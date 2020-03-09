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
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private void WriteRequestCreation(CodeWriter writer, RestClientMethod operation)
        {
            var methodName = CreateRequestMethodName(operation.Name);
            writer.Append($"internal {typeof(HttpMessage)} {methodName}(");
            var parameters = operation.Parameters;
            foreach (Parameter clientParameter in parameters)
            {
                writer.Append($"{clientParameter.Type} {clientParameter.Name},");
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.Line($"var message = pipeline.CreateMessage();");
                writer.Line($"var request = message.Request;");
                var method = operation.Request.HttpMethod;
                writer.Line($"request.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end  up with multiple // together

                writer.Line($"var uri = new RawRequestUriBuilder();");
                foreach (var segment in operation.Request.HostSegments)
                {
                    WriteUriFragment(writer, segment);
                }
                writer.RemoveTrailingComma();

                foreach (var segment in operation.Request.PathSegments)
                {
                    WritePathSegment(writer, segment);
                }

                //TODO: Duplicate code between query and header parameter processing logic
                foreach (var queryParameter in operation.Request.Query)
                {
                    WriteQueryParameter(writer, queryParameter);
                }

                writer.Line($"request.Uri = uri;");

                foreach (var header in operation.Request.Headers)
                {
                    WriteHeader(writer, header);
                }

                if (operation.Request.Body is RequestBody body && body.Serialization is JsonSerialization jsonSerialization)
                {
                    writer.Line($"using var content = new {typeof(Utf8JsonRequestContent)}();");

                    ParameterOrConstant value = body.Value;

                    writer.ToSerializeCall(
                        jsonSerialization,
                        WriteConstantOrParameter(value, ignoreNullability: true),
                        writerName: w => w.Append($"content.{nameof(Utf8JsonRequestContent.JsonWriter)}"));

                    writer.Line($"request.Content = content;");
                }
                else if (operation.Request.Body is RequestBody xmlBody && xmlBody.Serialization is XmlElementSerialization xmlSerialization)
                {
                    writer.Line($"using var content = new {typeof(XmlWriterContent)}();");

                    ParameterOrConstant value = xmlBody.Value;

                    writer.ToSerializeCall(
                        xmlSerialization,
                        WriteConstantOrParameter(value, ignoreNullability: true),
                        writerName: w => w.Append($"content.{nameof(XmlWriterContent.XmlWriter)}"));

                    writer.Line($"request.Content = content;");
                }

                writer.Line($"return message;");
            }
        }

        private void WriteUriFragment(CodeWriter writer, PathSegment segment)
        {
            writer.Append($"uri.AppendRaw({WriteConstantOrParameter(segment.Value)}");
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteOperation(CodeWriter writer, RestClientMethod operation, bool async)
        {
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

                writer.Line($"using var scope = clientDiagnostics.CreateScope({operation.Diagnostics.ScopeName:L});");
                foreach (DiagnosticAttribute diagnosticScopeAttributes in operation.Diagnostics.Attributes)
                {
                    writer.Line($"scope.AddAttribute({diagnosticScopeAttributes.Name:L}, {WriteConstantOrParameter(diagnosticScopeAttributes.Value)};");
                }
                writer.Line($"scope.Start();");

                using (writer.Scope($"try"))
                {
                    var requestMethodName = CreateRequestMethodName(operation.Name);
                    writer.Append($"using var message = {requestMethodName}(");

                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.Line($");");

                    if (async)
                    {
                        writer.Line($"await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);");
                    }
                    else
                    {
                        writer.Line($"pipeline.Send(message, cancellationToken);");
                    }

                    WriteStatusCodeSwitch(writer, responseBody, headerModelType, operation, async);
                }

                using (writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    writer.Line($"scope.Failed(e);");
                    writer.Line($"throw;");
                }
            }
        }

        private CodeWriterDelegate WriteConstantOrParameter(ParameterOrConstant constantOrParameter, bool ignoreNullability = false) => writer =>
        {
            if (constantOrParameter.IsConstant)
            {
                WriteConstant(writer, constantOrParameter.Constant);
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

        private void WriteConstant(CodeWriter writer, Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({constant.Type}){null:L}");
                return;
            }

            Type? frameworkType = constant.Type.FrameworkType;

            if (frameworkType == typeof(DateTimeOffset))
            {
                var d = (DateTimeOffset) constant.Value;
                d = d.ToUniversalTime();
                writer.Append($"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})");
            }
            else if (frameworkType == typeof(byte[]))
            {
                var value = (byte[]) constant.Value;
                writer.Append($"new byte[] {{");
                foreach (byte b in value)
                {
                    writer.Append($"{b}, ");
                }

                writer.Append($"}}");
            }
            else if (frameworkType != null)
            {
                writer.Literal(constant.Value);
            }
            else
            {
                throw new InvalidOperationException("Unknown constant type");
            }
        }

        private void WritePathSegment(CodeWriter writer, PathSegment segment)
        {
            writer.Append($"uri.AppendPath({WriteConstantOrParameter(segment.Value)}");
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteHeader(CodeWriter writer, RequestHeader header)
        {
            using (WriteValueNullCheck(writer, header.Value))
            {
                writer.Append($"request.Headers.Add({header.Name:L}, {WriteConstantOrParameter(header.Value)}");
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

        private void WriteQueryParameter(CodeWriter writer, QueryParameter queryParameter)
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
                writer.Append($"uri.{method}({queryParameter.Name:L}, {WriteConstantOrParameter(value)}");

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
        private void WriteStatusCodeSwitch(CodeWriter writer, ResponseBody? responseBody, CSharpType? headersModelType, RestClientMethod operation, bool async)
        {
            using (writer.Scope($"switch (message.Response.Status)"))
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
                        const string document = "document";
                        switch (objectResponseBody.Serialization)
                        {
                            case JsonSerialization jsonSerialization:
                                writer.Append($"using var {document:D} = ");
                                if (async)
                                {
                                    writer.Line($"await {typeof(JsonDocument)}.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                                }
                                else
                                {
                                    writer.Line($"{typeof(JsonDocument)}.Parse(message.Response.ContentStream);");
                                }

                                writer.ToDeserializeCall(
                                    jsonSerialization,
                                    w => w.Append($"document.RootElement"),
                                    ref valueVariable
                                );
                                break;
                            case XmlElementSerialization xmlSerialization:
                                writer.Line($"var {document:D} = {typeof(XDocument)}.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);");
                                writer.ToDeserializeCall(
                                    xmlSerialization,
                                    w => w.Append($"document"),
                                    ref valueVariable
                                );
                                break;
                        }
                    }
                    else if (responseBody is StreamResponseBody _)
                    {
                        writer.Line($"var {valueVariable:D} = message.ExtractResponseContent();");
                    }

                    if (headersModelType != null)
                    {
                        writer.Line($"var headers = new {headersModelType}(message.Response);");
                    }

                    switch (responseBody)
                    {
                        case null when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue(headers, message.Response);");
                            break;
                        case { } when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue({valueVariable}, headers, message.Response);");
                            break;
                        case { }:
                            writer.Append($"return {typeof(Response)}.FromValue({valueVariable}, message.Response);");
                            break;
                        case null when !statusCodes.Any():
                            break;
                        case null:
                            writer.Append($"return message.Response;");
                            break;
                    }
                }

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw clientDiagnostics.CreateRequestFailedException(message.Response);");
                }
            }
        }
    }
}
