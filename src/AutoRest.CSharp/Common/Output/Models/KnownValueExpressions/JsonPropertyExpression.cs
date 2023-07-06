// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonPropertyExpression(ValueExpression Untyped) : TypedValueExpression(typeof(JsonProperty), Untyped)
    {
        public StringExpression Name { get; } = new(new MemberExpression(Untyped, nameof(JsonProperty.Name)));
        public JsonElementExpression Value { get; } = new(new MemberExpression(Untyped, nameof(JsonProperty.Value)));

        public BoolExpression NameEquals(string value) => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonProperty.NameEquals), LiteralU8(value)));

        public MethodBodyStatement ThrowNonNullablePropertyIsNull()
            => new InvokeStaticMethodStatement(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.ThrowNonNullablePropertyIsNull), new[]{Untyped}, CallAsExtension: true);
    }
}
