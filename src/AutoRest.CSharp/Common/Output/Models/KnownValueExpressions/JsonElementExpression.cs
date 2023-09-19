// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonElementExpression(ValueExpression Untyped) : TypedValueExpression<JsonElement>(Untyped)
    {
        public EnumerableExpression EnumerateArray() => new(typeof(JsonElement), Invoke(nameof(JsonElement.EnumerateArray)));
        public EnumerableExpression EnumerateObject() => new(typeof(JsonProperty), Invoke(nameof(JsonElement.EnumerateObject)));
        public JsonElementExpression this[int index] =>new(new IndexerExpression(Untyped, Int(index)));
        public JsonElementExpression GetProperty(string propertyName) => new(Invoke(nameof(JsonElement.GetProperty), Literal(propertyName)));

        public ValueExpression InvokeClone() => Invoke(nameof(JsonElement.Clone));
        public ValueExpression GetBoolean() => Invoke(nameof(JsonElement.GetBoolean));
        public ValueExpression GetBytesFromBase64(string? format) => InvokeExtension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetBytesFromBase64), Literal(format));
        public ValueExpression GetChar() => InvokeExtension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetChar));
        public ValueExpression GetDateTimeOffset(string? format) => InvokeExtension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetDateTimeOffset), Literal(format));
        public ValueExpression GetDateTime() => Invoke(nameof(JsonElement.GetDateTime));
        public ValueExpression GetDecimal() => Invoke(nameof(JsonElement.GetDecimal));
        public ValueExpression GetDouble() => Invoke(nameof(JsonElement.GetDouble));
        public ValueExpression GetGuid() => Invoke(nameof(JsonElement.GetGuid));
        public ValueExpression GetInt16() => Invoke(nameof(JsonElement.GetInt16));
        public ValueExpression GetInt32() => Invoke(nameof(JsonElement.GetInt32));
        public ValueExpression GetInt64() => Invoke(nameof(JsonElement.GetInt64));
        public ValueExpression GetObject() => InvokeExtension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetObject));
        public StringExpression GetRawText() => new(Invoke(nameof(JsonElement.GetRawText)));
        public ValueExpression GetSingle() => Untyped.Invoke(nameof(JsonElement.GetSingle));
        public StringExpression GetString() => new(Untyped.Invoke(nameof(JsonElement.GetString)));
        public ValueExpression GetTimeSpan(string? format) => InvokeExtension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetTimeSpan), Literal(format));

        public BoolExpression ValueKindEqualsNull()
            => new(new BinaryOperatorExpression("==", Property(nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.Null)));

        public BoolExpression ValueKindEqualsString()
            => new(new BinaryOperatorExpression("==", Property(nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.String)));

        public MethodBodyStatement WriteTo(ValueExpression writer) => new InvokeInstanceMethodStatement(Untyped, nameof(JsonElement.WriteTo), new[]{writer}, false);

        public BoolExpression TryGetProperty(string elementName, string propertyName, out JsonElementExpression discriminator)
        {
            var discriminatorDeclaration = new VariableReference(typeof(JsonElement), "discriminator");
            discriminator = new JsonElementExpression(discriminatorDeclaration);
            return new BoolExpression(new FormattableStringToExpression($"{elementName}.{nameof(System.Text.Json.JsonElement.TryGetProperty)}({propertyName:L}, out {typeof(JsonElement)} {discriminatorDeclaration.Declaration:D})"));
        }
    }
}
