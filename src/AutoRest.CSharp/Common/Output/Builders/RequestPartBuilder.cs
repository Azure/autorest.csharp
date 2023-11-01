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

        private readonly List<PathRequestPart> _uriParts;
        private readonly List<PathRequestPart> _pathParts;
        private readonly List<QueryRequestPart> _queryParts;
        private readonly List<HeaderRequestPart> _headerParts;
        private readonly List<HeaderRequestPart> _contentHeaderParts;
        private readonly List<BodyRequestPart> _bodyParts;

        public RequestPartBuilder()
        {
            _uriParts = new List<PathRequestPart>();
            _pathParts = new List<PathRequestPart>();
            _queryParts = new List<QueryRequestPart>();
            _headerParts = new List<HeaderRequestPart>();
            _contentHeaderParts = new List<HeaderRequestPart>();
            _bodyParts = new List<BodyRequestPart>();
        }

        public RequestParts BuildParts()
            => new(_uriParts, _pathParts, _queryParts, _headerParts, _contentHeaderParts, _bodyParts);

        public void AddUriPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _uriParts.Add(new PathRequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type), Escape: !inputParameter.SkipUrlEncoding));
        }

        public void AddPathPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _pathParts.Add(new PathRequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type), Escape: !inputParameter.SkipUrlEncoding, IsNextLink: inputParameter.Name == "nextLink"));
        }

        public void AddQueryPart(InputParameter inputParameter, TypedValueExpression value, bool skipNullCheck)
        {
            _queryParts.Add
            (
                new QueryRequestPart
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
            _headerParts.Add(new HeaderRequestPart(inputParameter.NameInRequest, value, null, SerializationBuilder.GetSerializationFormat(inputParameter.Type), null));
        }

        public void AddMatchConditionsHeaderPart(Parameter outputParameter, SerializationFormat serializationFormat)
        {
            _headerParts.Add(new HeaderRequestPart(null, outputParameter, null, serializationFormat, null));
        }

        public void AddRequestConditionsHeaderPart(Parameter outputParameter, SerializationFormat serializationFormat)
        {
            _headerParts.Add(new HeaderRequestPart(null, outputParameter, null, serializationFormat, null));
        }

        public void AddHeaderPart(InputParameter inputParameter, TypedValueExpression value, SerializationFormat serializationFormat)
        {
            if (ContentHeaders.Contains(inputParameter.NameInRequest))
            {
                _contentHeaderParts.Add(new HeaderRequestPart(inputParameter.HeaderCollectionPrefix ?? inputParameter.NameInRequest, value, null, serializationFormat, inputParameter.ArraySerializationDelimiter));
            }
            else
            {
                _headerParts.Add(new HeaderRequestPart(inputParameter.HeaderCollectionPrefix ?? inputParameter.NameInRequest, value, null, serializationFormat, inputParameter.ArraySerializationDelimiter));
            }
        }

        public void AddBodyPart(InputParameter inputParameter, TypedValueExpression value)
        {
            _bodyParts.Add(new BodyRequestPart(inputParameter.NameInRequest, value, value, null, false));
        }

        public void AddBodyPart(TypedValueExpression value, MethodBodyStatement? conversions, TypedValueExpression content, bool skipNullCheck)
        {
            _bodyParts.Add(new BodyRequestPart(null, value, content, conversions, skipNullCheck));
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
