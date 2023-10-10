// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class CreateMessageMethodBuilder
    {
        private readonly ClientFields _fields;
        private readonly RequestParts _requestParts;
        private readonly HttpPipelineExpression _pipeline;
        private readonly RequestContextExpression? _requestContext;
        private readonly BodyMediaType _bodyMediaType;

        public CreateMessageMethodBuilder(ClientFields fields, RequestParts requestParts, RequestContextExpression? requestContext, BodyMediaType bodyMediaType)
        {
            _fields = fields;
            _requestParts = requestParts;
            _requestContext = requestContext;
            _bodyMediaType = bodyMediaType;
            _pipeline  = new HttpPipelineExpression(_fields.PipelineField);
        }

        public MethodBodyStatement CreateHttpMessage(RequestMethod requestMethod, bool bufferResponse, ResponseClassifierType? responseClassifierType, out HttpMessageExpression message, out RequestExpression request, out RawRequestUriBuilderExpression uriBuilder)
        {
            var callPipelineCreateMessage = _requestContext is not null
                ? responseClassifierType is not null
                    ? _pipeline.CreateMessage(_requestContext, new MemberExpression(null, responseClassifierType.Name))
                    : _pipeline.CreateMessage(_requestContext)
                : _pipeline.CreateMessage();

            var statements = new List<MethodBodyStatement>
            {
                Var("message", callPipelineCreateMessage, out message),
                Var("request", message.Request, out request)
            };

            if (!bufferResponse)
            {
                statements.Add(Assign(message.BufferResponse, False));
            }

            statements.Add(Assign(request.Method, new MemberExpression(typeof(RequestMethod), requestMethod.ToRequestMethodName())));
            statements.Add(Var("uri", New.RawRequestUriBuilder(), out uriBuilder));

            return statements;
        }

        public MethodBodyStatement AddUri(RawRequestUriBuilderExpression uriBuilder, string uri)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uri))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendRaw(span.ToString(), false));
                }
                else
                {
                    RequestPart? requestPart = null;
                    foreach (var part in _requestParts.UriParts)
                    {
                        if (part.NameInRequest.AsSpan().Equals(span, StringComparison.InvariantCulture))
                        {
                            requestPart = part;
                            break;
                        }
                    }

                    if (requestPart is not null)
                    {
                        lines.Add(requestPart.Value.Type.Equals(typeof(Uri))
                            ? uriBuilder.Reset(requestPart.Value)
                            : uriBuilder.AppendRaw(ConvertToRequestPartType(requestPart.Value, requestPart.Value.Type, convertOnlyExtendableEnumToString: true), requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{uri}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }

                }
            }
            return lines;
        }

        public MethodBodyStatement AddPath(RawRequestUriBuilderExpression uriBuilder, string path)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(path))
            {
                if (isLiteral)
                {
                    lines.Add(uriBuilder.AppendPath(span.ToString(), false));
                }
                else
                {
                    RequestPart? requestPart = null;
                    foreach (var part in _requestParts.PathParts)
                    {
                        if (part.NameInRequest.AsSpan().Equals(span, StringComparison.InvariantCulture))
                        {
                            requestPart = part;
                            break;
                        }
                    }

                    if (requestPart is not null)
                    {
                        lines.Add(requestPart.Value is not ConstantExpression && requestPart.NameInRequest == "nextLink"
                            ? uriBuilder.AppendRawNextLink(requestPart.Value, requestPart.Escape)
                            : uriBuilder.AppendPath(ConvertToRequestPartType(requestPart.Value, requestPart.Value.Type, requestPart.SerializationFormat), requestPart.SerializationFormat, requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{path}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                }
            }
            return lines;
        }

        public MethodBodyStatement AddQuery(RawRequestUriBuilderExpression uriBuilder)
            => _requestParts.QueryParts.Select(rp => NullCheckRequestPartValue(rp, GetAddToQueryStatement(uriBuilder, rp))).AsStatement();

        public MethodBodyStatement AddHeaders(RequestExpression request)
            => _requestParts.HeaderParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(request, rp))).AsStatement();

        public MethodBodyStatement AddContentHeaders(RequestExpression request)
            => _requestParts.ContentHeaderParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(request, rp))).AsStatement();

        public MethodBodyStatement AddBody(RequestExpression request)
            => _bodyMediaType switch
            {
                BodyMediaType.Multipart => new[]
                {
                    AddContentHeaders(request),
                    Var("content", New.MultipartFormDataContent(), out var multipartContent),
                    _requestParts.BodyParts.Select(rp => NullCheckRequestPartValue(rp, GetAddMultipartBodyPartStatement(multipartContent, rp))).AsStatement(),
                    multipartContent.ApplyToRequest(request)
                },
                BodyMediaType.Form => new[]
                {
                    AddContentHeaders(request),
                    Var("content", New.FormUrlEncodedContent(), out var urlContent),
                    _requestParts.BodyParts.Select(rp => NullCheckRequestPartValue(rp, urlContent.Add(rp.NameInRequest!, ConvertToString(rp.Value)))).AsStatement(),
                    Assign(request.Content, urlContent)
                },
                _ when _requestParts.BodyParts is [BodyRequestPart bodyRequestPart] =>
                    NullCheckRequestPartValue(bodyRequestPart, new[]
                    {
                        AddContentHeaders(request),
                        bodyRequestPart.Conversion ?? new MethodBodyStatement(),
                        Assign(request.Content, bodyRequestPart.Content)
                    }),
                _ => new MethodBodyStatement()
            };

        public MethodBodyStatement AddUserAgent(HttpMessageExpression message)
            => _fields.UserAgentField is not null
                ? new InvokeInstanceMethodStatement(_fields.UserAgentField, nameof(TelemetryDetails.Apply), message)
                : new MethodBodyStatement();

        private static MethodBodyStatement GetAddToQueryStatement(RawRequestUriBuilderExpression uriBuilder, RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.Value.Type, requestPart.SerializationFormat);
            if (requestPart.NameInRequest is not {} nameInRequest)
            {
                throw new InvalidOperationException($" must have ");
            }

            if (requestPart.Explode)
            {
                return new ForeachStatement("param", new EnumerableExpression(TypeFactory.GetElementType(requestPart.Value.Type), convertedValue), out var paramVariable)
                {
                    uriBuilder.AppendQuery(requestPart.NameInRequest, paramVariable, requestPart.SerializationFormat, requestPart.Escape)
                };
            }

            return requestPart.ArraySerializationDelimiter is { } delimiter
                ? uriBuilder.AppendQueryDelimited(nameInRequest, convertedValue, delimiter, requestPart.SerializationFormat, requestPart.Escape)
                : uriBuilder.AppendQuery(nameInRequest, convertedValue, requestPart.SerializationFormat, requestPart.Escape);
        }

        private static MethodBodyStatement GetAddHeaderStatement(RequestExpression request, RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.Value.Type, requestPart.SerializationFormat);
            if (requestPart.NameInRequest is null)
            {
                return requestPart.SerializationFormat == SerializationFormat.Default
                    ? request.Headers.Add(convertedValue)
                    : request.Headers.Add(convertedValue, requestPart.SerializationFormat);
            }

            if (requestPart.NameInRequest.Equals(SpecialHandledHeaders.ClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return request.Headers.Add(SpecialHandledHeaders.ClientRequestId, request.ClientRequestId);
            }

            return requestPart.ArraySerializationDelimiter is {} delimiter
                ? request.Headers.AddDelimited(requestPart.NameInRequest, convertedValue, delimiter, requestPart.SerializationFormat)
                : request.Headers.Add(requestPart.NameInRequest, convertedValue, requestPart.SerializationFormat);
        }

        private static MethodBodyStatement GetAddMultipartBodyPartStatement(MultipartFormDataContentExpression multipartContent, RequestPart requestPart)
        {
            var nameInRequest = requestPart.NameInRequest!;
            var value = requestPart.Value;
            if (!TypeFactory.IsList(value.Type))
            {
                return multipartContent.Add(new RequestContentExpression(value), nameInRequest, Null);
            }

            return new ForeachStatement("value", new EnumerableExpression(TypeFactory.GetElementType(value.Type), requestPart.Value), out var item)
            {
                multipartContent.Add(RequestContentExpression.Create(item), nameInRequest, Null)
            };
        }

        private static StringExpression ConvertToString(TypedValueExpression value)
        {
            if (value.Type is { IsFrameworkType: false, Implementation: EnumType enumType })
            {
                return new EnumExpression(enumType, value.NullableStructValue(value.Type)).ToSerial();
            }

            return value.Type.EqualsIgnoreNullable(typeof(string)) ? new(value) : value.NullableStructValue(value.Type).InvokeToString();
        }

        private static MethodBodyStatement NullCheckRequestPartValue(RequestPart requestPart, MethodBodyStatement addRequestPartStatement)
        {
            if (requestPart.SkipNullCheck)
            {
                return addRequestPartStatement;
            }

            var value = requestPart.Value;
            var type = requestPart.Value.Type;
            if (value is ConstantExpression)
            {
                return addRequestPartStatement;
            }

            if (requestPart.CheckUndefinedCollection && TypeFactory.IsCollectionType(type))
            {
                return new IfElseStatement(And(NotEqual(value, Null), InvokeOptional.IsCollectionDefined(value)), addRequestPartStatement, null);
            }

            if (type.IsNullable)
            {
                return new IfElseStatement(NotEqual(value, Null), addRequestPartStatement, null);
            }

            return addRequestPartStatement;

        }

        private static ValueExpression ConvertToRequestPartType(ValueExpression value, CSharpType fromType, SerializationFormat format = SerializationFormat.Default, bool convertOnlyExtendableEnumToString = false)
        {
            if (fromType is { IsFrameworkType: false, Implementation: EnumType enumType } && (!convertOnlyExtendableEnumToString || enumType.IsExtensible))
            {
                return new EnumExpression(enumType, value.NullableStructValue(fromType)).ToSerial();
            }

            if (value is ConstantExpression)
            {
                return value;
            }

            if (fromType.EqualsIgnoreNullable(typeof(ContentType)))
            {
                return value.NullableStructValue(fromType).InvokeToString();
            }

            if (fromType.EqualsIgnoreNullable(typeof(BinaryData)) && format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
            {
                return new BinaryDataExpression(value).ToArray();
            }

            return value.NullableStructValue(fromType);
        }
    }
}
