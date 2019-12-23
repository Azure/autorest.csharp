﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using YamlDotNet.Serialization;
using SerializationFormat = AutoRest.CSharp.V3.ClientModels.SerializationFormat;

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
                using (writer.Class("internal", "static", cs.Name))
                {
                    foreach (var method in operationGroup.Methods)
                    {
                        WriteOperation(writer, method, cs.Namespace);
                    }
                }
            }
            return true;
        }

        private void WriteOperation(CodeWriter writer, ClientMethod operation, CSharpNamespace @namespace)
        {
            //TODO: Handle multiple responses
            var responseBody = operation.Response.ResponseBody;
            CSharpType? bodyType = responseBody != null ? _typeFactory.CreateType(responseBody.Value) : null;
            CSharpType? headerModelType = operation.Response.HeaderModel != null ? _typeFactory.CreateType(operation.Response.HeaderModel.Name) : null;

            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };

            CSharpType returnType = new CSharpType(typeof(ValueTask<>), responseType);

            var parametersText = new[] { writer.Pair(writer.Type(typeof(ClientDiagnostics)), "clientDiagnostics"), writer.Pair(typeof(HttpPipeline), "pipeline") }
                .Concat(operation.Parameters
                    .OrderBy(p => p.DefaultValue != null)
                    .Select(parameter =>
                    {
                        Debug.Assert(parameter != null);
                        var pair = writer.Pair(_typeFactory.CreateInputType(parameter.Type), parameter.Name);
                        var shouldBeDefaulted = parameter.DefaultValue != null;
                        //TODO: This will only work if the parameter is a string parameter
                        return shouldBeDefaulted ? $"{pair} = {(parameter.DefaultValue != null ? $"\"{parameter.DefaultValue.Value.Value}\"" : "default")}" : pair;
                    }))
                .Append($"{writer.Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

            var methodName = operation.Name;
            using (writer.Method("public static async", writer.Type(returnType), $"{methodName}Async", parametersText))
            {
                WriteParameterNullChecks(writer, operation);

                writer.Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace.FullName}.{methodName}\");");
                //TODO: Implement attribute logic
                //writer.Line("scope.AddAttribute(\"key\", name);");
                writer.Line($"scope.Start();");

                using (writer.Try())
                {
                    writer.Line($"var request = pipeline.CreateRequest();");
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

                    if (operation.Request.Body is RequestBody body)
                    {
                        writer.Line($"using var content = new {writer.Type(typeof(Utf8JsonRequestContent))}();");

                        ConstantOrParameter value = body.Value;

                        writer.ToSerializeCall(
                            body.Serialization,
                            _typeFactory,
                            w => WriteConstantOrParameter(w, value),
                            writerName: w => w.Append($"content.{nameof(Utf8JsonRequestContent.JsonWriter)}"));

                        writer.Line($"request.Content = content;");
                    }

                    writer.Line($"var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);");

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

        private void WriteParameterNullChecks(CodeWriter writer, ClientMethod operation)
        {
            foreach (ServiceClientMethodParameter parameter in operation.Parameters)
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
            using (writer.Switch("response.Status"))
            {
                var statusCodes = operation.Response.SuccessfulStatusCodes;
                foreach (var statusCode in statusCodes)
                {
                    writer.Line($"case {statusCode}:");
                }

                using (responseBody != null ? writer.Scope() : default)
                {
                    string valueVariable = "value";

                    if (responseBody != null)
                    {
                        writer.Line($"using var document = await {writer.Type(typeof(JsonDocument))}.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                        writer.ToDeserializeCall(
                            responseBody.Serialization,
                            _typeFactory,
                            w => w.Append($"document.RootElement"),
                            ref valueVariable
                        );
                    }

                    if (headersModelType != null)
                    {
                        writer.Line($"var headers = new {headersModelType}(response);");
                    }

                    switch (responseBody)
                    {
                        case null when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue(headers, response);");
                            break;
                        case { } when headersModelType != null:
                            writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue({valueVariable}, headers, response);");
                            break;
                        case { }:
                            writer.Append($"return {typeof(Response)}.FromValue({valueVariable}, response);");
                            break;
                        case null:
                            writer.Append($"return response;");
                            break;
                    }
                }


                writer.Line($"default:");
                //TODO: Handle actual exception responses
                writer.Line($"throw new {typeof(Exception)}();");
            }
        }
    }
}
