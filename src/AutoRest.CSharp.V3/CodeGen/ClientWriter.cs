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
    internal class ClientWriter : StringWriter
    {
        private readonly TypeFactory _typeFactory;

        public ClientWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public bool WriteClient(ServiceClient operationGroup)
        {
            Header();
            using var _ = UsingStatements();
            var cs = _typeFactory.CreateType(operationGroup);
            var @namespace = cs.Namespace;
            using (Namespace(@namespace))
            {
                using (Class("internal", "static", operationGroup.Name))
                {
                    foreach (var method in operationGroup.Methods)
                    {
                        WriteOperation(method, cs.Namespace);
                    }
                }
            }
            return true;
        }

        private void WriteOperation(ClientMethod operation, CSharpNamespace? @namespace)
        {
            //TODO: Handle multiple responses
            var schemaResponse = operation.ResponseType;
            CSharpType? responseType = schemaResponse != null ? _typeFactory.CreateType(schemaResponse) : null;
            CSharpType returnType = schemaResponse != null && responseType != null
                ? new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response<>), responseType))
                : new CSharpType(typeof(ValueTask<>), new CSharpType(typeof(Response)));

            var parametersText = new[] { Pair(Type(typeof(ClientDiagnostics)), "clientDiagnostics"), Pair(typeof(HttpPipeline), "pipeline") }
                .Concat(operation.Parameters
                    .OrderBy(p => p.DefaultValue != null)
                    .Select(parameter =>
                    {
                        Debug.Assert(parameter != null);
                        var pair = Pair(_typeFactory.CreateInputType(parameter.Type), parameter.Name);
                        var shouldBeDefaulted = parameter.DefaultValue != null;
                        //TODO: This will only work if the parameter is a string parameter
                        return shouldBeDefaulted ? $"{pair} = {(parameter.DefaultValue != null ? $"\"{parameter.DefaultValue.Value.Value}\"" : "default")}" : pair;
                    }))
                .Append($"{Pair(typeof(CancellationToken), "cancellationToken")} = default").ToArray();

            var methodName = operation.Name;
            using (Method("public static async", Type(returnType), $"{methodName}Async", parametersText))
            {
                Line($"using var scope = clientDiagnostics.CreateScope(\"{@namespace?.FullName ?? "[NO NAMESPACE]"}.{methodName}\");");
                //TODO: Implement attribute logic
                //Line("scope.AddAttribute(\"key\", name);");
                Line("scope.Start();");

                using (Try())
                {
                    Line("var request = pipeline.CreateRequest();");
                    var method = operation.Request.Method;
                    Line($"request.Method = {Type(typeof(RequestMethod))}.{method.ToRequestMethodName()};");

                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end up with multiple // together
                    var urlText = String.Join(String.Empty, operation.Request.HostSegments.Select(s=> s.IsConstant ? s.Constant.Value :"{" + s.Parameter.Name + "}"));
                    Line($"request.Uri.Reset(new {Type(typeof(Uri))}($\"{urlText}\"));");

                    foreach (var segment in operation.Request.PathSegments)
                    {
                        WritePathSegment(segment);
                    }

                    foreach (var header in operation.Request.Headers)
                    {
                        WriteHeader(header);
                    }

                    //TODO: Duplicate code between query and header parameter processing logic
                    foreach (var queryParameter in operation.Request.Query)
                    {
                        WriteQueryParameter(queryParameter);
                    }


                    if (operation.Request.Body is ConstantOrParameter body)
                    {
                        var bufferWriter = new CSharpType(typeof(ArrayBufferWriter<>), new CSharpType(typeof(byte)));

                        Line($"var buffer = new {Type(bufferWriter)}();");
                        Line($"await using var writer = new {Type(typeof(Utf8JsonWriter))}(buffer);");

                        var type = body.IsConstant ? body.Constant.Type : body.Parameter.Type;
                        var name = body.IsConstant ? body.Constant.ToValueString() : body.Parameter.Name;
                        this.ToSerializeCall(type, _typeFactory, name, string.Empty, false);

                        Line("writer.Flush();");
                        Line("request.Content = RequestContent.Create(buffer.WrittenMemory);");
                    }

                    Line("var response = await pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);");
                    Line("cancellationToken.ThrowIfCancellationRequested();");

                    Action writeReturnText = schemaResponse != null && responseType != null
                        ? (Action)(() => WriteStatusCodeSwitch(schemaResponse, responseType, operation))
                        : () => Line("return response;");
                    writeReturnText();
                }

                var exceptionParameter = Pair(typeof(Exception), "e");
                using (Catch(exceptionParameter))
                {
                    Line("scope.Failed(e);");
                    Line("throw;");
                }
            }
        }

        private void WriteConstant(ClientConstant constant)
        {
            if (constant.Value == null)
            {
                Literal(null);
                return;
            }

            switch (constant.Type)
            {
                case FrameworkTypeReference frameworkType when frameworkType.Type == typeof(DateTime):
                    var dateTimeValue = (DateTime)constant.Value;
                    dateTimeValue = dateTimeValue.ToUniversalTime();

                    Append("new ");
                    Append(Type(typeof(DateTime)));
                    Append("(");
                    Literal(dateTimeValue.Year);
                    Append(", ");
                    Literal(dateTimeValue.Month);
                    Append(", ");
                    Literal(dateTimeValue.Day);
                    Append(", ");
                    Literal(dateTimeValue.Hour);
                    Append(", ");
                    Literal(dateTimeValue.Minute);
                    Append(", ");
                    Literal(dateTimeValue.Second);
                    Append(", ");
                    Literal(dateTimeValue.Millisecond);
                    Append(", ");
                    Append(Type(typeof(DateTimeKind)));
                    Append(".");
                    Append(nameof(DateTimeKind.Utc));
                    Append(")");
                    break;
                case FrameworkTypeReference _:
                    Literal(constant.Value);
                    break;
                case BinaryTypeReference _:
                    var value = (byte[])constant.Value;
                    Append("new byte[] {");
                    foreach (byte b in value)
                    {
                        Literal(b);
                        Append(", ");
                    }
                    Append("}");
                    break;
                default:
                    throw new InvalidOperationException("Unknown constant type");
            }
        }

        private void WritePathSegment(PathSegment segment)
        {
            var value = segment.Value;

            if (value.IsConstant)
            {
                Append("request.Uri.AppendPath(");
                WriteConstant(value.Constant);
                WriteSerializationFormat(segment.Format);
                Append(", ");
                Literal(segment.Escape);
                Line(");");
                return;
            }

            Append("request.Uri.AppendPath(");
            Append(value.Parameter.Name);
            WriteSerializationFormat(segment.Format);
            Append(", ");
            Literal(segment.Escape);
            Line(");");
        }

        private void WriteHeader(RequestHeader header)
        {
            if (header.Value.IsConstant)
            {
                Append("request.Headers.Add(");
                Literal(header.Name);
                Append(", ");
                WriteConstant(header.Value.Constant);
                Line(");");
                return;
            }

            var parameter = header.Value.Parameter;
            var type = _typeFactory.CreateType(parameter.Type);
            using (type.IsNullable ? If($"{parameter.Name} != null") : null)
            {
                Append("request.Headers.Add(");
                Literal(header.Name);
                Append(", ");
                Append(parameter.Name);
                if (type.IsNullable && type.IsValueType)
                {
                    Append(".Value");
                }

                WriteSerializationFormat(header.Format);
                Line(");");
            }
        }

        private void WriteSerializationFormat(SerializationFormat format)
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
                Append($", ");
                Literal(formatSpecifier);
            }
        }

        private void WriteQueryParameter(QueryParameter queryParameter)
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
                case QuerySerializationStyle.ComaDelimited:
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
                Append("request.Uri.");
                Append(method);
                Append("(");
                Literal(queryParameter.Name);
                Append(", ");
                WriteConstant(value.Constant);
                if (delimiter != null)
                {
                    Append(", ");
                    Literal(delimiter);
                }
                WriteSerializationFormat(queryParameter.SerializationFormat);
                Append(", ");
                Literal(queryParameter.Escape);
                Line(");");
                return;
            }

            var parameter = value.Parameter;
            var type = _typeFactory.CreateType(parameter.Type);
            using (parameter.Type.IsNullable ? If($"{parameter.Name} != null") : null)
            {
                Append("request.Uri.");
                Append(method);
                Append("(");
                Literal(queryParameter.Name);
                Append(", ");
                Append(parameter.Name);
                if (type.IsNullable && type.IsValueType)
                {
                    Append(".Value");
                }
                if (delimiter != null)
                {
                    Append(", ");
                    Literal(delimiter);
                }
                WriteSerializationFormat(queryParameter.SerializationFormat);
                Append(", ");
                Literal(queryParameter.Escape);
                Line(");");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(ClientTypeReference schemaResponse, CSharpType responseType, ClientMethod operation)
        {
            Line($"using var document = await {Type(typeof(JsonDocument))}.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);");

            //TODO: Handle multiple exceptions
            //var schemaException = operation.Exceptions?.FirstOrDefault() as SchemaResponse;

            using (Switch("response.Status"))
            {
                var statusCodes = operation.Request.SuccessfulStatusCodes;
                foreach (var statusCode in statusCodes)
                {
                    Line($"case {statusCode}:");
                }

                Append($"return {Type(typeof(Response))}.FromValue(");
                this.ToDeserializeCall(schemaResponse!, _typeFactory, "document.RootElement", Type(responseType), responseType.Name ?? "[NO TYPE NAME]");
                Line(", response);");
                Line("default:");
                //TODO: Handle actual exception responses
                Line($"throw new {Type(typeof(Exception))}();");
            }
        }
    }
}
