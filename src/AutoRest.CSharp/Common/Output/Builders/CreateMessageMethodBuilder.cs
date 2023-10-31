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
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using ContentType = Azure.Core.ContentType;
using RequestMethod = Azure.Core.RequestMethod;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal abstract class CreateMessageMethodBuilder
    {
        public abstract TypedValueExpression Message { get; }

        private readonly RequestParts _requestParts;

        protected CreateMessageMethodBuilder(RequestParts requestParts)
        {
            _requestParts = requestParts;
        }

        public static MethodBodyStatement CreateHttpMessage(ClientFields fields, RequestParts requestParts, RequestMethod requestMethod, TypedValueExpression? requestContext, bool bufferResponse, ResponseClassifierType? responseClassifierType, out CreateMessageMethodBuilder builder)
        {
            MethodBodyStatement statement;
            builder = Configuration.IsBranded
                ? Azure.AzureCreateMessageMethodBuilder.CreateBuilder(fields, requestParts, requestMethod, requestContext, bufferResponse, responseClassifierType, out statement)
                : System.SystemCreateMessageMethodBuilder.CreateBuilder(fields, requestParts, requestMethod.Method, requestContext, bufferResponse, responseClassifierType, out statement);

            return statement;
        }

        protected abstract MethodBodyStatement Reset(TypedValueExpression value);
        protected abstract MethodBodyStatement AppendUri(string literal);
        protected abstract MethodBodyStatement AppendUri(TypedValueExpression value, bool escape);
        protected abstract MethodBodyStatement AppendPath(string literal);
        protected abstract MethodBodyStatement AppendPath(TypedValueExpression value, SerializationFormat format, bool escape);
        protected abstract MethodBodyStatement AddQuery(string nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format, bool escape);
        protected abstract MethodBodyStatement AddHeader(string? nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format);
        protected abstract MethodBodyStatement AddMultipartBody();
        protected abstract MethodBodyStatement AddFormUrlEncodedBody();
        protected abstract MethodBodyStatement AddBody(BodyRequestPart bodyRequestPart);

        public MethodBodyStatement AddUri(string uri)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uri))
            {
                if (isLiteral)
                {
                    lines.Add(AppendUri( span.ToString()));
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
                        lines.Add(requestPart.Value.Type.Equals(typeof(Uri)) ? Reset(requestPart.Value) : AppendUri(ConvertToRequestPartType(requestPart.Value, convertOnlyExtendableEnumToString: true), requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{uri}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }

                }
            }
            return lines;
        }

        public MethodBodyStatement AddPath(string path)
        {
            var lines = new List<MethodBodyStatement>();
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(path))
            {
                if (isLiteral)
                {
                    lines.Add(AppendPath(span.ToString()));
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
                        lines.Add(requestPart.Value is not ConstantExpression && requestPart.IsNextLink
                            ? AppendRawNextLink(requestPart.Value, requestPart.Escape)
                            : AppendPath(ConvertToRequestPartType(requestPart.Value, requestPart.SerializationFormat), requestPart.SerializationFormat, requestPart.Escape));
                    }
                    else
                    {
                        ErrorHelpers.ThrowError($"\n\nError while processing request '{path}'\n\n  '{span.ToString()}' in URI is missing a matching definition in the path parameters collection{ErrorHelpers.UpdateSwaggerOrFile}");
                    }
                }
            }
            return lines;
        }

        public MethodBodyStatement AddQuery()
            => _requestParts.QueryParts.Select(rp => NullCheckRequestPartValue(rp, GetAddToQueryStatement(rp))).AsStatement();

        public MethodBodyStatement AddHeaders()
            => _requestParts.HeaderParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(rp))).AsStatement();

        public MethodBodyStatement AddContentHeaders()
            => _requestParts.ContentHeaderParts.Select(rp => NullCheckRequestPartValue(rp, GetAddHeaderStatement(rp))).AsStatement();

        public MethodBodyStatement AddBody(BodyMediaType bodyMediaType)
        {
            if (_requestParts.BodyParts is [BodyRequestPart bodyRequestPart])
            {
                return NullCheckRequestPartValue(bodyRequestPart, new[] { AddContentHeaders(), AddBody(bodyRequestPart) });
            }

            return bodyMediaType switch
            {
                BodyMediaType.Multipart => new[] { AddContentHeaders(), AddMultipartBody() },
                BodyMediaType.Form => new[] { AddContentHeaders(), AddFormUrlEncodedBody() },
                _ => new MethodBodyStatement()
            };
        }

        public abstract MethodBodyStatement AppendRawNextLink(TypedValueExpression value, bool escape);
        public abstract MethodBodyStatement SetUriToRequest();
        public abstract MethodBodyStatement AddUserAgent();

        private MethodBodyStatement GetAddToQueryStatement(RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.SerializationFormat);
            if (requestPart.NameInRequest is not {} nameInRequest)
            {
                throw new InvalidOperationException($" must have ");
            }

            if (requestPart.Explode)
            {
                return new ForeachStatement("param", new EnumerableExpression(TypeFactory.GetElementType(requestPart.Value.Type), convertedValue), out var paramVariable)
                {
                    AddQuery(requestPart.NameInRequest, paramVariable, null, requestPart.SerializationFormat, requestPart.Escape)
                };
            }

            return AddQuery(nameInRequest, convertedValue, requestPart.ArraySerializationDelimiter, requestPart.SerializationFormat, requestPart.Escape);
        }

        private MethodBodyStatement GetAddHeaderStatement(RequestPart requestPart)
        {
            var convertedValue = ConvertToRequestPartType(RemoveAllNullConditional(requestPart.Value), requestPart.SerializationFormat);
            return AddHeader(requestPart.NameInRequest, convertedValue, requestPart.ArraySerializationDelimiter, requestPart.SerializationFormat);
        }

        protected static MethodBodyStatement NullCheckRequestPartValue(RequestPart requestPart, MethodBodyStatement addRequestPartStatement)
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
                return new IfStatement(And(NotEqual(value, Null), InvokeOptional.IsCollectionDefined(value))) {addRequestPartStatement};
            }

            if (type.IsNullable)
            {
                return new IfStatement(NotEqual(value, Null)) {addRequestPartStatement};
            }

            return addRequestPartStatement;

        }

        private static TypedValueExpression ConvertToRequestPartType(TypedValueExpression value, SerializationFormat format = SerializationFormat.Default, bool convertOnlyExtendableEnumToString = false)
        {
            if (value.Type is { IsFrameworkType: false, Implementation: EnumType enumType } && (!convertOnlyExtendableEnumToString || enumType.IsExtensible))
            {
                return new EnumExpression(enumType, value.NullableStructValue(value.Type)).ToSerial();
            }

            if (value is ConstantExpression)
            {
                return value;
            }

            if (value.Type.EqualsIgnoreNullable(typeof(ContentType)))
            {
                return value.NullableStructValue(value.Type).InvokeToString();
            }

            if (value.Type.EqualsIgnoreNullable(typeof(BinaryData)) && format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
            {
                return new BinaryDataExpression(value).ToArray();
            }

            return value.NullableStructValue();
        }
    }
}
