// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class RequestPartBuilder
    {
        private static readonly HashSet<string> ContentHeaders = new(StringComparer.OrdinalIgnoreCase)
        {
            "Allow",
            "Content-Disposition",
            "Content-Encoding",
            "Content-Language",
            "Content-Length",
            "Content-Location",
            "Content-MD5",
            "Content-Range",
            "Content-Type",
            "Expires",
            "Last-Modified",
        };

        private readonly List<RequestPart> _uriParts;
        private readonly List<RequestPart> _pathParts;
        private readonly List<RequestPart> _queryParts;
        private readonly List<RequestPart> _headerParts;
        private readonly List<RequestPart> _contentHeaderParts;
        private readonly List<RequestPart> _bodyParts;

        public RequestPartBuilder()
        {
            _uriParts = new List<RequestPart>();
            _pathParts = new List<RequestPart>();
            _queryParts = new List<RequestPart>();
            _headerParts = new List<RequestPart>();
            _contentHeaderParts = new List<RequestPart>();
            _bodyParts = new List<RequestPart>();
        }

        public RequestParts BuildParts()
            => new(_uriParts, _pathParts, _queryParts, _headerParts, _contentHeaderParts, _bodyParts);

        public void AddUriPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _uriParts.Add(new RequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type), Escape: !inputParameter.SkipUrlEncoding));
        }

        public void AddPathPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _pathParts.Add(new RequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type), Escape: !inputParameter.SkipUrlEncoding));
        }

        public void AddQueryPart(InputParameter inputParameter, TypedValueExpression value, bool skipNullCheck)
        {
            _queryParts.Add
            (
                new RequestPart
                (
                    inputParameter.NameInRequest,
                    value,
                    null,
                    SerializationBuilder.GetSerializationFormat(inputParameter.Type),
                    inputParameter.ArraySerializationDelimiter,
                    Explode: inputParameter.Explode,
                    Escape: !inputParameter.SkipUrlEncoding,
                    SkipNullCheck: skipNullCheck,
                    CheckUndefinedCollection: true
                )
            );
        }

        public void AddNonParameterizedHeaderPart(InputParameter inputParameter)
        {
            var value = GetNonParameterizedHeaderValue(inputParameter.NameInRequest);
            _headerParts.Add(new RequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type)));
        }

        public void AddMatchConditionsHeaderPart(Parameter outputParameter, SerializationFormat serializationFormat)
        {
            _headerParts.Add(new RequestPart(null, outputParameter, null, serializationFormat));
        }

        public void AddRequestConditionsHeaderPart(Parameter outputParameter, SerializationFormat serializationFormat)
        {
            _headerParts.Add(new RequestPart(null, outputParameter, null, serializationFormat));
        }

        public void AddHeaderPart(InputParameter inputParameter, TypedValueExpression value, SerializationFormat serializationFormat)
        {
            if (ContentHeaders.Contains(inputParameter.NameInRequest))
            {
                _contentHeaderParts.Add(new RequestPart(inputParameter.HeaderCollectionPrefix ?? inputParameter.NameInRequest, value, null, serializationFormat, inputParameter.ArraySerializationDelimiter));
            }
            else
            {
                _headerParts.Add(new RequestPart(inputParameter.HeaderCollectionPrefix ?? inputParameter.NameInRequest, value, null, serializationFormat, inputParameter.ArraySerializationDelimiter));
            }
        }

        public void AddBodyPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _bodyParts.Add(new RequestPart(inputParameter.NameInRequest, value, null, SerializationFormat.Default));
        }

        public void AddBodyPart(TypedValueExpression value, MethodBodyStatement? conversions, RequestContentExpression content, bool skipNullCheck)
        {
            _bodyParts.Add(new BodyRequestPart(value, content, conversions, SkipNullCheck: skipNullCheck));
        }

        private static TypedValueExpression GetNonParameterizedHeaderValue(string nameInRequest)
        {
            if (nameInRequest.Equals(SpecialHandledHeaders.ClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return Literal(null);
            }

            if (nameInRequest.Equals(SpecialHandledHeaders.ReturnClientRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return Literal("true");
            }

            if (nameInRequest.Equals(SpecialHandledHeaders.RepeatabilityRequestId, StringComparison.OrdinalIgnoreCase))
            {
                return GuidExpression.NewGuid();
            }

            if (nameInRequest.Equals(SpecialHandledHeaders.RepeatabilityFirstSent, StringComparison.OrdinalIgnoreCase))
            {
                return DateTimeOffsetExpression.Now;
            }

            throw new InvalidOperationException($"Unknown non-parameterized header {nameInRequest}.");
        }
    }
}
