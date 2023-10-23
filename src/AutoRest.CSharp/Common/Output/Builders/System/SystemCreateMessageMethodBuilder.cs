// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders.System
{
    internal class SystemCreateMessageMethodBuilder : CreateMessageMethodBuilder
    {
        public static CreateMessageMethodBuilder CreateBuilder(ClientFields fields, RequestParts requestParts, string requestMethod, TypedValueExpression? requestContext, bool bufferResponse, ResponseClassifierType? responseClassifierType, out MethodBodyStatement statement)
        {
            var pipeline = new MessagePipelineExpression(fields.PipelineField);
            var options = requestContext is not null ? new RequestOptionsExpression(requestContext) : throw new ArgumentNullException(nameof(requestContext));
            var responseClassifier = responseClassifierType is not null ? new MemberExpression(null, responseClassifierType.Name) : throw new ArgumentNullException(nameof(responseClassifierType));

            var messageVar = new VariableReference(typeof(PipelineMessage), "message");
            var message = new PipelineMessageExpression(messageVar);
            var requestVar = new VariableReference(typeof(PipelineRequest), "request");
            var request = new PipelineRequestExpression(requestVar);
            var uriVar = new VariableReference(typeof(RequestUri), "uri");
            var uri = new RequestUriExpression(uriVar);

            statement = new[]
            {
                Var(messageVar, pipeline.CreateMessage(options, responseClassifier)),
                Var(requestVar, message.Request),
                request.SetMethod(requestMethod),
                Var(uriVar, New.Instance(typeof(RequestUri))),
            };

            return new SystemCreateMessageMethodBuilder(requestParts, message, request, uri);
        }

        private readonly PipelineMessageExpression _message;
        private readonly PipelineRequestExpression _request;
        private readonly RequestUriExpression _requestUri;

        public override TypedValueExpression Message => _message;

        private SystemCreateMessageMethodBuilder(RequestParts requestParts, PipelineMessageExpression message, PipelineRequestExpression request, RequestUriExpression requestUri) : base(requestParts)
        {
            _message = message;
            _request = request;
            _requestUri = requestUri;
        }

        public override MethodBodyStatement AppendRawNextLink(TypedValueExpression value, bool escape) => _requestUri.AppendRawPathOrQueryOrHostOrScheme(value, escape);
        public override MethodBodyStatement SetUriToRequest() => Assign(_request.Uri, _requestUri.ToUri());

        protected override MethodBodyStatement Reset(TypedValueExpression value) => _requestUri.Reset(value);
        protected override MethodBodyStatement AppendUri(string literal) => _requestUri.AppendRawPathOrQueryOrHostOrScheme(literal, false);
        protected override MethodBodyStatement AppendUri(TypedValueExpression value, bool escape) => _requestUri.AppendRawPathOrQueryOrHostOrScheme(value, escape);
        protected override MethodBodyStatement AppendPath(string literal) => _requestUri.AppendPath(literal, false);
        protected override MethodBodyStatement AppendPath(TypedValueExpression value, SerializationFormat format, bool escape) => _requestUri.AppendPath(value, format, escape);

        protected override MethodBodyStatement AddQuery(string nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format, bool escape)
            => delimiter is not null ? _requestUri.AppendQueryDelimited(nameInRequest, value, delimiter, format, escape) : _requestUri.AppendQuery(nameInRequest, value, format, escape);

        protected override MethodBodyStatement AddHeader(string? nameInRequest, TypedValueExpression value, string? delimiter, SerializationFormat format)
        {
            if (nameInRequest is null)
            {
                throw new ArgumentNullException(nameof(nameInRequest), "Special typed header types like MatchCondition aren't supported in unbranded");
            }

            if (delimiter is null)
            {
                var stringValue = format.ToFormatSpecifier() is {} formatSpecifier
                    ? new StringExpression(value.Invoke(nameof(ToString), Literal(formatSpecifier)))
                    : value.Type.EqualsIgnoreNullable(typeof(string)) ? new StringExpression(value) : value.InvokeToString();

                return _request.SetHeaderValue(nameInRequest, stringValue);
            }

            throw new NotImplementedException("Headers with delimiters aren't supported in unbranded yet.");
        }

        protected override MethodBodyStatement AddMultipartBody() => throw new NotSupportedException("Multipart body is not supported in unbranded.");
        protected override MethodBodyStatement AddFormUrlEncodedBody() => throw new NotSupportedException("Form URL body is not supported in unbranded.");

        protected override MethodBodyStatement AddBody(BodyRequestPart bodyRequestPart)
            => new[]
            {
                bodyRequestPart.Conversion ?? new MethodBodyStatement(),
                Assign(_request.Content, new RequestBodyExpression(bodyRequestPart.Content))
            };

        public override MethodBodyStatement AddUserAgent() => new();
    }
}
