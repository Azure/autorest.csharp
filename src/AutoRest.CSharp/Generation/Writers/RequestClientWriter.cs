// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using Azure.Core;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class RequestClientWriter
    {
        private const string PipelineVariable = "pipeline";
        private const string PipelineField = "_" + PipelineVariable;

        public static void WriteRequestCreation(CodeWriter writer, RestClientMethod clientMethod, bool lowLevel)
        {
            using var methodScope = writer.AmbientScope();

            var methodName = CreateRequestMethodName(clientMethod.Name);
            var returnType = lowLevel ? typeof(DynamicRequest) : typeof(HttpMessage);
            var visibility = lowLevel ? "public" : "internal";
            writer.Append($"{visibility} {returnType} {methodName}(");
            var parameters = clientMethod.Parameters;
            // Skip the first model parameter on low level client
            foreach (Parameter clientParameter in parameters.Skip(lowLevel ? 1 : 0))
            {
                if (lowLevel)
                {
                    writer.WriteParameter(clientParameter.Type, clientParameter.Name, clientParameter.DefaultValue);
                }
                else
                {
                    writer.Append($"{clientParameter.Type} {clientParameter.Name:D},");
                }
            }
            writer.RemoveTrailingComma();
            writer.Line($")");
            using (writer.Scope())
            {
                var message = new CodeWriterDeclaration("message");
                var request = new CodeWriterDeclaration("request");
                var uri = new CodeWriterDeclaration("uri");

                if (lowLevel)
                {
                    writer.Line($"var {request:D} = {PipelineField}.CreateRequest();");
                }
                else
                {
                    writer.Line($"var {message:D} = {PipelineField}.CreateMessage();");
                    writer.Line($"var {request:D} = {message}.Request;");
                }
                var method = clientMethod.Request.HttpMethod;
                if (!clientMethod.BufferResponse)
                {
                    writer.Line($"{message}.BufferResponse = false;");
                }
                writer.Line($"{request}.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                writer.Line($"var {uri:D} = new RawRequestUriBuilder();");
                foreach (var segment in clientMethod.Request.PathSegments)
                {
                    if (!segment.Value.IsConstant && segment.Value.Reference.Name == "nextLink")
                    {
                        WritePathSegment(writer, uri, segment, "AppendRawNextLink");
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

                WriteHeaders(writer, clientMethod, request, content: false);

                if (lowLevel)
                {
                    RequestClientWriter.WriteHeaders(writer, clientMethod, request, content: true);
                    writer.Line($"return new DynamicRequest({request}, _pipeline);");
                }
                else
                {
                    switch (clientMethod.Request.Body)
                    {
                        case SchemaRequestBody body:
                            using (WriteValueNullCheck(writer, body.Value))
                            {
                                WriteHeaders(writer, clientMethod, request, content: true);
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
                                WriteHeaders(writer, clientMethod, request, content: true);
                                writer.Append($"{request}.Content = {typeof(RequestContent)}.Create(");
                                WriteConstantOrParameter(writer, binaryBody.Value);
                                writer.Line($");");
                            }
                            break;
                        case TextRequestBody textBody:
                            using (WriteValueNullCheck(writer, textBody.Value))
                            {
                                WriteHeaders(writer, clientMethod, request, content: true);
                                writer.Append($"{request}.Content = new {typeof(StringRequestContent)}(");
                                WriteConstantOrParameter(writer, textBody.Value);
                                writer.Line($");");
                            }
                            break;
                        case MultipartRequestBody multipartRequestBody:
                            WriteHeaders(writer, clientMethod, request, content: true);

                            var multipartContent = new CodeWriterDeclaration("content");
                            writer.Line($"var {multipartContent:D} = new {typeof(MultipartFormDataContent)}();");

                            foreach (var bodyParameter in multipartRequestBody.RequestBodyParts)
                            {
                                switch (bodyParameter.Content)
                                {
                                    case BinaryRequestBody binaryBody:
                                        using (WriteValueNullCheck(writer, binaryBody.Value))
                                        {
                                            writer.Append($"{multipartContent}.Add({typeof(RequestContent)}.Create(");
                                            WriteConstantOrParameter(writer, binaryBody.Value);
                                            writer.Line($"), {bodyParameter.Name:L}, null);");
                                        }
                                        break;
                                    case TextRequestBody textBody:
                                        using (WriteValueNullCheck(writer, textBody.Value))
                                        {
                                            writer.Append($"{multipartContent}.Add(new {typeof(StringRequestContent)}(");
                                            WriteConstantOrParameter(writer, textBody.Value);
                                            writer.Line($"), {bodyParameter.Name:L}, null);");
                                        }
                                        break;
                                    case BinaryCollectionRequestBody collectionBody:
                                        var collectionItemVariable = new CodeWriterDeclaration("value");
                                        using (writer.Scope($"foreach (var {collectionItemVariable:D} in {collectionBody.Value.Reference.Name})"))
                                        {
                                            writer.Append($"{multipartContent}.Add({typeof(RequestContent)}.Create({collectionItemVariable}), {bodyParameter.Name:L}, null);");
                                        }
                                        break;
                                    default:
                                        throw new NotImplementedException(bodyParameter.Content?.GetType().FullName);
                                }
                            }
                            writer.Line($"{multipartContent}.ApplyToRequest({request});");
                            break;
                        case FlattenedSchemaRequestBody flattenedSchemaRequestBody:
                            WriteHeaders(writer, clientMethod, request, content: true);

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
                        case UrlEncodedBody urlEncodedRequestBody:
                            var urlContent = new CodeWriterDeclaration("content");

                            WriteHeaders(writer, clientMethod, request, content: true);
                            writer.Line($"var {urlContent:D} = new {typeof(FormUrlEncodedContent)}();");

                            foreach (var (name, value) in urlEncodedRequestBody.Values)
                            {
                                using (WriteValueNullCheck(writer, value))
                                {
                                    writer.Append($"{urlContent}.Add({name:L},");
                                    WriteConstantOrParameterAsString(writer, value);
                                    writer.Line($");");
                                }
                            }
                            writer.Line($"{request}.Content = {urlContent};");
                            break;
                        case null:
                            break;
                        default:
                            throw new NotImplementedException(clientMethod.Request.Body?.GetType().FullName);
                    }

                    writer.Line($"return {message};");
                }
            }
            writer.Line();
        }

        public static void WriteHeaders(CodeWriter writer, RestClientMethod clientMethod, CodeWriterDeclaration request, bool content)
        {
            foreach (var header in clientMethod.Request.Headers)
            {
                if (header.IsContentHeader == content)
                {
                    WriteHeader(writer, request, header);
                }
            }
        }

        public static string CreateRequestMethodName(string name) => $"Create{name}Request";

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

        private static void WriteHeader(CodeWriter writer, CodeWriterDeclaration request, RequestHeader header)
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

        private static void WritePathSegment(CodeWriter writer, CodeWriterDeclaration uri, PathSegment segment, string? methodName = null)
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

        private static void WriteConstantOrParameterAsString(CodeWriter writer, ReferenceOrConstant constantOrReference)
        {
            WriteConstantOrParameter(writer, constantOrReference, enumAsString: true);
            if (constantOrReference.Type.IsFrameworkType && constantOrReference.Type.FrameworkType != typeof(string))
            {
                writer.Append($".ToString()");
            }
        }

        private static void WriteConstantOrParameter(CodeWriter writer, ReferenceOrConstant constantOrReference, bool ignoreNullability = false, bool enumAsString = false)
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

        private static void WriteSerializationFormat(CodeWriter writer, SerializationFormat format)
        {
            var formatSpecifier = format.ToFormatSpecifier();
            if (formatSpecifier != null)
            {
                writer.Append($", {formatSpecifier:L}");
            }
        }

        private static void WriteQueryParameter(CodeWriter writer, CodeWriterDeclaration uri, QueryParameter queryParameter)
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

        private static CodeWriter.CodeWriterScope? WriteValueNullCheck(CodeWriter writer, ReferenceOrConstant value)
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

        private static string? GetSerializationStyleDelimiter(RequestParameterSerializationStyle style) => style switch
        {
            RequestParameterSerializationStyle.PipeDelimited => "|",
            RequestParameterSerializationStyle.TabDelimited => "\t",
            RequestParameterSerializationStyle.SpaceDelimited => " ",
            RequestParameterSerializationStyle.CommaDelimited => ",",
            _ => null
        };

    }
}
