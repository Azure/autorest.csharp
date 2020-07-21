// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {cs.Name}"))
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

        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string ClientDiagnosticsField = "_" + ClientDiagnosticsVariable;
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;

        private void WriteClientFields(CodeWriter writer, RestClient restClient)
        {
            foreach (Parameter clientParameter in restClient.Parameters)
            {
                writer.Line($"private {clientParameter.Type} {clientParameter.Name};");
            }

            writer.Line($"private {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private {typeof(HttpPipeline)} {PipelineField};");
            writer.Line();
        }

        private void WriteClientCtor(CodeWriter writer, RestClient restClient, CSharpType cs)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {cs.Name}");
            writer.WriteXmlDocumentationParameter(ClientDiagnosticsVariable, "The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter(PipelineVariable, "The HTTP pipeline for sending and receiving REST requests and responses.");
            foreach (Parameter parameter in restClient.Parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationRequiredParametersException(restClient.Parameters);

            writer.Append($"public {cs.Name:D}({typeof(ClientDiagnostics)} {ClientDiagnosticsVariable}, {typeof(HttpPipeline)} {PipelineVariable},");
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

                writer.Line($"{ClientDiagnosticsField} = {ClientDiagnosticsVariable};");
                writer.Line($"{PipelineField} = {PipelineVariable};");
            }
            writer.Line();
        }

        private string CreateMethodName(string name, bool async) => $"{name}{(async ? "Async" : string.Empty)}";

        private string CreateRequestMethodName(string name) => $"Create{name}Request";

        private void WriteRequestCreation(CodeWriter writer, RestClientMethod clientMethod)
        {
            using var methodScope = writer.AmbientScope();

            var methodName = CreateRequestMethodName(clientMethod.Name);
            writer.Append($"internal {typeof(HttpMessage)} {methodName}(");
            var parameters = clientMethod.Parameters;
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

                writer.Line($"var {message:D} = {PipelineField}.CreateMessage();");
                writer.Line($"var {request:D} = {message}.Request;");
                var method = clientMethod.Request.HttpMethod;
                writer.Line($"{request}.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                writer.Line($"var {uri:D} = new RawRequestUriBuilder();");
                foreach (var segment in clientMethod.Request.PathSegments)
                {
                    if (!segment.Value.IsConstant && segment.Value.Reference.Name == "nextLink")
                    {
                        if (segment.IsRaw)
                        {
                            // Artificial nextLink needs additional logic for relative versus absolute links
                            WritePathSegment(writer, uri, segment, "AppendRawNextLink");
                        }
                        else
                        {
                            // Natural nextLink parameters need to use a different method to parse path and query elements
                            WritePathSegment(writer, uri, segment, "AppendRaw");
                        }
                    }
                    else
                    {
                        WritePathSegment(writer, uri, segment);
                    }
                }

                //TODO: Duplicate code between query and header parameter processing logic
                foreach (var queryParameter in clientMethod.Request.Query)
                {
                    WriteQueryParameter(writer, uri, queryParameter);
                }

                writer.Line($"{request}.Uri = {uri};");

                foreach (var header in clientMethod.Request.Headers)
                {
                    WriteHeader(writer, request, header);
                }

                switch (clientMethod.Request.Body)
                {
                    case SchemaRequestBody body:
                        using (WriteValueNullCheck(writer, body.Value))
                        {
                            WriteSerializeContent(
                                writer,
                                request,
                                body.Serialization,
                                w => WriteConstantOrParameter(w, body.Value, ignoreNullability: true));
                        }

                        break;
                    case BinaryRequestBody binaryBody:
                        using (WriteValueNullCheck(writer, binaryBody.Value))
                        {
                            writer.Append($"{request}.Content = {typeof(RequestContent)}.Create(");
                            WriteConstantOrParameter(writer, binaryBody.Value);
                            writer.Line($");");
                        }
                        break;
                    case TextRequestBody textBody:
                        using (WriteValueNullCheck(writer, textBody.Value))
                        {
                            writer.Append($"{request}.Content = new {typeof(StringRequestContent)}(");
                            WriteConstantOrParameter(writer, textBody.Value);
                            writer.Line($");");
                        }
                        break;
                    case FlattenedSchemaRequestBody flattenedSchemaRequestBody:
                        var initializers = new List<PropertyInitializer>();
                        foreach (var initializer in flattenedSchemaRequestBody.Initializers)
                        {
                            initializers.Add(new PropertyInitializer(initializer.Property, w => w.WriteReferenceOrConstant(initializer.Value)));
                        }
                        var modelVariable = new CodeWriterDeclaration("model");
                        writer.WriteInitialization(
                                (w, v) => w.Line($"var {modelVariable:D} = {v};"),
                                flattenedSchemaRequestBody.ObjectType,
                                flattenedSchemaRequestBody.ObjectType.InitializationConstructor,
                                initializers);

                        WriteSerializeContent(
                            writer,
                            request,
                            flattenedSchemaRequestBody.Serialization,
                            w => w.Append(modelVariable));
                        break;
                    case null:
                        break;
                    default:
                        throw new NotImplementedException(clientMethod.Request.Body?.GetType().FullName);
                }

                writer.Line($"return {message};");
            }
            writer.Line();
        }

        private static void WriteSerializeContent(CodeWriter writer, CodeWriterDeclaration request, ObjectSerialization bodySerialization, CodeWriterDelegate valueDelegate)
        {
            switch (bodySerialization)
            {
                case JsonSerialization jsonSerialization:
                {
                    var content = new CodeWriterDeclaration("content");

                    writer.Line($"var {content:D} = new {typeof(Utf8JsonRequestContent)}();");
                    writer.ToSerializeCall(
                        jsonSerialization,
                        valueDelegate,
                        writerName: w => w.Append($"{content}.{nameof(Utf8JsonRequestContent.JsonWriter)}"));
                    writer.Line($"{request}.Content = {content};");
                    break;
                }
                case XmlElementSerialization xmlSerialization:
                {
                    var content = new CodeWriterDeclaration("content");

                    writer.Line($"var {content:D} = new {typeof(XmlWriterContent)}();");
                    writer.ToSerializeCall(
                        xmlSerialization,
                        valueDelegate,
                        writerName: w => w.Append($"{content}.{nameof(XmlWriterContent.XmlWriter)}"));
                    writer.Line($"{request}.Content = {content};");
                    break;
                }
                default:
                    throw new NotImplementedException(bodySerialization.ToString());
            }
        }

        private void WriteOperation(CodeWriter writer, RestClientMethod operation, bool async)
        {
            using var methodScope = writer.AmbientScope();

            CSharpType? bodyType = operation.ReturnType;
            CSharpType? headerModelType = operation.HeaderModel?.Type;
            CSharpType responseType = bodyType switch
            {
                null when headerModelType != null => new CSharpType(typeof(ResponseWithHeaders<>), headerModelType),
                { } when headerModelType == null => new CSharpType(typeof(Response<>), bodyType),
                { } => new CSharpType(typeof(ResponseWithHeaders<>), bodyType, headerModelType),
                _ => new CSharpType(typeof(Response)),
            };
            responseType = async ? new CSharpType(typeof(Task<>), responseType) : responseType;
            var parameters = operation.Parameters;
            writer.WriteXmlDocumentationSummary(operation.Description);

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

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

                var messageVariable = new CodeWriterDeclaration("message");
                var requestMethodName = CreateRequestMethodName(operation.Name);
                writer.Append($"using var {messageVariable:D} = {requestMethodName}(");

                foreach (Parameter parameter in parameters)
                {
                    writer.Append($"{parameter.Name:I}, ");
                }

                writer.RemoveTrailingComma();
                writer.Line($");");

                if (async)
                {
                    writer.Line($"await {PipelineField}.SendAsync({messageVariable}, cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"{PipelineField}.Send({messageVariable}, cancellationToken);");
                }

                WriteStatusCodeSwitch(writer, messageVariable, operation, async);
            }
            writer.Line();
        }

        private void WriteConstantOrParameter(CodeWriter writer, ReferenceOrConstant constantOrReference, bool ignoreNullability = false, bool enumAsString = false)
        {
            if (constantOrReference.IsConstant)
            {
                writer.WriteConstant(constantOrReference.Constant);
            }
            else
            {
                writer.Identifier(constantOrReference.Reference.Name);
                if (!ignoreNullability)
                {
                    writer.AppendNullableValue(constantOrReference.Type);
                }
            }

            if (enumAsString &&
                !constantOrReference.Type.IsFrameworkType &&
                constantOrReference.Type.Implementation is EnumType enumType)
            {
                writer.AppendEnumToString(enumType);
            }
        }

        private void WritePathSegment(CodeWriter writer, CodeWriterDeclaration uri, PathSegment segment, string? methodName = null)
        {
            if (segment.Value.Type.IsFrameworkType &&
                segment.Value.Type.FrameworkType == typeof(Uri))
            {
                writer.Append($"{uri}.Reset(");
                WriteConstantOrParameter(writer, segment.Value, enumAsString: !segment.IsRaw);
                writer.Line($");");
                return;
            }

            methodName ??= segment.IsRaw ? "AppendRaw" : "AppendPath";
            writer.Append($"{uri}.{methodName}(");
            WriteConstantOrParameter(writer, segment.Value, enumAsString: !segment.IsRaw);
            WriteSerializationFormat(writer, segment.Format);
            writer.Line($", {segment.Escape:L});");
        }

        private string? GetSerializationStyleDelimiter(RequestParameterSerializationStyle style) => style switch
        {
            RequestParameterSerializationStyle.PipeDelimited => "|",
            RequestParameterSerializationStyle.TabDelimited => "\t",
            RequestParameterSerializationStyle.SpaceDelimited => " ",
            RequestParameterSerializationStyle.CommaDelimited => ",",
            _ => null
        };

        private void WriteHeader(CodeWriter writer, CodeWriterDeclaration request, RequestHeader header)
        {
            string? delimiter = GetSerializationStyleDelimiter(header.SerializationStyle);
            string method = delimiter != null
                ? nameof(RequestHeaderExtensions.AddDelimited)
                : nameof(RequestHeaderExtensions.Add);

            using (WriteValueNullCheck(writer, header.Value))
            {
                writer.Append($"{request}.Headers.{method}({header.Name:L}, ");
                WriteConstantOrParameter(writer, header.Value, enumAsString: true);
                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, header.Format);
                writer.Line($");");
            }
        }

        private CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, ReferenceOrConstant value)
        {
            if (value.IsConstant)
                return default;

            var type = value.Type;
            if (type.IsNullable)
            {
                // turn "object.Property" into "object?.Property"
                var parts = value.Reference.Name.Split(".");

                writer.Append($"if (");
                bool first = true;
                foreach (var part in parts)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        writer.AppendRaw("?.");
                    }
                    writer.Identifier(part);
                }

                return writer.Line($" != null)").Scope();
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
            string? delimiter = GetSerializationStyleDelimiter(queryParameter.SerializationStyle);
            string method = delimiter != null
                ? nameof(RequestUriBuilderExtensions.AppendQueryDelimited)
                : nameof(RequestUriBuilderExtensions.AppendQuery);

            ReferenceOrConstant value = queryParameter.Value;
            using (WriteValueNullCheck(writer, value))
            {
                writer.Append($"{uri}.{method}({queryParameter.Name:L}, ");
                WriteConstantOrParameter(writer, value, enumAsString: true);
                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                writer.Line($", {queryParameter.Escape:L});");
            }
        }

        //TODO: Do multiple status codes
        private void WriteStatusCodeSwitch(CodeWriter writer, CodeWriterDeclaration message, RestClientMethod operation, bool async)
        {
            string responseVariable = $"{message.ActualName}.Response";

            var returnType = operation.ReturnType;
            var headersModelType = operation.HeaderModel?.Type;

            ReturnKind kind;

            if (returnType != null && headersModelType != null)
            {
                kind = ReturnKind.HeadersAndValue;
            }
            else if (headersModelType != null)
            {
                kind = ReturnKind.Headers;
            }
            else if (returnType != null)
            {
                kind = ReturnKind.Value;
            }
            else
            {
                kind = ReturnKind.Response;
            }

            if (headersModelType != null)
            {
                writer.Line($"var headers = new {headersModelType}({responseVariable});");
            }

            using (writer.Scope($"switch ({responseVariable}.Status)"))
            {
                foreach (var response in operation.Responses)
                {
                    var responseBody = response.ResponseBody;
                    var statusCodes = response.StatusCodes;

                    foreach (var statusCode in statusCodes)
                    {
                        writer.Line($"case {statusCode}:");
                    }

                    using (responseBody != null ? writer.Scope() : default)
                    {
                        ReferenceOrConstant value = default;

                        var valueVariable = new CodeWriterDeclaration("value");
                        if (responseBody is ObjectResponseBody objectResponseBody)
                        {
                            writer.Line($"{responseBody.Type} {valueVariable:D} = default;");
                            writer.WriteDeserializationForMethods(
                                objectResponseBody.Serialization,
                                async,
                                (w, v) => w.Line($"{valueVariable} = {v};"),
                                responseVariable);
                            value = new Reference(valueVariable.ActualName, responseBody.Type);
                        }
                        else if (responseBody is StreamResponseBody _)
                        {
                            writer.Line($"var {valueVariable:D} = {message}.ExtractResponseContent();");
                            value = new Reference(valueVariable.ActualName, responseBody.Type);
                        }
                        else if (returnType != null)
                        {
                            value = Constant.Default(returnType.WithNullable(true));
                        }

                        switch (kind)
                        {
                            case ReturnKind.Response:
                                writer.Append($"return {responseVariable};");
                                break;
                            case ReturnKind.Headers:
                                writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue(headers, {responseVariable});");
                                break;
                            case ReturnKind.HeadersAndValue:
                                writer.Append($"return {typeof(ResponseWithHeaders)}.FromValue");
                                if (!Equals(responseBody?.Type, operation.ReturnType))
                                {
                                    writer.Append($"<{operation.ReturnType}, {headersModelType}>");
                                }
                                writer.Append($"(");
                                writer.WriteReferenceOrConstant(value);
                                writer.Append($", headers, {responseVariable});");
                                break;
                            case ReturnKind.Value:
                                writer.Append($"return {typeof(Response)}.FromValue");
                                if (!Equals(responseBody?.Type, operation.ReturnType))
                                {
                                    writer.Append($"<{operation.ReturnType}>");
                                }
                                writer.Append($"(");
                                writer.WriteReferenceOrConstant(value);
                                writer.Append($", {responseVariable});");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                writer.Line($"default:");
                if (async)
                {
                    writer.Line($"throw await {ClientDiagnosticsField}.CreateRequestFailedExceptionAsync({responseVariable}).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"throw {ClientDiagnosticsField}.CreateRequestFailedException({responseVariable});");
                }
            }
        }

        private enum ReturnKind
        {
            Response,
            Headers,
            HeadersAndValue,
            Value
        }
    }
}
