// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonPropertyExpression(ValueExpression Untyped) : ValueExpression<JsonProperty>(Untyped)
    {
        public ValueExpression<string> Name { get; } = new(new MemberReference(Untyped, nameof(JsonProperty.Name)));
        public JsonElementExpression Value { get; } = new(new MemberReference(Untyped, nameof(JsonProperty.Value)));

        public ValueExpression NameEquals(string value) => Call.Instance(Untyped, nameof(JsonProperty.NameEquals), LiteralU8(value));

        public MethodBodyLine ThrowNonNullablePropertyIsNull()
            => new StaticMethodCallLine(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.ThrowNonNullablePropertyIsNull), new[]{Untyped}, CallAsExtension: true);
    }
}
