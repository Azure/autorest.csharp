// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ClientWriter
    {
        private readonly TypeFactory _typeFactory;

        public ClientWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public bool WriteClient(CodeWriter writer, ServiceClient operationGroup)
        {
            var cs = _typeFactory.CreateType(operationGroup.Name);
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                using (writer.Class("internal", "partial", cs.Name))
                {
                    WriteClientFields(writer, operationGroup);

                    WriteClientCtor(writer, operationGroup, cs);

                    foreach (var method in operationGroup.Methods)
                    {
                        WriteOperation(writer, method, cs.Namespace);
                    }
                }
            }

            return true;
        }

        private void WriteClientFields(CodeWriter writer, ServiceClient operationGroup)
        {
            foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
            {
                writer.Line($"private {_typeFactory.CreateType(clientParameter.Type)} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} clientDiagnostics;");
            writer.Line($"private {typeof(HttpPipeline)} pipeline;");
        }

        private void WriteClientCtor(CodeWriter writer, ServiceClient operationGroup, CSharpType cs)
        {
            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline,");
            foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
            {
                WriteParameter(writer, clientParameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, operationGroup.Parameters);

                foreach (ServiceClientParameter clientParameter in operationGroup.Parameters)
                {
                    writer.Line($"this.{clientParameter.Name} = {clientParameter.Name};");
                }

                writer.Line($"this.clientDiagnostics = clientDiagnostics;");
                writer.Line($"this.pipeline = pipeline;");
            }
        }

        private void WriteParameter(CodeWriter writer, ServiceClientParameter clientParameter)
        {
            writer.Append($"{_typeFactory.CreateInputType(clientParameter.Type)} {clientParameter.Name}");
            if (clientParameter.DefaultValue != null)
            {
                writer.Append($" = {clientParameter.DefaultValue.Value.Value:L}");
            }

            writer.AppendRaw(",");
        }

        private void WriteOperation(CodeWriter writer, ClientMethod operation, CSharpNamespace @namespace)
        {
            //TODO: Handle multiple responses
            var responseBody = operation.Response.ResponseBody;
            CSharpType? bodyType = responseBody != null ? _typeFactory.CreateType(responseBody.Type) : null;
            CSharpType? headerModelType = operation.Response.HeaderModel != null ? _typeFactory.CreateType(operation.Response.HeaderModel.Name) : null;

            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };

            CSharpType returnType = new CSharpType(typeof(ValueTask<>), responseType);

            var methodName = operation.Name;
            writer.Append($"public async {returnType} {methodName}Async(");
            foreach (ServiceClientParameter parameter in operation.Parameters)
            {
                WriteParameter(writer, parameter);
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, operation.Parameters);

                writer.Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace.FullName}.{methodName}\");");
                //TODO: Implement attribute logic
                //writer.Line("scope.AddAttribute(\"key\", name);");
                writer.Line($"scope.Start();");

                using (writer.Try())
                {
                    writer.Line($"using var message = pipeline.CreateMessage();");
                    writer.Line($"var request = message.Request;");
                    var method = operation.Request.Method;
                    writer.Line($"request.Method = {writer.Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");

                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end  up with multiple // together
                    var urlText = String.Join(String.Empty, operation.Request.HostSegments.Select(s => s.IsConstant ? s.Constant.Value : "{" + s.Parameter.Name + "}"));
                    writer.Line($"request.Uri.Reset(new {writer.Type(typeof(Uri))}($\"{urlText}\"));");

                    foreach (var segment in operation.Request.PathSegments)
                    {
                        WritePathSegment(writer, segment);
                    }

                    foreach (var header in operation.Request.Headers)
                    {
                        WriteHeader(writer, header);
                    }

                    //TODO: Duplicate code between query and header parameter processing logic
                    foreach (var queryParameter in operation.Request.Query)
                    {
                        WriteQueryParameter(writer, queryParameter);
                    }

                    if (operation.Request.Body is ObjectRequestBody body && body.Serialization is JsonSerialization jsonSerialization)
                    {
                        writer.Line($"using var content = new {typeof(Utf8JsonRequestContent)}();");

                        ConstantOrParameter value = body.Value;

                        writer.ToSerializeCall(
                            jsonSerialization,
                            _typeFactory,
                            w => WriteConstantOrParameter(w, value),
                            writerName: w => w.Append($"content.{nameof(Utf8JsonRequestContent.JsonWriter)}"));

                        writer.Line($"request.Content = content;");
                    }
                    else if (operation.Request.Body is ObjectRequestBody xmlBody && xmlBody.Serialization is XmlElementSerialization xmlSerialization)
                    {
                        writer.Line($"using var content = new {typeof(XmlWriterContent)}();");

                        ConstantOrParameter value = xmlBody.Value;

                        writer.ToSerializeCall(
                            xmlSerialization,
                            _typeFactory,
                            w => WriteConstantOrParameter(w, value),
                            writerName: w => w.Append($"content.{nameof(XmlWriterContent.XmlWriter)}"));

                        writer.Line($"request.Content = content;");
                    }

                    writer.Line($"await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);");

                    WriteStatusCodeSwitch(writer, responseBody, headerModelType, operation);
                }

                var exceptionParameter = writer.Pair(typeof(Exception), "e");
                using (writer.Catch(exceptionParameter))
                {
                    writer.Line($"scope.Failed(e);");
                    writer.Line($"throw;");
                }
            }
        }

        private void WriteConstantOrParameter(CodeWriter writer, ConstantOrParameter constantOrParameter)
        {
            if (constantOrParameter.IsConstant)
            {
                WriteConstant(writer, constantOrParameter.Constant);
            }
            else
            {
                writer.AppendRaw(constantOrParameter.Parameter.Name)
                    .AppendNullableValue(_typeFactory.CreateType(constantOrParameter.Type));
            }
        }

        private void WriteParameterNullChecks(CodeWriter writer, IEnumerable<ServiceClientParameter> parameters)
        {
            foreach (ServiceClientParameter parameter in parameters)
            {
                var cs = _typeFactory.CreateType(parameter.Type);
                if (parameter.IsRequired && (cs.IsNullable || !cs.IsValueType))
                {
                    using (writer.If($"{parameter.Name} == null"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name}));");
                    }
                }
            }
            writer.Line();
        }

        private void WriteConstant(CodeWriter writer, ClientConstant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({_typeFactory.CreateType(constant.Type)}){null:L}");
                return;
            }

            switch (constant.Type)
            {
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(DateTimeOffset):
                    var d = (DateTimeOffset)constant.Value;
                    d = d.ToUniversalTime();
                    writer.Append($"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})");
                    break;
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(byte[]):
                    var value = (byte[])constant.Value;
                    writer.Append($"new byte[] {{");
                    foreach (byte b in value)
                    {
                        writer.Append($"{b}, ");
                    }
                    writer.Append($"}}");
                    break;
                case FrameworkTypeReference _:
                    writer.Literal(constant.Value);
                    break;
                default:
                    throw new InvalidOperationException("Unknown constant type");
            }
        }

        private void WritePathSegment(CodeWriter writer, PathSegment segment)
        {
            writer.Append($"request.Uri.AppendPath(");
            WriteConstantOrParameter(writer, segment.Value);
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private void WriteHeader(CodeWriter writer, RequestHeader header)
        {
            using (WriteValueNullCheck(writer, header.Value))
            {
                writer.Append($"request.Headers.Add({header.Name:L}, ");
                WriteConstantOrParameter(writer, header.Value);
                WriteSerializationFormat(writer, header.Format);
                writer.Line($");");
            }
        }

        private CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, ConstantOrParameter value)
        {
            if (value.IsConstant)
                return default;

            var type = _typeFactory.CreateType(value.Type);
            if (type.IsNullable)
            {
                return writer.If($"{value.Parameter.Name} != null");
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
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "|";
                    break;
                case QuerySerializationStyle.TabDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = "\t";
                    break;
                case QuerySerializationStyle.SpaceDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = " ";
                    break;
                case QuerySerializationStyle.CommaDelimited:
                    method = nameof(UriBuilderExtensions.AppendQueryDelimited);
                    delimiter = ",";
                    break;

                default:
                    method = nameof(UriBuilderExtensions.AppendQuery);
                    break;
            }

            ConstantOrParameter value = queryParameter.Value;
            using (WriteValueNullCheck(writer, value))
            {
                writer.Append($"request.Uri.{method}({queryParameter.Name:L}, ");
                WriteConstantOrParameter(writer, value);
                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Line($", {queryParameter.Escape:L});");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, ResponseBody? responseBody, CSharpType? headersModelType, ClientMethod operation)
        {
            using (writer.Switch("message.Response.Status"))
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
                                writer.Line($"using var {document:D} = await {writer.Type(typeof(JsonDocument))}.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                                writer.ToDeserializeCall(
                                    jsonSerialization,
                                    _typeFactory,
                                    w => w.Append($"document.RootElement"),
                                    ref valueVariable
                                );
                                break;
                            case XmlElementSerialization xmlSerialization:
                                writer.Line($"var {document:D} = {typeof(XDocument)}.Load(message.Response.ContentStream, LoadOptions.PreserveWhitespace);");
                                writer.ToDeserializeCall(
                                    xmlSerialization,
                                    _typeFactory,
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
                        case null:
                            writer.Append($"return message.Response;");
                            break;
                    }
                }

                writer.Line($"default:");
                writer.Line($"throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);");
            }
        }
    }
}
