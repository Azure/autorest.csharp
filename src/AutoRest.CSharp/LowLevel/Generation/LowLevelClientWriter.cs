// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelClientWriter : ClientWriter
    {
        private static readonly Parameter ResponseParameter = new("response", null, typeof(Response), null, false);
        private static readonly Parameter NextLinkParameter = new("nextLink", null, new CSharpType(typeof(string), true), null, false);
        private static readonly Parameter PageSizeHintParameter = new("pageSizeHint", null, new CSharpType(typeof(int), true), null, false);
        private static readonly Parameter EnumeratorCancellationTokenParameter = new("cancellationToken", "Enumerator cancellation token", typeof(CancellationToken), Constant.NewInstanceOf(typeof(CancellationToken)), false) { Attributes = new[] { new CSharpAttribute(typeof(EnumeratorCancellationAttribute)) } };

        private static readonly FormattableString PageableProcessMessageMethodName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessage)}";
        private static readonly FormattableString PageableProcessMessageMethodAsyncName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageMethodName = $"{typeof(LowLevelOperationHelpers)}.{nameof(LowLevelOperationHelpers.ProcessMessage)}";
        private static readonly FormattableString LroProcessMessageMethodAsyncName = $"{typeof(LowLevelOperationHelpers)}.{nameof(LowLevelOperationHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString CreatePageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreatePageable)}";
        private static readonly FormattableString CreateAsyncPageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreateAsyncPageable)}";

        public void WriteClient(CodeWriter writer, LowLevelClient client, LowLevelClient[] subClients, BuildContext<LowLevelOutputLibrary> context)
        {
            var cs = client.Type;
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{client.Description}");
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client);
                    WriteConstructors(writer, client);

                    foreach (var clientMethod in client.ClientMethods)
                    {
                        if (clientMethod.IsLongRunning)
                        {
                            WriteLongRunningOperationMethod(writer, clientMethod, client.Fields, true);
                            WriteLongRunningOperationMethod(writer, clientMethod, client.Fields, false);
                        }
                        else if (clientMethod.PagingInfo != null)
                        {
                            WritePagingMethod(writer, clientMethod, client.Fields, true);
                            WritePagingMethod(writer, clientMethod, client.Fields, false);
                        }
                        else
                        {
                            WriteClientMethod(writer, client, clientMethod, context.Configuration, true);
                            WriteClientMethod(writer, client, clientMethod, context.Configuration, false);
                        }
                    }

                    WriteSubClientFactoryMethod(writer, context, client, subClients);

                    var responseClassifierTypes = new List<ResponseClassifierType>();
                    foreach (var method in client.RequestMethods)
                    {
                        var responseClassifierType = CreateResponseClassifierType(method);
                        responseClassifierTypes.Add(responseClassifierType);
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", client.Fields, responseClassifierType.Name, false);
                    }

                    foreach ((string name, StatusCodes[] statusCodes) in responseClassifierTypes.Distinct())
                    {
                        WriteResponseClassifier(writer, name, statusCodes);
                    }
                }
            }
        }

        private static void WriteClientFields(CodeWriter writer, LowLevelClient client)
        {
            foreach (var field in client.Fields)
            {
                writer.WriteFieldDeclaration(field);
            }

            writer
                .Line()
                .WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.")
                .Line($"public virtual {typeof(HttpPipeline)} Pipeline => {client.Fields.PipelineField.Name};");

            writer.Line();
        }

        private static void WriteConstructors(CodeWriter writer, LowLevelClient client)
        {
            WriteEmptyConstructor(writer, client);
            foreach (var constructor in client.PublicConstructors)
            {
                WritePublicConstructor(writer, client, constructor);
            }

            if (client.IsSubClient)
            {
                WriteSubClientInternalConstructor(writer, client, client.SubClientInternalConstructor);
            }
        }

        private static void WriteEmptyConstructor(CodeWriter writer, TypeProvider client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private static void WritePublicConstructor(CodeWriter writer, LowLevelClient client, MethodSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParameterNullChecks(signature.Parameters);
                writer.Line();

                var clientOptionsParameter = signature.Parameters.Last(p => p.Type.EqualsIgnoreNullable(client.ClientOptions.Type));
                writer.Line($"{client.Fields.ClientDiagnosticsField.Name:I} = new {client.Fields.ClientDiagnosticsField.Type}({clientOptionsParameter.Name:I});");

                FormattableString perCallPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";
                FormattableString perRetryPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";

                var credentialParameter = signature.Parameters.FirstOrDefault(p => p.Name == "credential");
                if (credentialParameter != null)
                {
                    var credentialField = client.Fields.GetFieldByParameter(credentialParameter);
                    if (credentialField != null)
                    {
                        var fieldName = credentialField.Name;
                        writer.Line($"{fieldName:I} = {credentialParameter.Name:I};");
                        if (credentialField.Type.Equals(typeof(AzureKeyCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(AzureKeyCredentialPolicy)}({fieldName:I}, {client.Fields.AuthorizationHeaderConstant!.Name})}}";
                        }
                        else if (credentialField.Type.Equals(typeof(TokenCredential)))
                        {
                            perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(BearerTokenAuthenticationPolicy)}({fieldName:I}, {client.Fields.ScopesConstant!.Name})}}";
                        }
                    }
                }

                writer.Line($"{client.Fields.PipelineField.Name:I} = {typeof(HttpPipelineBuilder)}.{nameof(HttpPipelineBuilder.Build)}({clientOptionsParameter.Name:I}, {perCallPolicies}, {perRetryPolicies}, new {typeof(ResponseClassifier)}());");

                foreach (var parameter in client.Parameters)
                {
                    var field = client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        if (parameter.IsApiVersionParameter)
                        {
                            writer.Line($"{field.Name:I} = {clientOptionsParameter.Name:I}.Version;");
                        }
                        else
                        {
                            writer.Line($"{field.Name:I} = {parameter.Name:I};");
                        }
                    }
                }
            }
            writer.Line();
        }

        private static void WriteSubClientInternalConstructor(CodeWriter writer, LowLevelClient client, MethodSignature signature)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParameterNullChecks(signature.Parameters);
                writer.Line();

                foreach (var parameter in signature.Parameters)
                {
                    var field = client.Fields.GetFieldByParameter(parameter);
                    if (field != null)
                    {
                        writer.Line($"{field.Name:I} = {parameter.Name:I};");
                    }
                }
            }
            writer.Line();
        }

        private static void WriteClientMethod(CodeWriter writer, LowLevelClient client, LowLevelClientMethod clientMethod, Configuration configuration, bool async)
        {
            var restMethod = clientMethod.RequestMethod;
            var headAsBoolean = restMethod.Request.HttpMethod == RequestMethod.Head && configuration.HeadAsBoolean;

            var returnType = async
                ? headAsBoolean ? typeof(Task<Response<bool>>) : typeof(Task<Response>)
                : headAsBoolean ? typeof(Response<bool>) : typeof(Response);

            using (WriteClientMethodDeclaration(writer, clientMethod, clientMethod.OperationSchemas, returnType, async))
            {
                using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, client.Fields.ClientDiagnosticsField.Name))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    writer.Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(restMethod.Name)}({restMethod.Parameters.GetIdentifiersFormattable()});");

                    var methodName = async
                        ? headAsBoolean ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync) : nameof(HttpPipelineExtensions.ProcessMessageAsync)
                        : headAsBoolean ? nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage) : nameof(HttpPipelineExtensions.ProcessMessage);

                    writer.AppendRaw("return ").WriteMethodCall(async, $"{client.Fields.PipelineField.Name:I}.{methodName}", $"{messageVariable}, {client.Fields.ClientDiagnosticsField.Name}, {KnownParameters.RequestContext.Name:I}");
                }
            }
            writer.Line();
        }

        private static void WritePagingMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            var method = clientMethod.RequestMethod;
            var pagingInfo = clientMethod.PagingInfo!;
            var nextPageMethod = pagingInfo.NextPageMethod;
            var returnType = async ? typeof(AsyncPageable<BinaryData>) : typeof(Pageable<BinaryData>);

            var createPageableMethodName = async ? CreateAsyncPageableMethodName : CreatePageableMethodName;

            using (WriteClientMethodDeclaration(writer, clientMethod, clientMethod.OperationSchemas, returnType, async))
            {
                var createEnumerableMethod = new CodeWriterDeclaration(CreateMethodName("CreateEnumerable", async));
                var createEnumerableParameters = async ? new[] { NextLinkParameter, PageSizeHintParameter, EnumeratorCancellationTokenParameter } : new[] { NextLinkParameter, PageSizeHintParameter };
                var createEnumerableReturnType = async ? typeof(IAsyncEnumerable<Page<BinaryData>>) : typeof(IEnumerable<Page<BinaryData>>);

                writer.Line($"return {createPageableMethodName}({createEnumerableMethod:D}, {fields.ClientDiagnosticsField.Name:I}, {clientMethod.Diagnostic.ScopeName:L});");

                // We don't properly handle the case when one of the parameters has a name "nextLink" but isn't a continuation token
                // So we assume that it is a string and use variable "nextLink" without declaration.
                var createEnumerableMethodSignature = new MethodSignature(createEnumerableMethod.ActualName, null, async ? "async " : string.Empty, createEnumerableReturnType, null, createEnumerableParameters);
                using (writer.WriteMethodDeclaration(createEnumerableMethodSignature))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var pageVariable = new CodeWriterDeclaration("page");
                    FormattableString processMessageMethodParameters = $"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsField.Name:I}, {KnownParameters.RequestContext.Name:I}, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L}{(async ? $", {EnumeratorCancellationTokenParameter.Name:I}" : "")}";

                    if (nextPageMethod == null)
                    {
                        writer
                            .Line($"using var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()});")
                            .Append($"var {pageVariable:D} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, processMessageMethodParameters)
                            .Line($"yield return {pageVariable};");
                        return;
                    }

                    using (writer.Scope($"do", newLine: false))
                    {
                        if (method != nextPageMethod)
                        {
                            writer
                                .Line($"var {messageVariable:D} = string.IsNullOrEmpty(nextLink)")
                                .Line($"    ? Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()})")
                                .Line($"    : Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetIdentifiersFormattable()});");
                        }
                        else
                        {
                            writer.Line($"var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetIdentifiersFormattable()});");
                        }

                        writer
                            .Append($"var {pageVariable:D} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, processMessageMethodParameters)
                            .Line($"nextLink = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                            .Line($"yield return {pageVariable};");
                    }

                    writer.Line($"while (!string.IsNullOrEmpty(nextLink));");
                }
            }

            writer.Line();
        }

        private static void WriteLongRunningOperationMethod(CodeWriter writer, LowLevelClientMethod clientMethod, ClientFields fields, bool async)
        {
            var startMethod = clientMethod.RequestMethod;
            var pagingInfo = clientMethod.PagingInfo;
            var nextPageMethod = clientMethod.PagingInfo?.NextPageMethod;
            var finalStateVia = startMethod.Operation.LongRunningFinalStateVia;
            var scopeName = clientMethod.Diagnostic.ScopeName;
            var isPageable = nextPageMethod != null;

            var returnType = isPageable
                ? async ? typeof(Task<Operation<AsyncPageable<BinaryData>>>) : typeof(Operation<Pageable<BinaryData>>)
                : async ? typeof(Task<Operation<BinaryData>>) : typeof(Operation<BinaryData>);

            using (WriteClientMethodDeclaration(writer, clientMethod, clientMethod.OperationSchemas, returnType, async))
            {
                var createEnumerableMethod = new CodeWriterDeclaration(CreateMethodName("CreateEnumerable", async));
                using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, fields.ClientDiagnosticsField.Name))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var processMessageParameters = isPageable
                        ? (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsField.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}, {createEnumerableMethod:D}"
                        : (FormattableString)$"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsField.Name:I}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {KnownParameters.RequestContext.Name:I}, {KnownParameters.WaitForCompletion.Name:I}";

                    writer
                        .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetIdentifiersFormattable()});")
                        .AppendRaw("return ")
                        .WriteMethodCall(async, LroProcessMessageMethodAsyncName, LroProcessMessageMethodName, processMessageParameters);
                }

                if (nextPageMethod != null && pagingInfo != null)
                {
                    var createEnumerableParameters = async
                        ? new[] { ResponseParameter, NextLinkParameter, PageSizeHintParameter, EnumeratorCancellationTokenParameter }
                        : new[] { ResponseParameter, NextLinkParameter, PageSizeHintParameter };
                    var createEnumerableReturnType = async ? typeof(IAsyncEnumerable<Page<BinaryData>>) : typeof(IEnumerable<Page<BinaryData>>);
                    var createEnumerableSignature = new MethodSignature(createEnumerableMethod.ActualName, null, async ? "async " : string.Empty, createEnumerableReturnType, null, createEnumerableParameters);

                    using (writer.Line().WriteMethodDeclaration(createEnumerableSignature))
                    {
                        var pageVariable = new CodeWriterDeclaration("page");
                        writer.Line($"Page<BinaryData> {pageVariable:D};");

                        // We don't properly handle the case when one of the parameters has a name "nextLink" but isn't a continuation token
                        // So we assume that it is a string and use variable "nextLink" without declaration.
                        using (writer.Scope($"if ({NextLinkParameter.Name} == null)"))
                        {
                            writer
                                .Line($"{pageVariable} = {typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.BuildPageForResponse)}(response, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L});")
                                .Line($"{NextLinkParameter.Name} = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                                .Line($"yield return {pageVariable};");
                        }

                        using (writer.Scope($"while (!string.IsNullOrEmpty({NextLinkParameter.Name}))"))
                        {
                            var messageVariable = new CodeWriterDeclaration("message");
                            writer.Line($"var {messageVariable:D} = Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetIdentifiersFormattable()});");

                            FormattableString pageableProcessMessageParameters = $"{fields.PipelineField.Name:I}, {messageVariable}, {fields.ClientDiagnosticsField.Name:I}, {KnownParameters.RequestContext.Name:I}, {pagingInfo.ItemName:L}, {pagingInfo.NextLinkName:L}{(async ? $", {EnumeratorCancellationTokenParameter.Name:I}" : "")}";

                            writer
                                .Append($"{pageVariable} = ").WriteMethodCall(async, PageableProcessMessageMethodAsyncName, PageableProcessMessageMethodName, pageableProcessMessageParameters)
                                .Line($"{NextLinkParameter.Name} = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                                .Line($"yield return {pageVariable};");
                        }
                    }
                }
            }

            writer.Line();
        }

        private void WriteSubClientFactoryMethod(CodeWriter writer, BuildContext context, LowLevelClient parentClient, LowLevelClient[] subClients)
        {
            var factoryMethods = new List<(FieldDeclaration?, MethodSignature, List<Reference>)>();
            foreach (var subClient in subClients)
            {
                var methodParameters = new List<Parameter>();
                var constructorCallParameters = new List<Reference>();

                foreach (var parameter in subClient.SubClientInternalConstructor.Parameters)
                {
                    var field = parentClient.Fields.GetFieldByParameter(parameter);
                    if (field == null)
                    {
                        methodParameters.Add(parameter);
                        constructorCallParameters.Add(parameter);
                    }
                    else
                    {
                        constructorCallParameters.Add(new Reference(field.Name, field.Type));
                    }
                }

                var subClientName = subClient.Type.Name;
                var libraryName = context.DefaultLibraryName;
                var methodName = subClientName.StartsWith(libraryName)
                    ? subClientName[libraryName.Length..]
                    : subClientName;

                var methodSignature = new MethodSignature($"Get{methodName}{ClientBuilder.GetClientSuffix(context)}", $"Initializes a new instance of {subClient.Type.Name}", "public virtual", subClient.Type, null, methodParameters.ToArray());
                if (methodParameters.Any())
                {
                    factoryMethods.Add((null, methodSignature, constructorCallParameters));
                }
                else
                {
                    var field = new FieldDeclaration("private", subClient.Type, $"_cached{subClient.Type.Name}");
                    factoryMethods.Add((field, methodSignature, constructorCallParameters));
                }
            }

            foreach (var (field, _, _) in factoryMethods)
            {
                if (field != null)
                {
                    writer.WriteFieldDeclaration(field);
                }
            }

            writer.Line();

            foreach (var (field, methodSignature, constructorCallParameters) in factoryMethods)
            {
                writer.WriteMethodDocumentation(methodSignature);
                using (writer.WriteMethodDeclaration(methodSignature))
                {
                    writer.WriteParameterNullChecks(methodSignature.Parameters);
                    writer.Line();

                    if (field != null)
                    {
                        writer
                            .Append($"return {typeof(Volatile)}.{nameof(Volatile.Read)}(ref {field.Name})")
                            .Append($" ?? {typeof(Interlocked)}.{nameof(Interlocked.CompareExchange)}(ref {field.Name}, new {methodSignature.ReturnType}({constructorCallParameters.GetIdentifiersFormattable()}), null)")
                            .Line($" ?? {field.Name};");
                    }
                    else
                    {
                        writer.Line($"return new {methodSignature.ReturnType}({constructorCallParameters.GetIdentifiersFormattable()});");
                    }
                }
                writer.Line();
            }
        }

        private static void WriteResponseClassifier(CodeWriter writer, string responseClassifierTypeName, StatusCodes[] statusCodes)
        {
            using (writer.Scope($"private sealed class {responseClassifierTypeName} : {typeof(ResponseClassifier)}"))
            {
                writer.Line($"private static {typeof(ResponseClassifier)} _instance;");
                writer.Line($"public static {typeof(ResponseClassifier)} Instance => _instance ??= new {responseClassifierTypeName}();");

                using (writer.Scope($"public override bool {nameof(ResponseClassifier.IsErrorResponse)}({typeof(HttpMessage)} message)"))
                {
                    using (writer.Scope($"return message.{nameof(HttpMessage.Response)}.{nameof(Response.Status)} switch", end: "};"))
                    {
                        foreach (var statusCode in statusCodes)
                        {
                            if (statusCode.Code != null)
                            {
                                writer.Line($"{statusCode.Code} => false,");
                            }
                            else
                            {
                                writer.Line($">= {statusCode.Family * 100:L} and < {statusCode.Family * 100 + 100:L} => false,");
                            }
                        }

                        writer.LineRaw("_ => true");
                    }
                }
            }
        }

        private static CodeWriter.CodeWriterScope WriteClientMethodDeclaration(CodeWriter writer, LowLevelClientMethod clientMethod, LowLevelOperationSchemaInfo operationSchemas, CSharpType returnType, bool async)
        {
            var parameters = clientMethod.IsLongRunning
                ? clientMethod.RequestMethod.Parameters.Prepend(KnownParameters.WaitForCompletion).ToArray()
                : clientMethod.RequestMethod.Parameters;
            var asyncText = async && (clientMethod.PagingInfo == null || clientMethod.IsLongRunning) ? " async" : string.Empty;
            var methodSignature = new MethodSignature(CreateMethodName(clientMethod.RequestMethod.Name, async), clientMethod.RequestMethod.Description, $"{clientMethod.RequestMethod.Accessibility} virtual{asyncText}", returnType, null, parameters);

            writer.WriteMethodDocumentation(methodSignature);
            WriteSchemaDocumentationRemarks(writer, operationSchemas);
            var declaration = writer.WriteMethodDeclaration(methodSignature, "AZC0002");
            writer.WriteParameterNullChecks(parameters);
            return declaration;
        }

        private static ResponseClassifierType CreateResponseClassifierType(RestClientMethod method)
        {
            var statusCodes = method.Responses
                .SelectMany(r => r.StatusCodes)
                .Distinct()
                .OrderBy(c => c.Code ?? c.Family * 100);
            return new ResponseClassifierType(statusCodes);
        }

        private static void WriteSchemaDocumentationRemarks(CodeWriter writer, LowLevelOperationSchemaInfo documentationSchemas)
        {
            var schemas = new List<FormattableString>();

            AddDocumentationForSchema(schemas, documentationSchemas.RequestBodySchema, "Request Body", true);
            AddDocumentationForSchema(schemas, documentationSchemas.ResponseBodySchema, "Response Body", false);
            AddDocumentationForSchema(schemas, documentationSchemas.ResponseErrorSchema, "Response Error", false);

            if (schemas.Count > 0)
            {
                writer.WriteXmlDocumentation("remarks", $"{schemas}");
            }

            static void AddDocumentationForSchema(List<FormattableString> formattedSchemas, Schema? schema, string schemaName, bool showRequried)
            {
                if (schema == null)
                {
                    return;
                }

                var docs = GetSchemaDocumentationsForSchema(schema, schemaName);

                if (docs != null)
                {
                    formattedSchemas.Add($"Schema for <c>{schemaName}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs, showRequried)}</code>{Environment.NewLine}");
                }
            }
        }

        private static string BuildSchemaFromDocs(SchemaDocumentation[] docs, bool showRequired)
        {
            var docDict = docs.ToDictionary(d => d.SchemaName, d => d);
            var builder = new StringBuilder();
            builder.AppendLine("{");
            BuildSchemaFromDoc(builder, docs.First(), docDict, showRequired, 2);
            builder.AppendLine("}");
            return builder.ToString();
        }

        private static void BuildSchemaFromDoc(StringBuilder builder, SchemaDocumentation doc, IDictionary<string, SchemaDocumentation> docDict, bool showRequired, int indentation = 0)
        {
            foreach (var row in doc.DocumentationRows)
            {
                var required = showRequired && row.Required ? " (required)" : string.Empty;
                var isArray = row.Type.EndsWith("[]");
                var rowType = isArray ? row.Type.Substring(0, row.Type.Length - 2) : row.Type;
                builder.AppendIndentation(indentation).Append($"{row.Name}: ");
                if (isArray)
                {
                    if (docDict.ContainsKey(rowType))
                    {
                        builder.AppendLine("[");
                        var docToProcess = docDict[rowType];
                        docDict.Remove(rowType); // In the case of cyclic reference where A has a property type of A itself, we just show the type A if it's not the first time we meet A.
                        builder.AppendIndentation(indentation + 2).AppendLine("{");
                        BuildSchemaFromDoc(builder, docToProcess, docDict, showRequired, indentation + 4);
                        builder.AppendIndentation(indentation + 2).AppendLine("}");
                        builder.AppendIndentation(indentation).AppendLine($"]{required},");
                    }
                    else
                        builder.AppendLine($"[{rowType}]{required},");
                }
                else
                {
                    if (docDict.ContainsKey(rowType))
                    {
                        builder.AppendLine("{");
                        var docToProcess = docDict[rowType];
                        docDict.Remove(rowType); // In the case of cyclic reference where A has a property type of A itself, we just show the type A if it's not the first time we meet A.
                        BuildSchemaFromDoc(builder, docToProcess, docDict, showRequired, indentation + 2);
                        builder.AppendIndentation(indentation).Append("}").AppendLine($"{required},");
                    }
                    else
                        builder.AppendLine($"{rowType}{required},");
                }
            }
            // Remove the last "," by first removing ",\n", then add back "\n".
            builder.Length -= 1 + Environment.NewLine.Length;
            builder.AppendLine();
        }

        private static SchemaDocumentation[]? GetSchemaDocumentationsForSchema(Schema schema, string schemaName)
        {
            // Visit each schema in the graph and for object schemas, collect information about all the properties.
            var visitedSchema = new HashSet<string>();
            var schemasToExplore = new Queue<Schema>(new[] { schema });
            var documentationObjects = new List<(string SchemaName, List<SchemaDocumentation.DocumentationRow> Rows)>();

            while (schemasToExplore.Any())
            {
                Schema toExplore = schemasToExplore.Dequeue();

                if (visitedSchema.Contains(toExplore.Name))
                {
                    continue;
                }

                switch (toExplore)
                {
                    case OrSchema o:
                        foreach (Schema s in o.AnyOf)
                        {
                            schemasToExplore.Enqueue(s);
                        }
                        break;
                    case DictionarySchema d:
                        schemasToExplore.Enqueue(d.ElementType);
                        break;
                    case ArraySchema a:
                        schemasToExplore.Enqueue(a.ElementType);
                        break;
                    case ObjectSchema o:
                        List<SchemaDocumentation.DocumentationRow> propertyDocumentation = new();

                        // We must also include any properties introduced by our parent chain.
                        foreach (ObjectSchema s in (o.Parents?.All ?? Array.Empty<ComplexSchema>()).Concat(new ComplexSchema[] { o }).OfType<ObjectSchema>())
                        {
                            foreach (Property prop in s.Properties)
                            {
                                propertyDocumentation.Add(new SchemaDocumentation.DocumentationRow(
                                    prop.SerializedName,
                                    BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(prop.Schema)),
                                    prop.Required ?? false,
                                    BuilderHelpers.EscapeXmlDescription(prop.Language.Default.Description)));

                                schemasToExplore.Enqueue(prop.Schema);
                            }
                        }

                        documentationObjects.Add(new(schema == o ? schemaName : BuilderHelpers.EscapeXmlDescription(StringifyTypeForTable(o)), propertyDocumentation));
                        break;
                }

                visitedSchema.Add(toExplore.Name);
            }

            if (!documentationObjects.Any())
            {
                return null;
            }

            return documentationObjects.Select(o => new SchemaDocumentation(o.SchemaName, o.Rows.ToArray())).ToArray();
        }

        private static string StringifyTypeForTable(Schema schema)
        {
            string RemovePrefix(string s, string prefix)
            {
                return s.StartsWith(prefix) ? s[prefix.Length..] : s;
            }

            return schema switch
            {
                BooleanSchema => "boolean",
                StringSchema => "string",
                NumberSchema => "number",
                AnySchema => "object",
                DateTimeSchema => "string (ISO 8601 Format)",
                ChoiceSchema choiceSchema => string.Join(" | ", choiceSchema.Choices.Select(c => $"\"{c.Value}\"")),
                DictionarySchema d => $"Dictionary<string, {StringifyTypeForTable(d.ElementType)}>",
                ArraySchema a => $"{StringifyTypeForTable(a.ElementType)}[]",
                _ => $"{RemovePrefix(schema.Name, "Json")}"
            };
        }

        private class SchemaDocumentation
        {
            internal record DocumentationRow(string Name, string Type, bool Required, string Description);

            public string SchemaName { get; }
            public DocumentationRow[] DocumentationRows { get; }

            public SchemaDocumentation(string schemaName, DocumentationRow[] documentationRows)
            {
                SchemaName = schemaName;
                DocumentationRows = documentationRows;
            }
        }

        private readonly struct ResponseClassifierType : IEquatable<ResponseClassifierType>
        {
            public string Name { get; }
            private readonly StatusCodes[] _statusCodes;

            public ResponseClassifierType(IOrderedEnumerable<StatusCodes> statusCodes)
            {
                _statusCodes = statusCodes.ToArray();
                Name = nameof(ResponseClassifier) + string.Join("", _statusCodes.Select(c => c.Code?.ToString() ?? $"{c.Family * 100}To{(c.Family + 1) * 100}"));
            }

            public bool Equals(ResponseClassifierType other) => Name == other.Name;

            public override bool Equals(object? obj) => obj is ResponseClassifierType other && Equals(other);

            public override int GetHashCode() => Name.GetHashCode();

            internal void Deconstruct(out string name, out StatusCodes[] statusCodes)
            {
                name = Name;
                statusCodes = _statusCodes;
            }
        }
    }
}
