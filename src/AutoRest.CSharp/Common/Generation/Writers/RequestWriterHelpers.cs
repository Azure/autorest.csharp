// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using Azure.Core;
using AutoRest.CSharp.Utilities;
using Azure;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class RequestWriterHelpers
    {
        public static void WriteRequestCreation(CodeWriter writer, RestClientMethod clientMethod, string methodAccessibility, ClientFields? fields, string? responseClassifierType, bool writeSDKUserAgent, IReadOnlyList<Parameter>? clientParameters = null)
        {
            using var methodScope = writer.AmbientScope();
            var parameters = clientMethod.Parameters;

            var methodName = CreateRequestMethodName(clientMethod.Name);
            writer.Append($"{methodAccessibility} {typeof(HttpMessage)} {methodName}(");
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

                if (clientMethod.Parameters.Contains(KnownParameters.RequestContext))
                {
                    writer.Append($"var {message:D} = _pipeline.CreateMessage({KnownParameters.RequestContext.Name:I}");
                    if (responseClassifierType != default)
                    {
                        writer.Append($", {responseClassifierType}");
                    }
                    writer.Line($");");
                }
                else
                {
                    writer.Line($"var {message:D} = _pipeline.CreateMessage();");
                }

                writer.Line($"var {request:D} = {message}.Request;");

                var method = clientMethod.Request.HttpMethod;
                if (!clientMethod.BufferResponse)
                {
                    writer.Line($"{message}.BufferResponse = false;");
                }
                writer.Line($"{request}.Method = {typeof(RequestMethod)}.{method.ToRequestMethodName()};");

                writer.Line($"var {uri:D} = new RawRequestUriBuilder();");
                foreach (var segment in clientMethod.Request.PathSegments)
                {
                    var value = GetFieldReference(fields, segment.Value);
                    if (value.Type.IsFrameworkType && value.Type.FrameworkType == typeof(Uri))
                    {
                        writer.Append($"{uri}.Reset(");
                        writer.Append(GetConstantOrParameter(value));
                        writer.Line($");");
                    }
                    else if (!value.IsConstant && value.Reference.Name == "nextLink")
                    {
                        WritePathSegment(writer, uri, segment, value, "AppendRawNextLink");
                    }
                    else
                    {
                        WritePathSegment(writer, uri, segment, value);
                    }
                }

                //TODO: Duplicate code between query and header parameter processing logic
                foreach (var queryParameter in clientMethod.Request.Query)
                {
                    WriteQueryParameter(writer, uri, queryParameter, fields, clientParameters);
                }

                writer.Line($"{request}.Uri = {uri};");

                WriteHeaders(writer, clientMethod, request, content: false, fields);

                switch (clientMethod.Request.Body)
                {
                    case RequestContentRequestBody body:
                        WriteHeaders(writer, clientMethod, request, content: true, fields);
                        writer.Line($"{request}.Content = {body.ParameterName};");
                        break;
                    case SchemaRequestBody body:
                        using (WriteValueNullCheck(writer, body.Value))
                        {
                            WriteHeaders(writer, clientMethod, request, content: true, fields);
                            WriteSerializeContent(writer, request, body.Serialization, GetConstantOrParameter(body.Value, ignoreNullability: true));
                        }

                        break;
                    case BinaryRequestBody binaryBody:
                        using (WriteValueNullCheck(writer, binaryBody.Value))
                        {
                            WriteHeaders(writer, clientMethod, request, content: true, fields);
                            writer.Append($"{request}.Content = {typeof(RequestContent)}.Create(");
                            WriteConstantOrParameter(writer, binaryBody.Value);
                            writer.Line($");");
                        }
                        break;
                    case TextRequestBody textBody:
                        using (WriteValueNullCheck(writer, textBody.Value))
                        {
                            WriteHeaders(writer, clientMethod, request, content: true, fields);
                            writer.Append($"{request}.Content = new {typeof(StringRequestContent)}(");
                            WriteConstantOrParameter(writer, textBody.Value);
                            writer.Line($");");
                        }
                        break;
                    case MultipartRequestBody multipartRequestBody:
                        WriteHeaders(writer, clientMethod, request, content: true, fields);

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
                        WriteHeaders(writer, clientMethod, request, content: true, fields);

                        var initializers = new List<PropertyInitializer>();
                        foreach (var initializer in flattenedSchemaRequestBody.Initializers)
                        {
                            initializers.Add(new PropertyInitializer(initializer.Property.Declaration.Name, initializer.Property.Declaration.Type, initializer.Property.IsReadOnly, initializer.Value.GetReferenceOrConstantFormattable(), initializer.Value.Type));
                        }
                        var modelVariable = new CodeWriterDeclaration("model");
                        writer.WriteInitialization(
                                v => writer.Line($"var {modelVariable:D} = {v};"),
                                flattenedSchemaRequestBody.ObjectType,
                                flattenedSchemaRequestBody.ObjectType.InitializationConstructor,
                                initializers);

                        WriteSerializeContent(writer, request, flattenedSchemaRequestBody.Serialization, $"{modelVariable:I}");
                        break;
                    case UrlEncodedBody urlEncodedRequestBody:
                        var urlContent = new CodeWriterDeclaration("content");

                        WriteHeaders(writer, clientMethod, request, content: true, fields);
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

                if (writeSDKUserAgent)
                {
                    writer.Line($"_userAgent.Apply({message});");
                }

                writer.Line($"return {message};");
            }
            writer.Line();
        }

        private static ReferenceOrConstant GetFieldReference(ClientFields? fields, ReferenceOrConstant value) =>
            fields != null && !value.IsConstant ? fields.GetFieldByParameter(value.Reference.Name, value.Reference.Type) ?? value : value;

        public static void WriteHeaders(CodeWriter writer, RestClientMethod clientMethod, CodeWriterDeclaration request, bool content, ClientFields? fields)
        {
            foreach (var header in clientMethod.Request.Headers)
            {
                if (header.IsContentHeader == content)
                {
                    WriteHeader(writer, request, header, fields);
                }
            }
        }

        public static string CreateRequestMethodName(string name) => $"Create{name}Request";

        private static void WriteSerializeContent(CodeWriter writer, CodeWriterDeclaration request, ObjectSerialization bodySerialization, FormattableString value)
        {
            switch (bodySerialization)
            {
                case JsonSerialization jsonSerialization:
                    {
                        writer.WriteMethodBodyStatement(Snippets.Var("content", Utf8JsonRequestContentExpression.New(), out var content));
                        writer.WriteMethodBodyStatement(JsonSerializationMethodsBuilder.SerializeExpression(content.JsonWriter, jsonSerialization, new FormattableStringToExpression(value)));
                        writer.WriteMethodBodyStatement(Snippets.Assign(new RequestExpression(request).Content, content));
                        break;
                    }
                case XmlElementSerialization xmlSerialization:
                    {
                        writer.WriteMethodBodyStatement(Snippets.Var("content", XmlWriterContentExpression.New(), out var content));
                        writer.WriteMethodBodyStatement(XmlSerializationMethodsBuilder.SerializeExpression(content.XmlWriter, xmlSerialization, new FormattableStringToExpression(value)));
                        writer.WriteMethodBodyStatement(Snippets.Assign(new RequestExpression(request).Content, content));
                        break;
                    }
                default:
                    throw new NotImplementedException(bodySerialization.ToString());
            }
        }

        private static void WriteHeader(CodeWriter writer, CodeWriterDeclaration request, RequestHeader header, ClientFields? fields)
        {
            string? delimiter = header.Delimiter;
            string method = delimiter != null
                ? nameof(RequestHeaderExtensions.AddDelimited)
                : nameof(RequestHeaderExtensions.Add);

            var value = GetFieldReference(fields, header.Value);
            using (WriteValueNullCheck(writer, value))
            {
                if (value.Type.Equals(typeof(MatchConditions)) || value.Type.Equals(typeof(RequestConditions)))
                {
                    writer.Append($"{request}.Headers.{method}(");
                } else
                {
                    writer.Append($"{request}.Headers.{method}({header.Name:L}, ");
                }

                if (value.Type.Equals(typeof(ContentType)))
                {
                    WriteConstantOrParameterAsString(writer, value);
                }
                else
                {
                    WriteConstantOrParameter(writer, value, enumAsString: true);
                }

                if (delimiter != null)
                {
                    writer.Append($", {delimiter:L}");
                }
                WriteSerializationFormat(writer, header.Format);
                writer.Line($");");
            }
        }

        private static void WritePathSegment(CodeWriter writer, CodeWriterDeclaration uri, PathSegment segment, ReferenceOrConstant value, string? methodName = null)
        {
            methodName ??= segment.IsRaw ? "AppendRaw" : "AppendPath";
            writer.Append($"{uri}.{methodName}(");
            WriteConstantOrParameter(writer, value, enumAsString: !segment.IsRaw || TypeFactory.IsExtendableEnum(value.Type));
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
            writer.Append(GetConstantOrParameter(constantOrReference, ignoreNullability));

            if (enumAsString && constantOrReference.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                writer.AppendEnumToString(enumType);
            }
        }

        private static FormattableString GetConstantOrParameter(ReferenceOrConstant constantOrReference, bool ignoreNullability = false)
        {
            if (constantOrReference.IsConstant)
            {
                return constantOrReference.Constant.GetConstantFormattable();
            }

            if (!ignoreNullability && constantOrReference.Type.IsNullable && constantOrReference.Type.IsValueType)
            {
                return $"{constantOrReference.Reference.Name:I}.Value";
            }

            return $"{constantOrReference.Reference.Name:I}";
        }

        private static void WriteSerializationFormat(CodeWriter writer, SerializationFormat format)
        {
            var formatSpecifier = format.ToFormatSpecifier();
            if (formatSpecifier != null)
            {
                writer.Append($", {formatSpecifier:L}");
            }
        }

        private static void WriteQueryParameter(CodeWriter writer, CodeWriterDeclaration uri, QueryParameter queryParameter, ClientFields? fields, IReadOnlyList<Parameter>? parameters)
        {
            string? delimiter = queryParameter.Delimiter;
            bool explode = queryParameter.Explode;
            string method = delimiter != null && !explode
                ? nameof(RequestUriBuilderExtensions.AppendQueryDelimited)
                : nameof(RequestUriBuilderExtensions.AppendQuery);

            var value = GetFieldReference(fields, queryParameter.Value);
            var parameter = parameters != null && queryParameter.Name == "api-version" ? parameters.FirstOrDefault(p => p.Name == "apiVersion") : null;
            using (parameter != null && parameter.IsOptionalInSignature ? null : WriteValueNullCheck(writer, value))
            {
                if (explode)
                {
                    var paramVariable = new CodeWriterDeclaration("param");
                    writer.Append($"foreach(var {paramVariable:D} in ");
                    WriteConstantOrParameter(writer, value, enumAsString: true);
                    writer.Line($")");
                    using (writer.Scope())
                    {
                        writer.Append($"{uri}.{method}({queryParameter.Name:L}, ");
                        WriteConstantOrParameter(writer, new Reference(paramVariable.ActualName, value.Type.Arguments.Length > 0 ? value.Type.Arguments[0] : value.Type), enumAsString: true);
                        WriteSerializationFormat(writer, queryParameter.SerializationFormat);
                        writer.Line($", {queryParameter.Escape:L});");
                    }
                }
                else
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
    }
}
