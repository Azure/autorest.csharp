// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.V3.AutoRest.Plugins;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.CodeAnalysis.Operations;
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class ClientWriter
    {
        public void WriteClient(CodeWriter writer, Client client, Configuration configuration)
        {
            var cs = client.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.DeclaredType.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client);

                    if (configuration.AzureArm)
                    {
                        WriteManagementClientCtors(writer, client, configuration);
                    }
                    else
                    {
                        WriteClientCtors(writer, client);
                    }

                    foreach (var clientMethod in client.Methods)
                    {
                        WriteClientMethod(writer, clientMethod, true);
                        WriteClientMethod(writer, clientMethod, false);
                    }

                    foreach (var pagingMethod in client.PagingMethods)
                    {
                        WritePagingOperation(writer, pagingMethod, true);
                        WritePagingOperation(writer, pagingMethod, false);
                    }

                    // We only need one CreateOperation method per overload group
                    HashSet<string> createOperations = new HashSet<string>();
                    foreach (var longRunningOperation in client.LongRunningOperationMethods)
                    {
                        if (createOperations.Add(longRunningOperation.Name))
                        {
                            WriteCreateOperationOperation(writer, longRunningOperation);
                        }

                        WriteStartOperationOperation(writer, longRunningOperation, true);
                        WriteStartOperationOperation(writer, longRunningOperation, false);
                    }
                }
            }
        }

        private void WriteManagementClientCtors(CodeWriter writer, Client client, Configuration configuration)
        {

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }

            writer.Line();

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            writer.Append($"public {client.Type.Name:D}(");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                // Skip host and API Version parameters that would be set later
                if (ManagementClientWriterHelpers.IsHostParameter(parameter) ||
                    ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                {
                    continue;
                }

                writer.WriteParameter(parameter);
            }

            writer.Append($"{typeof(TokenCredential)} tokenCredential, {configuration.LibraryName}ManagementClientOptions options = null)");

            using (writer.Scope())
            {
                writer.Line($"options ??= new {configuration.LibraryName}ManagementClientOptions();");
                writer.Line($"_clientDiagnostics = new {typeof(ClientDiagnostics)}(options);");
                writer.Line($"_pipeline = {typeof(ManagementPipelineBuilder)}.Build(tokenCredential, options);");

                writer.Append($"this.RestClient = new {client.RestClient.Type}(_clientDiagnostics, _pipeline, ");

                foreach (Parameter parameter in client.RestClient.Parameters)
                {
                    // Skip host and API Version parameters that would be set later
                    if (ManagementClientWriterHelpers.IsHostParameter(parameter) ||
                        ManagementClientWriterHelpers.IsApiVersionParameter(parameter))
                    {
                        continue;
                    }

                    writer.Append($"{parameter.Name}: {parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");

            }
            writer.Line();
        }

        private void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, bool async)
        {
            CSharpType? bodyType = clientMethod.RestClientMethod.ReturnType;
            CSharpType responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                typeof(Response);

            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;

            var parameters = clientMethod.RestClientMethod.Parameters;
            writer.WriteXmlDocumentationSummary(clientMethod.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(clientMethod.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public virtual {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteDiagnosticScope(writer, clientMethod.Diagnostics, writer =>
                {
                    writer.Append($"return (");
                    if (async)
                    {
                        writer.Append($"await ");
                    }

                    writer.Append($"RestClient.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                    foreach (var parameter in clientMethod.RestClientMethod.Parameters)
                    {
                        writer.Append($"{parameter.Name:I}, ");
                    }
                    writer.Append($"cancellationToken)");

                    if (async)
                    {
                        writer.Append($".ConfigureAwait(false)");
                    }

                    writer.Append($")");

                    if (bodyType == null && clientMethod.RestClientMethod.HeaderModel != null)
                    {
                        writer.Append($".GetRawResponse()");
                    }

                    writer.Line($";");
                });
            }

            writer.Line();
        }

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private string CreateCreateOperationName(string name) => $"Create{name}";

        private string CreateStartOperationName(string name, bool async) => $"Start{name}{(async ? "Async" : string.Empty)}";

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private void WriteClientFields(CodeWriter writer, Client client)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} _clientDiagnostics;");
            writer.Line($"private readonly {typeof(HttpPipeline)} _pipeline;");
            writer.Append($"internal {client.RestClient.Type} RestClient").LineRaw(" { get; }");
        }

        private void WriteClientCtors(CodeWriter writer, Client client)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name} for mocking.");
            using (writer.Scope($"protected {client.Type.Name:D}()"))
            {
            }

            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {client.Type.Name}");
            writer.Append($"internal {client.Type.Name:D}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline,");
            foreach (Parameter parameter in client.RestClient.Parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.Append($"this.RestClient = new {client.RestClient.Type}(clientDiagnostics, pipeline, ");
                foreach (var parameter in client.RestClient.Parameters)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");

                writer.Line($"_clientDiagnostics = clientDiagnostics;");
                writer.Line($"_pipeline = pipeline;");
            }
            writer.Line();
        }

        private void WritePagingOperation(CodeWriter writer, PagingMethod pagingMethod, bool async)
        {
            var pageType = pagingMethod.ItemType;
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = pagingMethod.Method.Parameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            writer.Append($"public virtual {responseType} {CreateMethodName(pagingMethod.Name, async)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                var pageWrappedType = new CSharpType(typeof(Page<>), pageType);
                var funcType = async ? new CSharpType(typeof(Task<>), pageWrappedType) : pageWrappedType;
                var nullableInt = new CSharpType(typeof(int), true);

                var continuationTokenText = pagingMethod.NextLinkName != null ? $"response.Value.{pagingMethod.NextLinkName}" : "null";
                var asyncText = async ? "async" : string.Empty;
                var awaitText = async ? "await" : string.Empty;
                var configureAwaitText = async ? ".ConfigureAwait(false)" : string.Empty;
                using (writer.Scope($"{asyncText} {funcType} FirstPageFunc({nullableInt} pageSizeHint)"))
                {
                    WriteDiagnosticScope(writer, pagingMethod.Diagnostics, writer =>
                    {
                        writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                        foreach (Parameter parameter in parameters)
                        {
                            writer.Append($"{parameter.Name}, ");
                        }

                        writer.Line($"cancellationToken){configureAwaitText};");
                        writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                    });
                }

                var nextPageFunctionName = "null";
                if (pagingMethod.NextPageMethod != null)
                {
                    nextPageFunctionName = "NextPageFunc";
                    var nextPageParameters = pagingMethod.NextPageMethod.Parameters;
                    using (writer.Scope($"{asyncText} {funcType} {nextPageFunctionName}({typeof(string)} nextLink, {nullableInt} pageSizeHint)"))
                    {
                        WriteDiagnosticScope(writer, pagingMethod.Diagnostics, writer =>
                        {
                            writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(");
                            foreach (Parameter parameter in nextPageParameters)
                            {
                                writer.Append($"{parameter.Name}, ");
                            }
                            writer.Line($"cancellationToken){configureAwaitText};");
                            writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                        });
                    }
                }
                writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, {nextPageFunctionName});");
            }
            writer.Line();
        }

        private void WriteCreateOperationOperation(CodeWriter writer, LongRunningOperation lroMethod)
        {
            RestClientMethod originalMethod = lroMethod.OriginalMethod;
            CSharpType? responseBodyType = lroMethod.OriginalResponse.ResponseBody?.Type;
            CSharpType responseType = new CSharpType(typeof(Operation<>), responseBodyType ?? new CSharpType(typeof(Response)));
            Parameter[] parameters = lroMethod.CreateParameters;

            writer.WriteXmlDocumentationSummary(originalMethod.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.Append($"internal {responseType} {CreateCreateOperationName(lroMethod.Name)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Line($")");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                writer.Append($"return {typeof(ArmOperationHelpers)}.Create(");
                writer.Append($"_pipeline, _clientDiagnostics, originalResponse, {typeof(RequestMethod)}.{originalMethod.Request.HttpMethod.ToRequestMethodName()}, {lroMethod.Diagnostics.ScopeName:L}, {typeof(OperationFinalStateVia)}.{lroMethod.FinalStateVia}, createOriginalHttpMessage");

                if (responseBodyType != null)
                {
                    writer.Line($", ");
                    string responseVariable = "response";
                    if (lroMethod.OriginalResponse.ResponseBody is ObjectResponseBody objectResponseBody)
                    {
                        using (writer.Scope($"({responseVariable:D}, cancellationToken) =>", "{", "},"))
                        {
                            writer.WriteDeserializationForMethods(
                                objectResponseBody.Serialization,
                                async: false,
                                (w, v) => w.Line($"return {v};")
                                , responseVariable);
                        }

                        using (writer.Scope($"async ({responseVariable:D}, cancellationToken) =>", newLine: false))
                        {
                            writer.WriteDeserializationForMethods(
                                objectResponseBody.Serialization,
                                async: true,
                                (w, v) => w.Line($"return {v};")
                                , responseVariable);
                        }
                    }
                    else if (lroMethod.OriginalResponse.ResponseBody is StreamResponseBody)
                    {
                        //TODO: https://github.com/Azure/autorest.csharp/issues/523
                        throw new NotSupportedException("Binary is not supported as message (not response) is required for ExtractResponseContent() call.");
                    }
                }

                writer.Line($");");
            }
            writer.Line();
        }

        private void WriteDiagnosticScope(CodeWriter writer, Diagnostic diagnostic, CodeWriterDelegate inner)
        {
            var scopeVariable = new CodeWriterDeclaration("scope");

            writer.Line($"using var {scopeVariable:D} = _clientDiagnostics.CreateScope({diagnostic.ScopeName:L});");
            foreach (DiagnosticAttribute diagnosticScopeAttributes in diagnostic.Attributes)
            {
                writer.Append($"{scopeVariable}.AddAttribute({diagnosticScopeAttributes.Name:L},");
                writer.WriteReferenceOrConstant(diagnosticScopeAttributes.Value);
                writer.Line($");");
            }

            writer.Line($"{scopeVariable}.Start();");

            using (writer.Scope($"try"))
            {
                inner(writer);
            }

            using (writer.Scope($"catch ({typeof(Exception)} e)"))
            {
                writer.Line($"{scopeVariable}.Failed(e);");
                writer.Line($"throw;");
            }
        }

        private void WriteStartOperationOperation(CodeWriter writer, LongRunningOperation lroMethod, bool async)
        {
            RestClientMethod originalMethod = lroMethod.OriginalMethod;
            CSharpType responseType = new CSharpType(typeof(Operation<>), lroMethod.OriginalResponse.ResponseBody?.Type ?? typeof(Response));
            responseType = async ? new CSharpType(typeof(ValueTask<>), responseType) : responseType;
            Parameter[] parameters = originalMethod.Parameters;

            writer.WriteXmlDocumentationSummary(originalMethod.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            string asyncText = async ? "async " : string.Empty;
            writer.Append($"public virtual {asyncText}{responseType} {CreateStartOperationName(lroMethod.Name, async)}(");
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                WriteDiagnosticScope(writer, lroMethod.Diagnostics, writer =>
                {
                    string awaitText = async ? "await" : string.Empty;
                    string configureText = async ? ".ConfigureAwait(false)" : string.Empty;
                    writer.Append($"var originalResponse = {awaitText} RestClient.{CreateMethodName(originalMethod.Name, async)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.Line($"cancellationToken){configureText};");

                    writer.Append($"return {CreateCreateOperationName(lroMethod.Name)}(originalResponse, () => RestClient.{CreateRequestMethodName(originalMethod.Name)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Line($"));");
                });

            }
            writer.Line();
        }
    }
}
