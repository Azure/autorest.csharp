// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Response = Azure.Response;
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
            var cs = _typeFactory.CreateType(operationGroup);
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                using (writer.Class("internal", "static", operationGroup.Name))
                {
                    foreach (var method in operationGroup.Methods)
                    {
                        WriteOperation(writer, method, cs.Namespace);
                    }
                }
            }
            return true;
        }

        private void WriteOperation(CodeWriter writer, ClientMethod operation, CSharpNamespace? @namespace)
        {
            //TODO: Handle multiple responses
            var schemaResponse = operation.ResponseType;
            CSharpType? responseType = schemaResponse != null ? _typeFactory.CreateType(schemaResponse) : null;
            CSharpType returnType = schemaResponse != null && responseType != null
                ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response<>), responseType))
                : new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response)));

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
                writer.Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace?.FullName ?? "[NO NAMESPACE]"}.{methodName}\");");
                //TODO: Implement attribute logic
                //writer.Line("scope.AddAttribute(\"key\", name);");
                writer.Line("scope.Start();");

                using (writer.Try())
                {
                    writer.Line("var request = pipeline.CreateRequest();");
                    var method = operation.Request.Method;
                    writer.Line($"request.Method = {writer.Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");

                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end up with multiple // together
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

                    if (operation.Request.Body is ConstantOrParameter body)
                    {
                        var bufferWriter = new CSharpType(typeof(ArrayBufferWriter<>), new CSharpType(typeof(byte)));

                        writer.Line($"var buffer = new {writer.Type(bufferWriter)}();");
                        writer.Line($"await using var writer = new {writer.Type(typeof(Utf8JsonWriter))}(buffer);");

                        var type = body.IsConstant ? body.Constant.Type : body.Parameter.Type;
                        var name = body.IsConstant ? body.Constant.ToValueString() : body.Parameter.Name;
                        writer.ToSerializeCall(type, _typeFactory, name, string.Empty, false);

                        writer.Line("writer.Flush();");
                        writer.Line("request.Content = RequestContent.Create(buffer.WrittenMemory);");
                    }

                    writer.Line("var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);");
                    writer.Line("cancellationToken.ThrowIfCancellationRequested();");

                    if (schemaResponse != null && responseType != null)
                    {
                        WriteStatusCodeSwitch(writer, schemaResponse, responseType, operation);
                    }
                    else
                    {
                        writer.Line("return response;");
                    }
                }

                var exceptionParameter = writer.Pair(typeof(Exception), "e");
                using (writer.Catch(exceptionParameter))
                {
                    writer.Line("scope.Failed(e);");
                    writer.Line("throw;");
                }
            }
        }

        private void WriteConstant(CodeWriter writer, ClientConstant constant)
        {
            if (constant.Value == null)
            {
                writer.Literal(null);
                return;
            }

            switch (constant.Type)
            {
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(DateTime):
                    var dateTimeValue = (DateTime)constant.Value;
                    dateTimeValue = dateTimeValue.ToUniversalTime();

                    writer.Append("new ");
                    writer.Append(writer.Type(typeof(DateTime)));
                    writer.Append("(");
                    writer.Literal(dateTimeValue.Year);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Month);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Day);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Hour);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Minute);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Second);
                    writer.Comma();
                    writer.Literal(dateTimeValue.Millisecond);
                    writer.Comma();
                    writer.Append(writer.Type(typeof(DateTimeKind)));
                    writer.Append(".");
                    writer.Append(nameof(DateTimeKind.Utc));
                    writer.Append(")");
                    break;
                case FrameworkTypeReference _:
                    writer.Literal(constant.Value);
                    break;
                case BinaryTypeReference _:
                    var value = (byte[])constant.Value;
                    writer.Append("new byte[] {");
                    foreach (byte b in value)
                    {
                        writer.Literal(b);
                        writer.Comma();
                    }
                    writer.Append("}");
                    break;
                default:
                    throw new InvalidOperationException("Unknown constant type");
            }
        }

        private void WritePathSegment(CodeWriter writer, PathSegment segment)
        {
            var value = segment.Value;

            if (value.IsConstant)
            {
                writer.Append("request.Uri.AppendPath(");
                WriteConstant(writer, value.Constant);
                WriteSerializationFormat(writer, segment.Format);
                writer.Comma();
                writer.Literal(segment.Escape);
                writer.Line(");");
                return;
            }

            writer.Append("request.Uri.AppendPath(");
            writer.Append(value.Parameter.Name);
            WriteSerializationFormat(writer, segment.Format);
            writer.Comma();
            writer.Literal(segment.Escape);
            writer.Line(");");
        }

        private void WriteHeader(CodeWriter writer, RequestHeader header)
        {
            if (header.Value.IsConstant)
            {
                writer.Append("request.Headers.Add(");
                writer.Literal(header.Name);
                writer.Comma();
                WriteConstant(writer, header.Value.Constant);
                writer.Line(");");
                return;
            }

            var parameter = header.Value.Parameter;
            var type = _typeFactory.CreateType(parameter.Type);
            using (type.IsNullable ? writer.If($"{parameter.Name} != null") : default)
            {
                writer.Append("request.Headers.Add(");
                writer.Literal(header.Name);
                writer.Comma();
                writer.Append(parameter.Name);
                if (type.IsNullable && type.IsValueType)
                {
                    writer.Append(".Value");
                }

                WriteSerializationFormat(writer, header.Format);
                writer.Line(");");
            }
        }

        private void WriteSerializationFormat(CodeWriter writer, SerializationFormat format)
        {
            var formatSpecifier = format switch
            {
                SerializationFormat.DateTimeRFC1123 => "R",
                SerializationFormat.DateTimeISO8601 => "S",
                SerializationFormat.Date => "D",
                SerializationFormat.DateTimeUnix => "U",
                _ => null
            };

            if (formatSpecifier != null)
            {
                writer.Comma().Literal(formatSpecifier);
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
            if (value.IsConstant)
            {
                writer.Append("request.Uri.");
                writer.Append(method);
                writer.Append("(");
                writer.Literal(queryParameter.Name);
                writer.Comma();
                WriteConstant(writer, value.Constant);
                if (delimiter != null)
                {
                    writer.Comma();
                    writer.Literal(delimiter);
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Comma();
                writer.Literal(queryParameter.Escape);
                writer.Line(");");
                return;
            }

            var parameter = value.Parameter;
            var type = _typeFactory.CreateType(parameter.Type);
            using (parameter.Type.IsNullable ? writer.If($"{parameter.Name} != null") : default)
            {
                writer.Append("request.Uri.");
                writer.Append(method);
                writer.Append("(");
                writer.Literal(queryParameter.Name);
                writer.Comma();
                writer.Append(parameter.Name);
                if (type.IsNullable && type.IsValueType)
                {
                    writer.Append(".Value");
                }
                if (delimiter != null)
                {
                    writer.Comma();
                    writer.Literal(delimiter);
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Comma();
                writer.Literal(queryParameter.Escape);
                writer.Line(");");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, ClientTypeReference schemaResponse, CSharpType responseType, ClientMethod operation)
        {
            writer.Line($"using var document = await {writer.Type(typeof(JsonDocument))}.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");

            //TODO: Handle multiple exceptions
            //var schemaException = operation.Exceptions?.FirstOrDefault() as SchemaResponse;

            using (writer.Switch("response.Status"))
            {
                var statusCodes = operation.Request.SuccessfulStatusCodes;
                foreach (var statusCode in statusCodes)
                {
                    writer.Line($"case {statusCode}:");
                }

                writer.Append($"return {writer.Type(typeof(Response))}.FromValue(");
                writer.ToDeserializeCall(schemaResponse!, _typeFactory, "document.RootElement", writer.Type(responseType), responseType.Name ?? "[NO TYPE NAME]");
                writer.Line(", response);");
                writer.Line("default:");
                //TODO: Handle actual exception responses
                writer.Line($"throw new {writer.Type(typeof(Exception))}();");
            }
        }
    }
}
