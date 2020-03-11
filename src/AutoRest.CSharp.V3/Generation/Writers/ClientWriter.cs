// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
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
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class ClientWriter
    {
        public void WriteClient(CodeWriter writer, Client client)
        {
            var cs = client.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(client.Description);
                using (writer.Scope($"{client.DeclaredType.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, client);
                    WriteClientCtors(writer, client);

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

                    foreach (var longRunningOperation in client.LongRunningOperationMethods)
                    {
                        WriteCreateOperationOperation(writer, longRunningOperation);
                        WriteStartOperationOperation(writer, longRunningOperation, true);
                        WriteStartOperationOperation(writer, longRunningOperation, false);
                    }
                }
            }
        }

        private void WriteClientMethod(CodeWriter writer, ClientMethod clientMethod, bool async)
        {
            var responseBody = clientMethod.RestClientMethod.Response.ResponseBody;
            CSharpType? bodyType = responseBody?.Type;
            CSharpType responseType = bodyType != null ?
                new CSharpType(typeof(Response<>), bodyType) :
                new CSharpType(typeof(Response));

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
                writer.Append($"return (");
                if (async)
                {
                    writer.Append($"await ");
                }

                writer.Append($"RestClient.{CreateMethodName(clientMethod.RestClientMethod.Name, async)}(");
                foreach (var parameter in clientMethod.RestClientMethod.Parameters)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                writer.Append($"cancellationToken)");

                if (async)
                {
                    writer.Append($".ConfigureAwait(false)");
                }

                writer.Append($")");

                if (bodyType == null && clientMethod.RestClientMethod.Response.HeaderModel != null)
                {
                    writer.Append($".GetRawResponse()");
                }

                writer.Line($";");
            }
        }

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private string CreateCreateOperationName(string name) => $"Create{name}";

        private string CreateStartOperationName(string name, bool async) => $"Start{name}{(async ? "Async" : string.Empty)}";

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private void WriteClientFields(CodeWriter writer, Client client)
        {
            writer.Line($"private readonly {typeof(ClientDiagnostics)} clientDiagnostics;");
            writer.Line($"private readonly {typeof(HttpPipeline)} pipeline;");
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

                writer.Line($"this.clientDiagnostics = clientDiagnostics;");
                writer.Line($"this.pipeline = pipeline;");
            }
        }

        private void WritePagingOperation(CodeWriter writer, PagingInfo pagingMethod, bool async)
        {
            var pageType = pagingMethod.ItemType;
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = pagingMethod.Method.Parameters;
            var nextPageParameters = pagingMethod.NextPageMethod.Parameters;

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
                    writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.Method.Name, async)}(");
                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.Line($"cancellationToken){configureAwaitText};");
                    writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                }

                using (writer.Scope($"{asyncText} {funcType} NextPageFunc({typeof(string)} nextLink, {nullableInt} pageSizeHint)"))
                {
                    writer.Append($"var response = {awaitText} RestClient.{CreateMethodName(pagingMethod.NextPageMethod.Name, async)}(");
                    foreach (Parameter parameter in nextPageParameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                    writer.Line($"cancellationToken){configureAwaitText};");
                    writer.Line($"return {typeof(Page)}.FromValues(response.Value.{pagingMethod.ItemName}, {continuationTokenText}, response.GetRawResponse());");
                }
                writer.Line($"return {typeof(PageableHelpers)}.Create{(async ? "Async" : string.Empty)}Enumerable(FirstPageFunc, NextPageFunc);");
            }
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
                writer.Append($"pipeline, clientDiagnostics, originalResponse, {typeof(RequestMethod)}.{originalMethod.Request.HttpMethod.ToRequestMethodName()}, {originalMethod.Diagnostics.ScopeName:L}, {typeof(OperationFinalStateVia)}.{lroMethod.FinalStateVia}, createOriginalHttpMessage");

                if (responseBodyType != null)
                {
                    writer.Line($", ");
                    string valueVariable = "value";
                    const string document = "document";
                    ObjectSerialization? serialization = (lroMethod.OriginalResponse.ResponseBody as ObjectResponseBody)?.Serialization;
                    using (writer.Scope($"(response, cancellationToken) =>", "{", "},"))
                    {
                        switch (serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                writer.Append($"using var {document:D} = ");
                                writer.Line($"{typeof(JsonDocument)}.Parse(response.ContentStream);");
                                writer.ToDeserializeCall(
                                    jsonSerialization,
                                    w => w.Append($"document.RootElement"),
                                    ref valueVariable
                                );
                                writer.Line($"return {valueVariable};");
                                break;
                            case XmlElementSerialization xmlSerialization:
                                writer.Line($"var {document:D} = {typeof(XDocument)}.Load(response.ContentStream, LoadOptions.PreserveWhitespace);");
                                writer.ToDeserializeCall(
                                    xmlSerialization,
                                    w => w.Append($"document"),
                                    ref valueVariable
                                );
                                writer.Line($"return {valueVariable};");
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                    }

                    using (writer.Scope($"async (response, cancellationToken) =>", newLine: false))
                    {
                        switch (serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                writer.Append($"using var {document:D} = ");
                                writer.Line($"await {typeof(JsonDocument)}.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                                writer.ToDeserializeCall(
                                    jsonSerialization,
                                    w => w.Append($"document.RootElement"),
                                    ref valueVariable
                                );
                                writer.Line($"return {valueVariable};");
                                break;
                            case XmlElementSerialization xmlSerialization:
                                writer.Line($"var {document:D} = {typeof(XDocument)}.Load(response.ContentStream, LoadOptions.PreserveWhitespace);");
                                writer.ToDeserializeCall(
                                    xmlSerialization,
                                    w => w.Append($"document"),
                                    ref valueVariable
                                );
                                writer.Line($"return {valueVariable};");
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                    }
                }

                writer.Line($");");
            }
        }

        private void WriteStartOperationOperation(CodeWriter writer, LongRunningOperation lroMethod, bool async)
        {
            RestClientMethod originalMethod = lroMethod.OriginalMethod;
            CSharpType responseType = new CSharpType(typeof(Operation<>), lroMethod.OriginalResponse.ResponseBody?.Type ?? new CSharpType(typeof(Response)));
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
            }
        }
    }
}