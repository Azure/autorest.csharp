// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders.Azure
{
    internal class AzureCreateMessageMethodBuilder : CreateMessageMethodBuilder
    {
        public static CreateMessageMethodBuilder CreateBuilder(ClientFields fields, RequestParts requestParts, RequestMethod requestMethod, TypedValueExpression? requestContext, bool bufferResponse, ResponseClassifierType? responseClassifierType, out MethodBodyStatement createMessageStatement)
        {
            var pipeline = new HttpPipelineExpression(fields.PipelineField);

            var callPipelineCreateMessage = requestContext is not null
                ? responseClassifierType is not null
                    ? pipeline.CreateMessage(new RequestContextExpression(requestContext), new MemberExpression(null, responseClassifierType.Name))
                    : pipeline.CreateMessage(new RequestContextExpression(requestContext))
                : pipeline.CreateMessage();

            var statements = new List<MethodBodyStatement>
            {
                Var("message", callPipelineCreateMessage, out var message),
                Var("request", message.Request, out var request)
            };

            if (!bufferResponse)
            {
                statements.Add(Assign(message.BufferResponse, False));
            }

            statements.Add(Assign(request.Method, new MemberExpression(typeof(RequestMethod), requestMethod.ToRequestMethodName())));
            statements.Add(Var("uri", New.RawRequestUriBuilder(), out RawRequestUriBuilderExpression uriBuilder));

            createMessageStatement = statements;
            return new AzureCreateMessageMethodBuilder(fields, requestParts, message, request, uriBuilder);
        }

        private readonly ClientFields _fields;
        private readonly RequestParts _requestParts;
        private readonly RawRequestUriBuilderExpression _uriBuilder;
        private readonly HttpMessageExpression _message;
        private readonly RequestExpression _request;

        public override TypedValueExpression Message => _message;

        private AzureCreateMessageMethodBuilder(ClientFields fields, RequestParts requestParts, HttpMessageExpression message, RequestExpression request, RawRequestUriBuilderExpression uriBuilder) : base(requestParts)
        {
            _fields = fields;
            _requestParts = requestParts;
            _uriBuilder = uriBuilder;
            _message = message;
            _request = request;
        }

        public override MethodBodyStatement AppendRawNextLink(TypedValueExpression value, bool escape) => _uriBuilder.AppendRawNextLink(value, false);
        public override MethodBodyStatement SetUriToRequest() => Assign(_request.Uri, _uriBuilder);

        protected override MethodBodyStatement Reset(TypedValueExpression value) => _uriBuilder.Reset(value);
        protected override MethodBodyStatement AppendUri(string literal) => _uriBuilder.AppendRaw(literal, false);
        protected override MethodBodyStatement AppendUri(TypedValueExpression value, bool escape) => _uriBuilder.AppendRaw(value, escape);
        protected override MethodBodyStatement AppendPath(string literal) => _uriBuilder.AppendPath(literal, false);
        protected override MethodBodyStatement AppendPath(TypedValueExpression value, SerializationFormat format, bool escape) => _uriBuilder.AppendPath(value, format, escape);
        protected override MethodBodyStatement AddQuery(string nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format, bool escape)
            => delimiter is not null ? _uriBuilder.AppendQueryDelimited(nameInRequest, value, delimiter, format, escape) : _uriBuilder.AppendQuery(nameInRequest, value, format, escape);

        protected override MethodBodyStatement AddHeader(string? nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format)
        {
            if (nameInRequest is null)
            {
                return format == SerializationFormat.Default
                    ? _request.Headers.Add(value)
                    : _request.Headers.Add(value, format);
            }

            if (nameInRequest.Equals(SpecialHandledHeaders.ClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return _request.Headers.Add(SpecialHandledHeaders.ClientRequestId, _request.ClientRequestId);
            }

            return delimiter is not null
                ? _request.Headers.AddDelimited(nameInRequest, value, delimiter, format)
                : _request.Headers.Add(nameInRequest, value, format);
        }

        protected override MethodBodyStatement AddMultipartBody()
            => new[]
            {
                Var("content", New.MultipartFormDataContent(), out var multipartContent),
                _requestParts.BodyParts.Select(rp => NullCheckRequestPartValue(rp, GetAddMultipartBodyPartStatement(multipartContent, rp))).AsStatement(),
                multipartContent.ApplyToRequest(_request)
            };

        protected override MethodBodyStatement AddFormUrlEncodedBody()
            => new[]
            {
                Var("content", New.FormUrlEncodedContent(), out var urlContent),
                _requestParts.BodyParts.Select(rp => NullCheckRequestPartValue(rp, urlContent.Add(rp.NameInRequest!, ConvertToString(rp.Value)))).AsStatement(),
                Assign(_request.Content, urlContent)
            };

        protected override MethodBodyStatement AddBody(BodyRequestPart bodyRequestPart)
            => new[]
            {
                bodyRequestPart.Conversion ?? new MethodBodyStatement(),
                Assign(_request.Content, new RequestContentExpression(bodyRequestPart.Content))
            };

        public override MethodBodyStatement AddUserAgent()
            => _fields.UserAgentField is not null
                ? new InvokeInstanceMethodStatement(_fields.UserAgentField, nameof(TelemetryDetails.Apply), _message)
                : new MethodBodyStatement();

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
    }
}
