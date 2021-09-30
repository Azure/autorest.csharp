// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Output.Builders;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Generation.Writers;
using System.Text;
using System.Collections;
using AutoRest.CSharp.Output.Models.Responses;
using Response = Azure.Response;
using AutoRest.CSharp.AutoRest.Plugins;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelDataPlaneClientWriter : ClientWriter
    {
        public void WriteClient(CodeWriter writer, LowLevelDataPlaneClient client, BuildContext context)
        {
            var cs = client.Type;
            using (writer.Namespace(cs.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{client.Description}");
                using (writer.Scope($"{client.Declaration.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client, context);
                    WriteClientCtors(writer, client, context);

                    foreach (var clientMethod in client.Methods)
                    {
                        WriteClientMethod(writer, clientMethod, context.Configuration, true);
                        WriteClientMethod(writer, clientMethod, context.Configuration, false);
                    }

                    foreach (var pagingMethod in client.PagingMethods)
                    {
                        WritePagingMethod(writer, pagingMethod, context.Configuration, true);
                        WritePagingMethod(writer, pagingMethod, context.Configuration, false);
                    }

                    foreach (var longRunningOperationMethod in client.LongRunningOperationMethods)
                    {
                        WriteLongRunningOperationMethod(writer, longRunningOperationMethod, context.Configuration, true);
                        WriteLongRunningOperationMethod(writer, longRunningOperationMethod, context.Configuration, false);
                    }
                }
            }
        }

        private void WriteClientMethod(CodeWriter writer, LowLevelClientMethod clientMethod, Configuration configuration, bool async)
        {
            WriteClientMethodDecleration(writer, clientMethod.RestMethod, clientMethod.OperationSchemas, configuration, async);
            WriteClientMethodBody(writer, clientMethod, async);
        }

        private void WritePagingMethod(CodeWriter writer, LowLevelPagingMethod clientMethod, Configuration configuration, bool async)
        {
            var pageMethodReturnType = async ? new CSharpType(typeof(Task<Page<BinaryData>>)) : new CSharpType(typeof(Page<BinaryData>));
            var asyncText = async ? "async " : string.Empty;
            var awaitText = async ? "await " : string.Empty;
            var enumerableFactoryMethod = async ? "CreateAsyncEnumerable" : "CreateEnumerable";

            WriteClientMethodDecleration(writer, clientMethod.FirstPageMethod, clientMethod.OperationSchemas, configuration, async);

            using (writer.Scope())
            {
                writer.Line($"options ??= new {typeof(Azure.RequestOptions)}();");

                var enumeratedParameterMap = WriteEnumerableArgumentEnumerationStatements(writer, clientMethod.FirstPageMethod);

                writer.Line($"{asyncText}{pageMethodReturnType} FirstPageFunc(int? pageSizeHint)");
                using (writer.Scope())
                {
                    WritePagingFuncMethodBody(writer, clientMethod.Diagnostic, clientMethod.FirstPageMethod, clientMethod.PagingResponseInfo, async, enumeratedParameterMap);
                }
                writer.Line();

                if (clientMethod.PagingResponseInfo.NextPageMethod != null)
                {
                    writer.Line($"{asyncText}{pageMethodReturnType} NextPageFunc(string nextLink, int? pageSizeHint)");
                    using (writer.Scope())
                    {
                        WritePagingFuncMethodBody(writer, clientMethod.Diagnostic, clientMethod.PagingResponseInfo.NextPageMethod, clientMethod.PagingResponseInfo, async, enumeratedParameterMap);
                    }
                    writer.Line();
                }

                writer.Line($"return PageableHelpers.{enumerableFactoryMethod}(FirstPageFunc, {(clientMethod.PagingResponseInfo.NextPageMethod != null ? "NextPageFunc" : "null")});");
            }

            writer.Line();
        }

        private Dictionary<string, CodeWriterDeclaration> WriteEnumerableArgumentEnumerationStatements(CodeWriter writer, RestClientMethod clientMethod)
        {
            var enumeratedParameterMap = new Dictionary<string, CodeWriterDeclaration>();

            foreach (Parameter p in clientMethod.Parameters)
            {
                if (TypeFactory.IsIEnumerableType(p.Type))
                {
                    writer.UseNamespace("System.Linq");
                    CodeWriterDeclaration d = new CodeWriterDeclaration($"{p.Name}Values");
                    writer.Line($"var {d:D} = {p.Name}.ToArray();");
                    enumeratedParameterMap[p.Name] = d;
                }
            }

            return enumeratedParameterMap;
        }

        private void WritePagingFuncMethodBody(CodeWriter writer, Diagnostic diagnostic, RestClientMethod serviceMethod, LowLevelPagingResponseInfo pagingResponseInfo, bool async, Dictionary<string, CodeWriterDeclaration> enumeratedParameterMap)
        {
            WriteDiagnosticScope(writer, diagnostic, ClientDiagnosticsField, writer =>
            {
                var responseVariable = new CodeWriterDeclaration("response");

                writer.Append($"{typeof(Response)} {responseVariable:D} = ");

                if (async)
                {
                    writer.Append($"await ");
                }

                writer.Append($"{RestClientField}.{CreateMethodName(serviceMethod.Name, async)}(");
                foreach (var parameter in serviceMethod.Parameters)
                {
                    if (TypeFactory.IsIEnumerableType(parameter.Type))
                    {
                        writer.Append($"{enumeratedParameterMap[parameter.Name]:I}, ");
                    }
                    else
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                }
                writer.Append($"options)");

                if (async)
                {
                    writer.Append($".ConfigureAwait(false)");
                }

                writer.Line($";");

                writer.Append($"return LowLevelPagableHelpers.BuildPageForResponse({responseVariable}, \"{pagingResponseInfo.ItemName}\", ");

                if (pagingResponseInfo.NextLinkName != null)
                {
                    writer.Line($"\"{pagingResponseInfo.NextLinkName}\");");
                }
                else
                {
                    writer.Line($"null);");
                }
            });
        }

        private void WriteLongRunningOperationMethod(CodeWriter writer, LowLevelLongRunningOperationMethod clientMethod, Configuration configuration, bool async)
        {
            var finalStateVia = clientMethod.StartMethod.Operation.LongRunningFinalStateVia;

            WriteClientMethodDecleration(writer, clientMethod.StartMethod, clientMethod.OperationSchemas, configuration, async);
            WriteLongRunningOperationMethodBody(writer, clientMethod, async);
        }

        private void WriteLongRunningOperationMethodBody(CodeWriter writer, LowLevelLongRunningOperationMethod clientMethod, bool async)
        {
            var finalStateVia = clientMethod.StartMethod.Operation.LongRunningFinalStateVia;

            var pageMethodReturnType = async ? new CSharpType(typeof(Task<Page<BinaryData>>)) : new CSharpType(typeof(Page<BinaryData>));
            var asyncText = async ? "async " : string.Empty;
            var awaitText = async ? "await " : string.Empty;
            var operationReturnType = async ? new CSharpType(typeof(AsyncPageable<BinaryData>)) : new CSharpType(typeof(Pageable<BinaryData>));
            var enumerableFactoryMethod = async ? "CreateAsyncEnumerable" : "CreateEnumerable";

            using (writer.Scope())
            {
                if (clientMethod.PagingResponseInfo != null)
                {
                    if (clientMethod.PagingResponseInfo.NextPageMethod != null)
                    {
                        var enumeratedParameterMap = WriteEnumerableArgumentEnumerationStatements(writer, clientMethod.PagingResponseInfo.NextPageMethod);

                        writer.Line($"{asyncText}{pageMethodReturnType} NextPageFunc(string nextLink, int? pageSizeHint)");
                        using (writer.Scope())
                        {
                            WritePagingFuncMethodBody(writer, clientMethod.Diagnostic, clientMethod.PagingResponseInfo.NextPageMethod, clientMethod.PagingResponseInfo, async, enumeratedParameterMap);
                        }
                        writer.Line();
                    }
                }

                WriteDiagnosticScope(writer, clientMethod.Diagnostic, ClientDiagnosticsField, writer =>
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    writer.Append($"using {typeof(HttpMessage)} {messageVariable:D} = {RestClientField}.{RequestWriterHelpers.CreateRequestMethodName(clientMethod.StartMethod.Name)}(");
                    foreach (var parameter in clientMethod.StartMethod.Parameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Line($");");

                    var responseVariable = new CodeWriterDeclaration("response");
                    writer.Append($"{typeof(Response)} {responseVariable:D} = ");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.StartMethod.Name, async)}(");
                    foreach (var parameter in clientMethod.StartMethod.Parameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.Append($"options)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Line($";");

                    if (clientMethod.PagingResponseInfo == null)
                    {
                        writer.Line($"return new LowLevelFuncOperation<BinaryData>({ClientDiagnosticsField}, {PipelineField}, {messageVariable}.Request, {responseVariable}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {clientMethod.Diagnostic.ScopeName:L}, LowLevelOperationHelpers.ResponseContentSelector);");
                    }
                    else
                    {
                        writer.Line($"return new LowLevelFuncOperation<{operationReturnType}>({ClientDiagnosticsField}, {PipelineField}, {messageVariable}.Request, {responseVariable}, {typeof(OperationFinalStateVia)}.{finalStateVia}, {clientMethod.Diagnostic.ScopeName:L}, ({typeof(Response)} response) => {{");
                        {
                            writer.Line($"return PageableHelpers.{enumerableFactoryMethod}((int? pageSizeHint) => {{");
                            {
                                writer.Append($"return ");
                                if (async)
                                {
                                    writer.Append($"Task.FromResult(");
                                }

                                writer.Append($"LowLevelPagableHelpers.BuildPageForResponse(response, \"{clientMethod.PagingResponseInfo.ItemName}\", ");

                                if (clientMethod.PagingResponseInfo.NextLinkName != null)
                                {
                                    writer.Append($"\"{clientMethod.PagingResponseInfo.NextLinkName}\"");
                                }
                                else
                                {
                                    writer.Append($"null");
                                }

                                if (async)
                                {
                                    writer.Append($")");
                                }

                                writer.Line($");");
                            }

                            writer.Line($"}}, {(clientMethod.PagingResponseInfo.NextPageMethod != null ? "NextPageFunc" : "null")});");
                            writer.LineRaw("});");
                        }
                    }
                });
            }

            writer.Line();
        }

        private void WriteClientMethodBody(CodeWriter writer, LowLevelClientMethod clientMethod, bool async)
        {
            using (writer.Scope())
            {
                WriteDiagnosticScope(writer, clientMethod.Diagnostics, ClientDiagnosticsField, writer =>
                {
                    writer.Append($"return ");

                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    writer.Append($"{RestClientField}.{CreateMethodName(clientMethod.RestMethod.Name, async)}(");
                    foreach (var parameter in clientMethod.RestMethod.Parameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.Append($"options)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        private static readonly CSharpType RequestOptionsParameterType = new CSharpType(typeof(RequestOptions), true);
        private static readonly Parameter RequestOptionsParameter = new Parameter("options", "The request options", RequestOptionsParameterType, Constant.Default(RequestOptionsParameterType), false);

        private void WriteClientMethodDecleration(CodeWriter writer, RestClientMethod clientMethod, LowLevelOperationSchemaInfo operationSchemas, Configuration configuration, bool async)
        {
            var parameters = clientMethod.Parameters.Concat(new Parameter[] { RequestOptionsParameter });
            var headAsBoolean = clientMethod.Request.HttpMethod == RequestMethod.Head && configuration.HeadAsBoolean;

            var responseType = new CSharpType((async, clientMethod.Operation.IsLongRunning, clientMethod.Operation.Language.Default.Paging != null) switch
            {
                (false, false, false) => headAsBoolean == true ? typeof(Response<bool>) : typeof(Response),
                (false, true, false) => typeof(Operation<BinaryData>),
                (true, false, false) => headAsBoolean == true ? typeof(Task<Response<bool>>) : typeof(Task<Response>),
                (true, true, false) => typeof(Task<Operation<BinaryData>>),
                (false, false, true) => typeof(Pageable<BinaryData>),
                (false, true, true) => typeof(Operation<Pageable<BinaryData>>),
                (true, false, true) => typeof(AsyncPageable<BinaryData>),
                (true, true, true) => typeof(Task<Operation<AsyncPageable<BinaryData>>>)
            });

            writer.WriteXmlDocumentationSummary($"{clientMethod.Description}");

            foreach (var parameter in parameters)
            {
                var description = parameter.Description;
                if (parameter.AllowedValues != null && parameter.AllowedValues.Count > 0)
                {
                    if (description?.EndsWith(".") == false)
                        description += ".";
                    var allowedValues = string.Join(" | ", parameter.AllowedValues.Select(v => $"\"{v}\""));
                    description = $"{description} Allowed values: {BuilderHelpers.EscapeXmlDescription(allowedValues)}";
                }
                writer.WriteXmlDocumentationParameter(parameter.Name, $"{description}");
            }

            WriteSchemaDocumentationRemarks(writer, operationSchemas);

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = (async && (clientMethod.Operation.Language.Default.Paging == null || clientMethod.Operation.IsLongRunning)) ? "async" : string.Empty;
            writer.Line($"#pragma warning disable AZC0002");
            writer.Append($"{clientMethod.Accessibility} virtual {asyncText} {responseType} {methodName}(");

            foreach (var parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            writer.Line($"#pragma warning restore AZC0002");
        }

        private const string CredentialVariable = "credential";
        private const string OptionsVariable = "options";
        private const string AuthorizationHeaderConstant = "AuthorizationHeader";
        private const string ScopesConstant = "AuthorizationScopes";
        private const string KeyAuthField = "_keyCredential";
        private const string TokenAuthField = "_tokenCredential";
        private const string ResponseSelectorField = "_responseContentSelector";
        private new const string RestClientField = "_restClient";

        private void WriteClientFields(CodeWriter writer, LowLevelDataPlaneClient client, BuildContext context)
        {
            writer.WriteXmlDocumentationSummary($"The HTTP pipeline for sending and receiving REST requests and responses.");
            writer.Append($"public virtual {typeof(HttpPipeline)} {PipelineProperty}");
            writer.LineRaw("{ get => " + PipelineField + "; }");

            writer.Line($"private {typeof(HttpPipeline)} {PipelineField};");
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private readonly {client.RestClient.Declaration.Name} {RestClientField};");

            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme azureKeySecurityScheme:
                        writer.Line($"private const string {AuthorizationHeaderConstant} = {azureKeySecurityScheme.HeaderName:L};");
                        writer.Line($"private readonly {typeof(AzureKeyCredential)}? {KeyAuthField};");
                        break;
                    case AADTokenSecurityScheme aadTokenSecurityScheme:
                        writer.Append($"private readonly string[] {ScopesConstant} = ");
                        writer.Append($"{{ ");
                        foreach (var credentialScope in aadTokenSecurityScheme.Scopes)
                        {
                            writer.Append($"{credentialScope:L}, ");
                        }
                        writer.RemoveTrailingComma();
                        writer.Line($"}};");
                        writer.Line($"private readonly {typeof(TokenCredential)}? {TokenAuthField};");
                        break;
                }
            }

            writer.Line();
        }

        private void WriteClientCtors(CodeWriter writer, LowLevelDataPlaneClient client, BuildContext context)
        {
            WriteEmptyConstructor(writer, client);

            foreach (var scheme in context.CodeModel.Security.GetSchemesOrAnonymous())
            {
                WriteConstructor(writer, client, scheme, context);
            }
        }

        private void WriteEmptyConstructor(CodeWriter writer, LowLevelDataPlaneClient client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }
            writer.Line();
        }

        private CSharpType? GetCredentialType(SecurityScheme scheme)
        {
            switch (scheme)
            {
                case AzureKeySecurityScheme azureKeySecurityScheme:
                    return typeof(AzureKeyCredential);
                case AADTokenSecurityScheme aadTokenSecurityScheme:
                    return typeof(TokenCredential);
                case NoAuthSecurity noAuthSecurityScheme:
                    return null;
                default:
                    throw new NotImplementedException($"Unknown security scheme: {scheme.GetType()}");
            }
        }

        private void WriteConstructor(CodeWriter writer, LowLevelDataPlaneClient client, SecurityScheme securityScheme, BuildContext context)
        {
            var ctorParams = client.GetConstructorParameters(GetCredentialType(securityScheme));

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }
            writer.WriteXmlDocumentationParameter(OptionsVariable, $"The options for configuring the client.");

            var clientOptionsName = ClientBuilder.GetClientPrefix(context.DefaultLibraryName, context);
            writer.Append($"public {client.Type.Name:D}(");
            foreach (Parameter parameter in ctorParams)
            {
                writer.WriteParameter(parameter);
            }
            writer.Append($" {clientOptionsName}ClientOptions {OptionsVariable} = null)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(ctorParams);
                writer.Line();

                writer.Line($"{OptionsVariable} ??= new {clientOptionsName}ClientOptions();");
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}({OptionsVariable});");

                var authPolicy = new CodeWriterDeclaration("authPolicy");
                if (securityScheme is AzureKeySecurityScheme)
                {
                    writer.Line($"{KeyAuthField} = {CredentialVariable};");
                    writer.Line($"var {authPolicy:D} = new {typeof(AzureKeyCredentialPolicy)}({KeyAuthField}, {AuthorizationHeaderConstant});");
                }
                else if (securityScheme is AADTokenSecurityScheme)
                {
                    writer.Line($"{TokenAuthField} = {CredentialVariable};");
                    writer.Line($"var {authPolicy:D} = new {typeof(BearerTokenAuthenticationPolicy)}({TokenAuthField}, {ScopesConstant});");
                }

                writer.Append($"{PipelineField} = {typeof(HttpPipelineBuilder)}.Build({OptionsVariable}, new {typeof(HttpPipelinePolicy)}[] ");
                writer.AppendRaw("{");
                writer.Append($" new {typeof(LowLevelCallbackPolicy)}() ");
                writer.AppendRaw("}, ");
                if (securityScheme is NoAuthSecurity)
                {
                    writer.Append($"Array.Empty<{typeof(HttpPipelinePolicy)}>()");
                }
                else
                {
                    writer
                        .Append($"new {typeof(HttpPipelinePolicy)}[] {{")
                        .Append($" {authPolicy:I} ")
                        .AppendRaw("}");
                }
                writer.Line($", new {typeof(ResponseClassifier)}());");

                writer.Append($"this.{RestClientField} = new {client.RestClient.Type}({ClientDiagnosticsField}, {PipelineField}, ");
                foreach (var parameter in client.RestClient.Parameters)
                {
                    if (!parameter.IsApiVersionParameter)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    else
                    {
                        writer.Append($"{OptionsVariable}.Version, ");
                    }
                }
                writer.RemoveTrailingComma();
                writer.Append($");");
            }
            writer.Line();
        }

        private void WriteSchemaDocumentationRemarks(CodeWriter writer, LowLevelOperationSchemaInfo documentationSchemas)
        {
            var schemas = new List<FormattableString>();

            void AddDocumentationForSchema(Schema? schema, string schemaName, bool showRequried)
            {
                if (schema == null)
                {
                    return;
                }

                var docs = GetSchemaDocumentationsForSchema(schema, schemaName);

                if (docs != null)
                {
                    schemas!.Add($"Schema for <c>{schemaName}</c>:{Environment.NewLine}<code>{BuildSchemaFromDocs(docs, showRequried)}</code>{Environment.NewLine}");
                }
            }

            AddDocumentationForSchema(documentationSchemas.RequestBodySchema, "Request Body", true);
            AddDocumentationForSchema(documentationSchemas.ResponseBodySchema, "Response Body", false);
            AddDocumentationForSchema(documentationSchemas.ResponseErrorSchema, "Response Error", false);

            if (schemas.Count > 0)
            {
                writer.WriteXmlDocumentation("remarks", $"{schemas}");
            }
        }

        private string BuildSchemaFromDocs(SchemaDocumentation[] docs, bool showRequired)
        {
            var docDict = docs.ToDictionary(d => d.SchemaName, d => d);
            var builder = new StringBuilder();
            builder.AppendLine("{");
            BuildSchemaFromDoc(builder, docs.FirstOrDefault(), docDict, showRequired, 2);
            builder.AppendLine("}");
            return builder.ToString();
        }

        private void BuildSchemaFromDoc(StringBuilder builder, SchemaDocumentation doc, IDictionary<string, SchemaDocumentation> docDict, bool showRequired, int indentation = 0)
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

        internal class SchemaDocumentation
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
    }
}
