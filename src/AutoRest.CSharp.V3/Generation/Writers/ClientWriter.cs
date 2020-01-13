// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Parameter = AutoRest.CSharp.V3.ClientModels.Parameter;
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

        public void WriteClient(CodeWriter writer, Client operationGroup)
        {
            var cs = _typeFactory.CreateType(operationGroup.Name);
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(operationGroup.Description);
                using (writer.Class("internal", "partial", cs.Name))
                {
                    WriteClientFields(writer, operationGroup);

                    WriteClientCtor(writer, operationGroup, cs);

                    foreach (var method in operationGroup.Methods)
                    {
                        WriteRequestCreation(writer, method);
                        WriteOperation(writer, method, async: true);
                        WriteOperation(writer, method, async: false);
                        if (method.Paging != null)
                        {
                            WriteRequestCreation(writer, method, true);
                            WriteOperation(writer, method, true, true);
                            WritePagingOperation(writer, method, true);
                        }
                    }
                }
            }
        }

        private void WriteClientFields(CodeWriter writer, Client operationGroup)
        {
            foreach (Parameter clientParameter in operationGroup.Parameters)
            {
                writer.Line($"private {_typeFactory.CreateType(clientParameter.Type)} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} clientDiagnostics;");
            writer.Line($"private {typeof(HttpPipeline)} pipeline;");
        }

        private void WriteClientCtor(CodeWriter writer, Client operationGroup, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline,");
            foreach (Parameter clientParameter in operationGroup.Parameters)
            {
                WriteParameter(writer, clientParameter);
            }

            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, operationGroup.Parameters);

                foreach (Parameter clientParameter in operationGroup.Parameters)
                {
                    writer.Line($"this.{clientParameter.Name} = {clientParameter.Name};");
                }

                writer.Line($"this.clientDiagnostics = clientDiagnostics;");
                writer.Line($"this.pipeline = pipeline;");
            }
        }

        private void WriteParameter(CodeWriter writer, Parameter clientParameter)
        {
            writer.Append($"{_typeFactory.CreateInputType(clientParameter.Type)} {clientParameter.Name}");
            if (clientParameter.DefaultValue != null)
            {
                writer.Append($" = {clientParameter.DefaultValue.Value.Value:L}");
            }

            writer.AppendRaw(",");
        }

        private string CreateMethodName(Method operation, bool async, bool supportsPaging) => $"{operation.Name}{(supportsPaging ? "FirstPage" : string.Empty)}{(async ? "Async" : string.Empty)}";

        private string CreateRequestMethodName(Method operation) => $"Create{operation.Name}{(operation.Paging != null ? "FirstPage" : string.Empty)}Request";

        private string CreateNextPageRequestMethodName(Method operation) => $"Create{operation.Name}NextPageRequest";

        private string GetNextPageMethodName(Method operation) => $"{operation.Name}NextPageAsync";

        private bool IsNextPageParameter(Parameter parameter) =>
            parameter.Location != ParameterLocation.Path
            && parameter.Location != ParameterLocation.Body
            && parameter.Location != ParameterLocation.Query;

        private void WriteRequestCreation(CodeWriter writer, Method operation, bool nextPage = false)
        {
            var methodName = nextPage ? CreateNextPageRequestMethodName(operation) : CreateRequestMethodName(operation);
            writer.Append($"internal {typeof(HttpMessage)} {methodName}(");
            var parameters = nextPage
                ? operation.Parameters.Where(IsNextPageParameter).ToArray()
                : operation.Parameters;
            foreach (Parameter clientParameter in parameters)
            {
                writer.Append($"{_typeFactory.CreateInputType(clientParameter.Type)} {clientParameter.Name},");
            }
            if (nextPage)
            {
                writer.Append($"{writer.Type(typeof(string), true)} nextLinkUrl");
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                writer.Line($"var message = pipeline.CreateMessage();");
                writer.Line($"var request = message.Request;");
                var method = operation.Request.Method;
                writer.Line($"request.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                var uriType = writer.Type(typeof(Uri));
                using (nextPage ? writer.If($"{uriType}.IsWellFormedUriString(nextLinkUrl, UriKind.Absolute)") : default)
                {
                    if (nextPage)
                    {
                        writer.Line($"request.Uri.Reset(new {uriType}(nextLinkUrl));");
                    }
                }
                using (nextPage ? writer.Else() : default)
                {
                    //TODO: Add logic to escape the strings when specified, using Uri.EscapeDataString(value);
                    //TODO: Need proper logic to convert the values to strings. Right now, everything is just using default ToString().
                    //TODO: Need logic to trim duplicate slashes (/) so when combined, you don't end  up with multiple // together
                    var urlText = String.Join(String.Empty, operation.Request.HostSegments.Select(s => s.IsConstant ? s.Constant.Value : "{" + s.Parameter.Name + "}"));
                    var nextLinkText = nextPage ? "{nextLinkUrl}" : string.Empty;
                    writer.Line($"request.Uri.Reset(new {uriType}($\"{urlText}{nextLinkText}\"));");

                    if (!nextPage)
                    {
                        foreach (var segment in operation.Request.PathSegments)
                        {
                            WritePathSegment(writer, segment);
                        }

                        //TODO: Duplicate code between query and header parameter processing logic
                        foreach (var queryParameter in operation.Request.Query)
                        {
                            WriteQueryParameter(writer, queryParameter);
                        }
                    }
                }

                foreach (var header in operation.Request.Headers)
                {
                    WriteHeader(writer, header);
                }

                if (!nextPage && operation.Request.Body is RequestBody body && body.Serialization is JsonSerialization jsonSerialization)
                {
                    writer.Line($"using var content = new {typeof(Utf8JsonRequestContent)}();");

                    RequestParameter value = body.Value;

                    writer.ToSerializeCall(
                        jsonSerialization,
                        _typeFactory,
                        WriteConstantOrParameter(value),
                        writerName: w => w.Append($"content.{nameof(Utf8JsonRequestContent.JsonWriter)}"));

                    writer.Line($"request.Content = content;");
                }
                else if (!nextPage && operation.Request.Body is RequestBody xmlBody && xmlBody.Serialization is XmlElementSerialization xmlSerialization)
                {
                    writer.Line($"using var content = new {typeof(XmlWriterContent)}();");

                    RequestParameter value = xmlBody.Value;

                    writer.ToSerializeCall(
                        xmlSerialization,
                        _typeFactory,
                        WriteConstantOrParameter(value),
                        writerName: w => w.Append($"content.{nameof(XmlWriterContent.XmlWriter)}"));

                    writer.Line($"request.Content = content;");
                }

                writer.Line($"return message;");
            }
        }

        private void WriteOperation(CodeWriter writer, Method operation, bool async, bool nextPage = false)
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
            var supportsPaging = operation.Paging != null;
            var pageType = operation.Paging?.ItemType != null ? _typeFactory.CreateType(operation.Paging.ItemType) : new CSharpType(typeof(string));
            responseType = supportsPaging ? new CSharpType(typeof(Page<>), pageType) : responseType;
            var parameters = nextPage
                ? operation.Parameters.Where(IsNextPageParameter).ToArray()
                : operation.Parameters;

            writer.WriteXmlDocumentationSummary(operation.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            if (nextPage)
            {
                writer.WriteXmlDocumentationParameter("nextLinkUrl", "The URL to the next page of results.");
            }
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            var methodName = nextPage ? GetNextPageMethodName(operation) : CreateMethodName(operation, async, supportsPaging);
            CSharpType asyncReturnType = new CSharpType(typeof(ValueTask<>), responseType);
            writer.Append($"public {(async ? "async " : string.Empty)}{(async ? asyncReturnType : responseType)} {methodName}(");

            foreach (Parameter parameter in parameters)
            {
                WriteParameter(writer, parameter);
            }

            if (nextPage)
            {
                writer.Append($"{typeof(string)} nextLinkUrl, ");
            }
            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, parameters);

                writer.Line($"using var scope = clientDiagnostics.CreateScope({operation.Diagnostics.ScopeName:L});");
                foreach (DiagnosticAttribute diagnosticScopeAttributes in operation.Diagnostics.Attributes)
                {
                    writer.Line($"scope.AddAttribute({diagnosticScopeAttributes.Name:L}, {WriteConstantOrParameter(diagnosticScopeAttributes.Value)};");
                }
                writer.Line($"scope.Start();");

                using (writer.Scope($"try"))
                {
                    var requestMethodName = nextPage ? CreateNextPageRequestMethodName(operation) : CreateRequestMethodName(operation);
                    writer.Append($"using var message = {requestMethodName}(");

                    foreach (Parameter parameter in parameters)
                    {
                        writer.Append($"{parameter.Name}, ");
                    }

                    if (nextPage)
                    {
                        writer.Append($"nextLinkUrl");
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

                    WriteStatusCodeSwitch(writer, responseBody, headerModelType, operation, async, supportsPaging);
                }

                using (writer.Scope($"catch ({typeof(Exception)} e)"))
                {
                    writer.Line($"scope.Failed(e);");
                    writer.Line($"throw;");
                }
            }
        }

        private void WritePagingOperation(CodeWriter writer, Method operation, bool async)
        {
            var pageType = operation.Paging?.ItemType != null ? _typeFactory.CreateType(operation.Paging.ItemType) : new CSharpType(typeof(string));
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = operation.Parameters;
            var nextPageParameters = parameters.Where(IsNextPageParameter).ToArray();

            writer.WriteXmlDocumentationSummary(operation.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");

            writer.Append($"public {responseType} {CreateMethodName(operation, async, false)}(");
            foreach (Parameter parameter in parameters)
            {
                WriteParameter(writer, parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            using (writer.Scope())
            {
                WriteParameterNullChecks(writer, parameters);

                var funcType = new CSharpType(typeof(Task<>), new CSharpType(typeof(Page<>), pageType));
                var nullableInt = new CSharpType(typeof(int), true);

                writer.Append($"{funcType} FirstPageFunc({nullableInt} pageSizeHint) => {CreateMethodName(operation, async, true)}(");
                foreach (Parameter parameter in parameters)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                writer.Line($"cancellationToken).AsTask();");

                writer.Append($"{funcType} NextPageFunc({typeof(string)} continuationToken, {nullableInt} pageSizeHint) => {GetNextPageMethodName(operation)}(");
                foreach (Parameter parameter in nextPageParameters)
                {
                    writer.Append($"{parameter.Name}, ");
                }
                writer.Line($"continuationToken, cancellationToken).AsTask();");
                writer.Line($"return PageResponseEnumerator.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);");
            }
        }

        private CodeWriterDelegate WriteConstantOrParameter(RequestParameter constantOrParameter) => writer =>
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
        };

        private void WriteParameterNullChecks(CodeWriter writer, IEnumerable<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
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

        private void WriteConstant(CodeWriter writer, Constant constant)
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
            writer.Append($"request.Uri.AppendPath({WriteConstantOrParameter(segment.Value)}");
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

        private CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, RequestParameter value)
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

            RequestParameter value = queryParameter.Value;
            using (WriteValueNullCheck(writer, value))
            {
                writer.Append($"request.Uri.{method}({queryParameter.Name:L}, {WriteConstantOrParameter(value)}");
                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Line($", {queryParameter.Escape:L});");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, ResponseBody? responseBody, CSharpType? headersModelType, Method operation, bool async, bool supportsPaging)
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

                    var continuationTokenText = operation.Paging?.NextLinkName != null ? $"{valueVariable}.{operation.Paging?.NextLinkName}" : "null";
                    var responseCallText = supportsPaging
                        ? $"{typeof(Page)}.FromValues({valueVariable}.{operation.Paging?.ItemName}, {continuationTokenText}, message.Response)"
                        : responseBody switch
                        {
                            null when headersModelType != null => $"{typeof(ResponseWithHeaders)}.FromValue(headers, message.Response)",
                            { } when headersModelType != null => $"{typeof(ResponseWithHeaders)}.FromValue({valueVariable}, headers, message.Response)",
                            { } => $"{typeof(Response)}.FromValue({valueVariable}, message.Response)",
                            _ => "message.Response"
                        };
                    writer.Line($"return {responseCallText};");
                }

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await message.Response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw message.Response.CreateRequestFailedException();");
                }
            }
        }
    }
}
