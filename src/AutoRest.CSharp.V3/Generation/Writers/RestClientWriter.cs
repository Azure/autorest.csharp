// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
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
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class RestClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient restClient)
        {
            var cs = restClient.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(restClient.Description);
                using (writer.Scope($"{restClient.DeclaredType.Accessibility} partial class {cs.Name}"))
                {
                    WriteClientFields(writer, restClient);

                    WriteClientCtor(writer, restClient, cs);

                    foreach (var method in restClient.Methods)
                    {
                        WriteRequestCreation(writer, method);
                        WriteOperation(writer, method, true);
                        WriteOperation(writer, method, false);
                    }
                }
            }
        }

        private void WriteClientFields(CodeWriter writer, RestClient restClient)
        {
            foreach (Parameter clientParameter in restClient.Parameters)
            {
                writer.Line($"private {clientParameter.Type} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} clientDiagnostics;");
            writer.Line($"private {typeof(HttpPipeline)} pipeline;");
            writer.Line();
        }

        private void WriteClientCtor(CodeWriter writer, RestClient restClient, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline,");
            foreach (Parameter clientParameter in restClient.Parameters)
            {
                writer.WriteParameter(clientParameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(restClient.Parameters);

                foreach (Parameter clientParameter in restClient.Parameters)
                {
                    writer.Line($"this.{clientParameter.Name} = {clientParameter.Name};");
                }

                writer.Line($"this.clientDiagnostics = clientDiagnostics;");
                writer.Line($"this.pipeline = pipeline;");
            }
            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private void WriteRequestCreation(CodeWriter writer, RestClientMethod operation)
        {
            using var methodScope = writer.AmbientScope();

            var methodName = CreateRequestMethodName(operation.Name);
            writer.Append($"internal {typeof(HttpMessage)} {methodName}(");
            var parameters = operation.Parameters;
            foreach (Parameter clientParameter in parameters)
            {
                writer.Append($"{clientParameter.Type} {clientParameter.Name:D},");
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                var message = new CodeWriterDeclaration("message");
                var request = new CodeWriterDeclaration("request");
                var uri = new CodeWriterDeclaration("uri");

                writer.Line($"var {message:D} = pipeline.CreateMessage();");
                writer.Line($"var {request:D} = {message}.Request;");
                var method = operation.Request.HttpMethod;
                writer.Line($"{request}.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end  up with multiple // together

                writer.Line($"var {uri:D} = new RawRequestUriBuilder();");
                foreach (var segment in operation.Request.HostSegments)
                {
                    WriteUriFragment(writer, uri, segment);
                }
                writer.RemoveTrailingComma();

                foreach (var segment in operation.Request.PathSegments)
                {
                    WritePathSegment(writer, uri, segment);
                }

                //TODO: Duplicate code between query and header parameter processing logic
                foreach (var queryParameter in operation.Request.Query)
                {
                    WriteQueryParameter(writer, uri, queryParameter);
                }

                writer.Line($"{request}.Uri = {uri};");

                foreach (var header in operation.Request.Headers)
                {
                    WriteHeader(writer, request, header);
                }

                if (operation.Request.Body is SchemaRequestBody body)
                {
                    ParameterOrConstant value = body.Value;
                    switch (body.Serialization)
                    {
                        case JsonSerialization jsonSerialization:
                        {
                            var content = new CodeWriterDeclaration("content");

                            writer.Line($"using var {content:D} = new {typeof(Utf8JsonRequestContent)}();");
                            writer.ToSerializeCall(
                                jsonSerialization,
                                WriteConstantOrParameter(value, ignoreNullability: true),
                                writerName: w => w.Append($"{content}.{nameof(Utf8JsonRequestContent.JsonWriter)}"));
                            writer.Line($"{request}.Content = {content};");
                            break;
                        }
                        case XmlElementSerialization xmlSerialization:
                        {
                            var content = new CodeWriterDeclaration("content");

                            writer.Line($"using var {content:D} = new {typeof(XmlWriterContent)}();");
                            writer.ToSerializeCall(
                                xmlSerialization,
                                WriteConstantOrParameter(value, ignoreNullability: true),
                                writerName: w => w.Append($"{content}.{nameof(XmlWriterContent.XmlWriter)}"));
                            writer.Line($"{request}.Content = {content};");
                            break;
                        }
                        default:
                            throw new NotImplementedException(body.Serialization.ToString());
                    }
                }
                else if (operation.Request.Body is BinaryRequestBody binaryBody)
                {
                    writer.Line($"{request}.Content = {typeof(RequestContent)}.Create({WriteConstantOrParameter(binaryBody.Value, ignoreNullability: true)});");
                }

                writer.Line($"return {message};");
            }
            writer.Line();
        }

        private void WriteUriFragment(CodeWriter writer, CodeWriterDeclaration uri, PathSegment segment)
        {
            writer.Append($"{uri}.AppendRaw({WriteConstantOrParameter(segment.Value)}");
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteOperation(CodeWriter writer, RestClientMethod operation, bool async)
        {
            using var methodScope = writer.AmbientScope();

            //TODO: Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413
            var responseBody = operation.Response.ResponseBody;
            CSharpType? bodyType = responseBody?.Type;
            CSharpType? headerModelType = operation.Response.HeaderModel?.Type;
            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };
            responseType = async ? new CSharpType(typeof(ValueTask<>), responseType) : responseType;
            var parameters = operation.Parameters;
            writer.WriteXmlDocumentationSummary(operation.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = CreateMethodName(operation.Name, async);
            var asyncText = async ? "async" : string.Empty;
            writer.Append($"public {asyncText} {responseType} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                writer.WriteParameterNullChecks(parameters);

                var scopeVariable = new CodeWriterDeclaration("scope");
                writer.Line($"using var {scopeVariable:D} = clientDiagnostics.CreateScope({operation.Diagnostics.ScopeName:L});");
                foreach (DiagnosticAttribute diagnosticScopeAttributes in operation.Diagnostics.Attributes)
                {
                    writer.Line($"{scopeVariable}.AddAttribute({diagnosticScopeAttributes.Name:L}, {WriteConstantOrParameter(diagnosticScopeAttributes.Value)};");
                }
                writer.Line($"{scopeVariable}.Start();");

                using (writer.Scope($"try"))
                {
                    var messageVariable = new CodeWriterDeclaration("message");
                    var requestMethodName = CreateRequestMethodName(operation.Name);
                    writer.Append($"using var {messageVariable:D} = {requestMethodName}(");

                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.Line($");");

                    if (async)
                    {
                        writer.Line($"await pipeline.SendAsync({messageVariable}, cancellationToken).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"pipeline.Send({messageVariable}, cancellationToken);");
                    }

                    WriteStatusCodeSwitch(writer, messageVariable, responseBody, headerModelType, operation, async);
                }

                using (writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    writer.Line($"{scopeVariable}.Failed(e);");
                    writer.Line($"throw;");
                }
            }
            writer.Line();
        }

        private CodeWriterDelegate WriteConstantOrParameter(ParameterOrConstant constantOrParameter, bool ignoreNullability = false) => writer =>
        {
            if (constantOrParameter.IsConstant)
            {
                writer.WriteConstant(constantOrParameter.Constant);
            }
            else
            {
                writer.AppendRaw(constantOrParameter.Parameter.Name);
                if (!ignoreNullability)
                {
                    writer.AppendNullableValue(constantOrParameter.Type);
                }
            }
        };

        private void WritePathSegment(CodeWriter writer, CodeWriterDeclaration uri, PathSegment segment)
        {
            writer.Append($"{uri}.AppendPath({WriteConstantOrParameter(segment.Value)}");
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteHeader(CodeWriter writer, CodeWriterDeclaration request, RequestHeader header)
        {
            using (WriteValueNullCheck(writer, header.Value))
            {
                writer.Append($"{request}.Headers.Add({header.Name:L}, {WriteConstantOrParameter(header.Value)}");
                WriteSerializationFormat(writer, header.Format);
                writer.Line($");");
            }
        }

        private CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, ParameterOrConstant value)
        {
            if (value.IsConstant)
                return default;

            var type = value.Type;
            if (type.IsNullable)
            {
                return writer.Scope($"if ({value.Parameter.Name} != null)");
            }

            return default;
        }

        private void WriteSerializationFormat(CodeWriter writer, SerializationFormat format)
        {
            if (format == SerializationFormat.Bytes_Base64Url)
            {
                // base64url is the only options for paths ns queries
                return;
            }

            var formatSpecifier = format.ToFormatSpecifier();
            if (formatSpecifier != null)
            {
                writer.Append($", {formatSpecifier:L}");
            }
        }

        private void WriteQueryParameter(CodeWriter writer, CodeWriterDeclaration uri, QueryParameter queryParameter)
        {
            string method;
            string? delimiter = null;
            switch (queryParameter.SerializationStyle)
            {
                case QuerySerializationStyle.PipeDelimited:
                    method = nameof(RequestUriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "|";
                    break;
                case QuerySerializationStyle.TabDelimited:
                    method = nameof(RequestUriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "\t";
                    break;
                case QuerySerializationStyle.SpaceDelimited:
                    method = nameof(RequestUriBuilderExtensions.AppendQueryDelimited);
                    delimiter = " ";
                    break;
                case QuerySerializationStyle.CommaDelimited:
                    method = nameof(RequestUriBuilderExtensions.AppendQueryDelimited);
                    delimiter = ",";
                    break;
                default:
                    method = nameof(RequestUriBuilderExtensions.AppendQuery);
                    break;
            }

            ParameterOrConstant value = queryParameter.Value;
            using (WriteValueNullCheck(writer, value))
            {
                writer.Append($"{uri}.{method}({queryParameter.Name:L}, {WriteConstantOrParameter(value)}");

                // TODO: Hack to support extensible enums in query. https://github.com/Azure/autorest.csharp/issues/325
                var type = value.Type;
                if (!type.IsFrameworkType && type.Implementation is EnumType enumType && enumType.IsStringBased)
                {
                    writer.Append($".ToString()");
                }

                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Line($", {queryParameter.Escape:L});");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, CodeWriterDeclaration message, ResponseBody? responseBody, CSharpType? headersModelType, RestClientMethod operation, bool async)
        {
            string responseVariable = $"{message.ActualName}.Response";
            using (writer.Scope($"switch ({responseVariable}.Status)"))
            {
                var statusCodes = operation.Response.SuccessfulStatusCodes;
                foreach (var statusCode in statusCodes)
                {
                    writer.Line($"case {statusCode}:");
                }

                using (responseBody != null ? writer.Scope() : default)
                {
                    string valueVariable = "value";
                    if (responseBody is ObjectResponseBody objectResponseBody)
                    {
                        writer.WriteDeserializationForMethods(objectResponseBody.Serialization, async, ref valueVariable, responseVariable);
                    }
                    else if (responseBody is StreamResponseBody _)
                    {
                        writer.Line($"var {valueVariable:D} = {message}.ExtractResponseContent();");
                    }

                    if (headersModelType != null)
                    {
                        writer.Line($"var headers = new {headersModelType}({responseVariable});");
                    }

                    switch (responseBody)
                    {
                        case null when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue(headers, {responseVariable});");
                            break;
                        case { } when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue({valueVariable}, headers, {responseVariable});");
                            break;
                        case { }:
                            writer.Append($"return {typeof(Response)}.FromValue({valueVariable}, {responseVariable});");
                            break;
                        case null when !statusCodes.Any():
                            break;
                        case null:
                            writer.Append($"return {responseVariable};");
                            break;
                    }
                }

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await clientDiagnostics.CreateRequestFailedExceptionAsync({responseVariable}).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw clientDiagnostics.CreateRequestFailedException({responseVariable});");
                }
            }
        }
    }
}
