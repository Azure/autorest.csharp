// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal record RestClientMethodParameters
    (
        RequestParts RequestParts,
        IReadOnlyList<Parameter> CreateMessage,
        IReadOnlyList<Parameter> Protocol,
        IReadOnlyList<Parameter> Convenience,
        IReadOnlyDictionary<Parameter, ValueExpression> Arguments,
        IReadOnlyDictionary<Parameter, MethodBodyStatement> Conversions,
        bool HasAmbiguityBetweenProtocolAndConvenience
    )
    {
        public RestClientMethodParameters MakeAllProtocolParametersRequired()
        {
            var protocol = new List<Parameter>();
            var arguments = new Dictionary<Parameter, ValueExpression>();
            var conversions = new Dictionary<Parameter, MethodBodyStatement>();

            foreach (var parameter in Protocol)
            {
                var updatedParameter = parameter with { DefaultValue = null };
                if (Arguments.TryGetValue(parameter, out var argument))
                {
                    arguments[updatedParameter] = argument;
                }
                if (Conversions.TryGetValue(parameter, out var conversion))
                {
                    conversions[updatedParameter] = conversion;
                }
                protocol.Add(updatedParameter);
            }

            return this with
            {
                Protocol = protocol,
                Arguments = arguments,
                Conversions = conversions,
                HasAmbiguityBetweenProtocolAndConvenience = false
            };
        }
    }

    internal record RequestParts(IReadOnlyList<RequestPart> UriParts, IReadOnlyList<RequestPart> PathParts, IReadOnlyList<RequestPart> QueryParts, IReadOnlyList<RequestPart> HeaderParts, IReadOnlyList<RequestPart> ContentHeaderParts, IReadOnlyList<RequestPart> BodyParts);

    internal record RequestPart(string? NameInRequest, TypedValueExpression Value, MethodBodyStatement? Conversion, SerializationFormat SerializationFormat, string? ArraySerializationDelimiter = null, bool Explode = false, bool Escape = false, bool SkipNullCheck = false, bool CheckUndefinedCollection = false);

    internal record BodyRequestPart(TypedValueExpression Value, RequestContentExpression Content, MethodBodyStatement? Conversion, bool SkipNullCheck = false) : RequestPart(null, Value, Conversion, SerializationFormat.Default, SkipNullCheck: SkipNullCheck);
}
