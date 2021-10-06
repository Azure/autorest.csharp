// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Builders;
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
        private const string KeyAuthFieldName = "_keyCredential";
        private const string TokenAuthFieldName = "_tokenCredential";
        private const string AuthorizationHeaderConstantName = "AuthorizationHeader";
        private const string ScopesConstantName = "AuthorizationScopes";

        private static readonly CSharpType RequestOptionsParameterType = new(typeof(RequestOptions), true);

        private static readonly Parameter RequestOptionsParameter = new("options", "The request options", RequestOptionsParameterType, Constant.Default(RequestOptionsParameterType), false);
        private static readonly Parameter ResponseParameter = new("response", null, typeof(Response), null, false);
        private static readonly Parameter NextLinkParameter = new("nextLink", null, new CSharpType(typeof(string), true), null, false);
        private static readonly Parameter PageSizeHintParameter = new("pageSizeHint", null, new CSharpType(typeof(int), true), null, false);
        private static readonly Parameter EnumeratorCancellationTokenParameter = new("cancellationToken", "Enumerator cancellation token", typeof(CancellationToken), Constant.NewInstanceOf(typeof(CancellationToken)), false) { Attributes = new[] { new CSharpAttribute(typeof(EnumeratorCancellationAttribute)) } };

        private static readonly FormattableString ProcessMessageMethodName = $"{PipelineField:I}.{nameof(HttpPipelineExtensions.ProcessMessage)}";
        private static readonly FormattableString ProcessMessageMethodAsyncName = $"{PipelineField:I}.{nameof(HttpPipelineExtensions.ProcessMessageAsync)}";
        private static readonly FormattableString ProcessHeadAsBoolMessageMethodName = $"{PipelineField:I}.{nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessage)}";
        private static readonly FormattableString ProcessHeadAsBoolMessageMethodAsyncName = $"{PipelineField:I}.{nameof(HttpPipelineExtensions.ProcessHeadAsBoolMessageAsync)}";
        private static readonly FormattableString PageableProcessMessageMethodName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessage)}";
        private static readonly FormattableString PageableProcessMessageMethodAsyncName = $"{typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString LroProcessMessageMethodName = $"{typeof(LowLevelOperationHelpers)}.{nameof(LowLevelOperationHelpers.ProcessMessage)}";
        private static readonly FormattableString LroProcessMessageMethodAsyncName = $"{typeof(LowLevelOperationHelpers)}.{nameof(LowLevelOperationHelpers.ProcessMessageAsync)}";
        private static readonly FormattableString CreatePageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreatePageable)}";
        private static readonly FormattableString CreateAsyncPageableMethodName = $"{typeof(PageableHelpers)}.{nameof(PageableHelpers.CreateAsyncPageable)}";

        public void WriteClient(CodeWriter writer, LowLevelRestClient restClient, BuildContext context)
        {
            var cs = restClient.Type;
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{restClient.Description}");
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    var fieldNames = WriteClientFields(writer, restClient, context);
                    WriteConstructors(writer, restClient, context);

                    foreach (var clientMethod in restClient.ClientMethods)
                    {
                        WriteClientMethod(writer, clientMethod, context.Configuration, true);
                        WriteClientMethod(writer, clientMethod, context.Configuration, false);
                    }

                    foreach (var pagingMethod in restClient.PagingMethods)
                    {
                        WritePagingMethod(writer, pagingMethod, true);
                        WritePagingMethod(writer, pagingMethod, false);
                    }

                    foreach (var longRunningOperationMethod in restClient.LongRunningOperationMethods)
                    {
                        WriteLongRunningOperationMethod(writer, longRunningOperationMethod, true);
                        WriteLongRunningOperationMethod(writer, longRunningOperationMethod, false);
                    }

                    var responseClassifierTypes = new List<ResponseClassifierType>();
                    foreach (var method in restClient.Methods)
                    {
                        var responseClassifierType = CreateResponseClassifierType(method);
                        responseClassifierTypes.Add(responseClassifierType);
                        RequestWriterHelpers.WriteRequestCreation(writer, method, "internal", fieldNames, responseClassifierType.Name, false);
                    }

                    foreach ((string name, StatusCodes[] statusCodes) in responseClassifierTypes.Distinct())
                    {
                        WriteResponseClassifier(writer, name, statusCodes);
                    }
                }
            }
        }

        private static IReadOnlyDictionary<string, string> WriteClientFields(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            var fieldNames = new Dictionary<string, string>();

            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        writer.Line($"private const string {AuthorizationHeaderConstantName} = {azureKeySecurityScheme.HeaderName:L};");
                        writer.Line($"private readonly {typeof(AzureKeyCredential)}? {KeyAuthFieldName};");
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        writer.Append($"private static readonly string[] {ScopesConstantName} = ");
                        writer.Append($"{{ ");
                        foreach (var credentialScope in aadTokenSecurityScheme.Scopes)
                        {
                            writer.Append($"{credentialScope:L}, ");
                        }
                        writer.RemoveTrailingComma();
                        writer.Line($"}};");
                        writer.Line($"private readonly {typeof(TokenCredential)}? {TokenAuthFieldName};");
                        break;
                }
            }

            writer.Line();

            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            foreach (Parameter clientParameter in client.Parameters)
            {
                fieldNames.Add(clientParameter.Name, "_" + clientParameter.Name);
                writer.Line($"private readonly {clientParameter.Type} _{clientParameter.Name};");
            }

            writer.Line();

            writer.WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.");
            writer.Line($"public virtual {typeof(HttpPipeline)} {PipelineProperty} {{ get => {PipelineField}; }}");

            writer.Line();

            return fieldNames;
        }

        private static void WriteConstructors(CodeWriter writer, LowLevelRestClient client, BuildContext context)
        {
            WriteEmptyConstructor(writer, client);
            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                WriteConstructor(writer, client, scheme);
            }
        }

        private static void WriteConstructor(CodeWriter writer, LowLevelRestClient client, SecurityScheme securityScheme)
        {
            var clientOptionsType = client.ClientOptions.Type;
            var clientOptionsParameter = new Parameter("options", "The options for configuring the client.", clientOptionsType.WithNullable(true), Constant.Default(clientOptionsType.WithNullable(true)), false);

            var ctorParams = RestClientBuilder.GetConstructorParameters(client.Parameters, GetCredentialType(securityScheme)).Append(clientOptionsParameter).ToArray();
            var signature = new MethodSignature(client.Type.Name, $"Initializes a new instance of {client.Type.Name}", "public", ctorParams);

            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParameterNullChecks(ctorParams);
                writer.Line($"{clientOptionsParameter.Name} ??= new {clientOptionsType}();");

                writer.Line();
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({clientOptionsParameter.Name});");

                FormattableString perRetryPolicies = $"Array.Empty<{typeof(HttpPipelinePolicy)}>()";
                FormattableString perCallPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{ new {typeof(LowLevelCallbackPolicy)}()}}";

                var credentialParameter = ctorParams.FirstOrDefault(p => p.Name == "credential");
                if (credentialParameter != default)
                {
                    if (securityScheme is AzureKeySecurityScheme)
                    {
                        writer.Line($"{KeyAuthFieldName} = {credentialParameter.Name};");
                        perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(AzureKeyCredentialPolicy)}({KeyAuthFieldName}, {AuthorizationHeaderConstantName})}}";
                    }
                    else if (securityScheme is AADTokenSecurityScheme)
                    {
                        writer.Line($"{TokenAuthFieldName} = {credentialParameter.Name};");
                        perRetryPolicies = $"new {typeof(HttpPipelinePolicy)}[] {{new {typeof(BearerTokenAuthenticationPolicy)}({TokenAuthFieldName}, {ScopesConstantName})}}"; //(, }}";
                    }
                }

                writer.Line($"{PipelineField} = {typeof(HttpPipelineBuilder)}.{nameof(HttpPipelineBuilder.Build)}({clientOptionsParameter.Name}, {perCallPolicies}, {perRetryPolicies}, new {typeof(ResponseClassifier)}());");

                foreach (var parameter in client.Parameters)
                {
                    if (parameter.IsApiVersionParameter)
                    {
                        writer.Line($"_{parameter.Name:I} = {clientOptionsParameter.Name:I}.Version;");
                    }
                    else
                    {
                        writer.Line($"_{parameter.Name:I} = {parameter.Name:I};");
                    }
                }
            }
            writer.Line();
        }

        private static CSharpType? GetCredentialType(SecurityScheme scheme)
        {
            switch (scheme)
            {
                case AzureKeySecurityScheme:
                    return typeof(AzureKeyCredential);
                case AADTokenSecurityScheme:
                    return typeof(TokenCredential);
                case NoAuthSecurity:
                    return null;
                default:
                    throw new NotImplementedException($"Unknown security scheme: {scheme.GetType()}");
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

        private static void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, Configuration configuration, bool async)
        {
            var restMethod = clientMethod.RestMethod;
            var headAsBoolean = restMethod.Request.HttpMethod == RequestMethod.Head && configuration.HeadAsBoolean;

            var returnType = async
                ? headAsBoolean ? typeof(Task<Response<bool>>) : typeof(Task<Response>)
                : headAsBoolean ? typeof(Response<bool>) : typeof(Response);

            using (WriteClientMethodDeclaration(writer, restMethod, clientMethod.OperationSchemas, returnType, async))
            {
                using (WriteDiagnosticScope(writer, clientMethod.Diagnostics, ClientDiagnosticsField))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    writer.Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(restMethod.Name)}({restMethod.Parameters.GetNamesForMethodCall()});");

                    var methodName = async
                        ? headAsBoolean ? ProcessHeadAsBoolMessageMethodAsyncName : ProcessMessageMethodAsyncName
                        : headAsBoolean ? ProcessHeadAsBoolMessageMethodName : ProcessMessageMethodName;

                    writer.AppendRaw("return ").WriteMethodCall(async, methodName, $"{messageVariable}, {ClientDiagnosticsField}, {RequestOptionsParameter.Name:I}");
                }
            }
            writer.Line();
        }

        private static void WritePagingMethod(CodeWriter writer, LowLevelPagingMethod clientMethod, bool async)
        {
            var method = clientMethod.FirstPageMethod;
            var pagingResponseInfo = clientMethod.PagingResponseInfo;
            var nextPageMethod = clientMethod.PagingResponseInfo.NextPageMethod;
            var returnType = async ? typeof(AsyncPageable<BinaryData>) : typeof(Pageable<BinaryData>);

            var createPageableMethodName = async ? CreateAsyncPageableMethodName : CreatePageableMethodName;

            using (WriteClientMethodDeclaration(writer, method, clientMethod.OperationSchemas, returnType, async))
            {
                writer.WriteParameterNullChecks(method.Parameters);
                var createEnumerableMethod = new CodeWriterDeclaration(CreateMethodName("CreateEnumerable", async));
                var createEnumerableParameters = async ? new[] { NextLinkParameter, PageSizeHintParameter, EnumeratorCancellationTokenParameter } : new[] { NextLinkParameter, PageSizeHintParameter };
                var createEnumerableReturnType = async ? typeof(IAsyncEnumerable<Page<BinaryData>>) : typeof(IEnumerable<Page<BinaryData>>);

                writer.Line($"return {createPageableMethodName}({createEnumerableMethod:D}, {ClientDiagnosticsField}, {clientMethod.Diagnostic.ScopeName:L});");

                // We don't properly handle the case when one of the parameters has a name "nextLink" but isn't a continuation token
                // So we assume that it is a string and use variable "nextLink" without declaration.
                var createEnumerableMethodSignature = new MethodSignature(createEnumerableMethod.ActualName, null, async ? "async " : string.Empty, createEnumerableReturnType, null, createEnumerableParameters);
                using (writer.WriteMethodDeclaration(createEnumerableMethodSignature))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var pageVariable = new CodeWriterDeclaration("page");
                    FormattableString processMessageMethodParameters = $"{PipelineField:I}, {messageVariable}, {ClientDiagnosticsField}, {RequestOptionsParameter.Name:I}, {pagingResponseInfo.ItemName:L}, {pagingResponseInfo.NextLinkName:L}{(async ? $", {EnumeratorCancellationTokenParameter.Name:I}" : "")}";

                    if (nextPageMethod == null)
                    {
                        writer
                            .Line($"using var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetNamesForMethodCall()});")
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
                                .Line($"    ? Create{method.Name}Request({method.Parameters.GetNamesForMethodCall()})")
                                .Line($"    : Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetNamesForMethodCall()});");
                        }
                        else
                        {
                            writer.Line($"var {messageVariable:D} = Create{method.Name}Request({method.Parameters.GetNamesForMethodCall()});");
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

        private static void WriteLongRunningOperationMethod(CodeWriter writer, LowLevelLongRunningOperationMethod clientMethod, bool async)
        {
            var startMethod = clientMethod.StartMethod;
            var pagingResponseInfo = clientMethod.PagingResponseInfo;
            var nextPageMethod = clientMethod.PagingResponseInfo?.NextPageMethod;
            var finalStateVia = startMethod.Operation.LongRunningFinalStateVia;
            var scopeName = clientMethod.Diagnostic.ScopeName;
            var isPageable = nextPageMethod != null;

            var returnType = isPageable
                ? async ? typeof(Task<Operation<AsyncPageable<BinaryData>>>) : typeof(Operation<Pageable<BinaryData>>)
                : async ? typeof(Task<Operation<BinaryData>>) : typeof(Operation<BinaryData>);

            using (WriteClientMethodDeclaration(writer, startMethod, clientMethod.OperationSchemas, returnType, async))
            {
                var createEnumerableMethod = new CodeWriterDeclaration(CreateMethodName("CreateEnumerable", async));
                using (WriteDiagnosticScope(writer, clientMethod.Diagnostic, ClientDiagnosticsField))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var processMessageParameters = isPageable
                        ? (FormattableString)$"{PipelineField}, {messageVariable}, {ClientDiagnosticsField}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {RequestOptionsParameter.Name:I}, {createEnumerableMethod:D}"
                        : (FormattableString)$"{PipelineField}, {messageVariable}, {ClientDiagnosticsField}, {scopeName:L}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {RequestOptionsParameter.Name:I}";

                    writer
                        .Line($"using {typeof(HttpMessage)} {messageVariable:D} = {RequestWriterHelpers.CreateRequestMethodName(startMethod.Name)}({startMethod.Parameters.GetNamesForMethodCall()});")
                        .AppendRaw("return ")
                        .WriteMethodCall(async, LroProcessMessageMethodAsyncName, LroProcessMessageMethodName, processMessageParameters);
                }

                if (nextPageMethod != null && pagingResponseInfo != null)
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
                                .Line($"{pageVariable} = {typeof(LowLevelPageableHelpers)}.{nameof(LowLevelPageableHelpers.BuildPageForResponse)}(response, {pagingResponseInfo.ItemName:L}, {pagingResponseInfo.NextLinkName:L});")
                                .Line($"{NextLinkParameter.Name} = {pageVariable}.{nameof(Page<BinaryData>.ContinuationToken)};")
                                .Line($"yield return {pageVariable};");
                        }

                        using (writer.Scope($"while (!string.IsNullOrEmpty({NextLinkParameter.Name}))"))
                        {
                            var messageVariable = new CodeWriterDeclaration("message");
                            writer.Line($"var {messageVariable:D} = Create{nextPageMethod.Name}Request({nextPageMethod.Parameters.GetNamesForMethodCall()});");

                            FormattableString pageableProcessMessageParameters = $"{PipelineField}, {messageVariable}, {ClientDiagnosticsField}, {RequestOptionsParameter.Name:I}, {pagingResponseInfo.ItemName:L}, {pagingResponseInfo.NextLinkName:L}{(async ? $", {EnumeratorCancellationTokenParameter.Name:I}" : "")}";

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

        private static CodeWriter.CodeWriterScope WriteClientMethodDeclaration(CodeWriter writer, RestClientMethod clientMethod, LowLevelOperationSchemaInfo operationSchemas, CSharpType returnType, bool async)
        {
            var parameters = clientMethod.Parameters.Append(RequestOptionsParameter);
            var asyncText = (async && (clientMethod.Operation.Language.Default.Paging == null || clientMethod.Operation.IsLongRunning)) ? " async" : string.Empty;
            var methodSignature = new MethodSignature(CreateMethodName(clientMethod.Name, async), clientMethod.Description, $"{clientMethod.Accessibility} virtual{asyncText}", returnType, null, parameters.ToArray());

            writer.WriteMethodDocumentation(methodSignature);
            WriteSchemaDocumentationRemarks(writer, operationSchemas);
            return writer.WriteMethodDeclaration(methodSignature, "AZC0002");
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
            BuildSchemaFromDoc(builder, docs.FirstOrDefault(), docDict, showRequired, 2);
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
            HashSet<string> visitedSchema = new HashSet<string>();
            Queue<Schema> schemasToExplore = new Queue<Schema>(new Schema[] { schema });
            List<(string SchemaName, List<SchemaDocumentation.DocumentationRow> Rows)> documentationObjects = new();

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

        private static string StringifyTypeForTable(Schema s)
        {
            string RemovePrefix(string s, string prefix)
            {
                if (s.StartsWith(prefix))
                {
                    return s.Substring(prefix.Length);
                }

                return s;
            }

            switch (s)
            {
                case BooleanSchema:
                    return "boolean";
                case StringSchema:
                    return "string";
                case NumberSchema:
                    return "number";
                case AnySchema:
                    return "object";
                case DateTimeSchema:
                    return "string (ISO 8601 Format)";
                case ChoiceSchema c:
                    return string.Join(" | ", c.Choices.Select(c => $"\"{c.Value}\""));
                case DictionarySchema d:
                    return $"Dictionary<string, {StringifyTypeForTable(d.ElementType)}>";
                case ArraySchema a:
                    return $"{StringifyTypeForTable(a.ElementType)}[]";
                default:
                    return $"{RemovePrefix(s.Name, "Json")}";
            }
        }

        private class SchemaDocumentation
        {
            internal record DocumentationRow(string Name, string Type, bool Required, string Description) { }

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
