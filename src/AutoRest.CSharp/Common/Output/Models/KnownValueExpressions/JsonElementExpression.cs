// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonElementExpression(ValueExpression Untyped) : ValueExpression<JsonElement>(Untyped)
    {
        public ValueExpression CallClone() => Call.Instance(Untyped, nameof(JsonElement.Clone));
        public ValueExpression EnumerateArray() => Call.Instance(Untyped, nameof(JsonElement.EnumerateArray));
        public ValueExpression EnumerateObject() => Call.Instance(Untyped, nameof(JsonElement.EnumerateObject));
        public ValueExpression GetBoolean() => Call.Instance(Untyped, nameof(JsonElement.GetBoolean));
        public ValueExpression GetBytesFromBase64(string? format) => Call.Extension(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.GetBytesFromBase64), Untyped, Literal(format));
        public ValueExpression GetChar() => Call.Extension(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.GetChar), Untyped);
        public ValueExpression GetDateTimeOffset(string? format) => Call.Extension(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.GetDateTimeOffset), Untyped, Literal(format));
        public ValueExpression GetDateTime() => Call.Instance(Untyped, nameof(JsonElement.GetDateTime));
        public ValueExpression GetDecimal() => Call.Instance(Untyped, nameof(JsonElement.GetDecimal));
        public ValueExpression GetDouble() => Call.Instance(Untyped, nameof(JsonElement.GetDouble));
        public ValueExpression GetGuid() => Call.Instance(Untyped, nameof(JsonElement.GetGuid));
        public ValueExpression GetInt16() => Call.Instance(Untyped, nameof(JsonElement.GetInt16));
        public ValueExpression GetInt32() => Call.Instance(Untyped, nameof(JsonElement.GetInt32));
        public ValueExpression GetInt64() => Call.Instance(Untyped, nameof(JsonElement.GetInt64));
        public ValueExpression GetObject() => Call.Extension(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.GetObject), Untyped);
        public ValueExpression GetRawText() => Call.Instance(Untyped, nameof(JsonElement.GetRawText));
        public ValueExpression GetSingle() => Call.Instance(Untyped, nameof(JsonElement.GetSingle));
        public ValueExpression GetString() => Call.Instance(Untyped, nameof(JsonElement.GetString));
        public ValueExpression GetTimeSpan(string? format) => Call.Extension(typeof(Azure.Core.JsonElementExtensions), nameof(Azure.Core.JsonElementExtensions.GetTimeSpan), Untyped, Literal(format));

        public ValueExpression ValueKindEqualsNull()
            => new BinaryOperatorExpression("==", new MemberReference(Untyped, nameof(JsonElement.ValueKind)), new FormattableStringToExpression($"{typeof(JsonValueKind)}.{nameof(JsonValueKind.Null)}"));

        public ValueExpression ValueKindEqualsString()
            => new BinaryOperatorExpression("==", new MemberReference(Untyped, nameof(JsonElement.ValueKind)), new FormattableStringToExpression($"{typeof(JsonValueKind)}.{nameof(JsonValueKind.String)}"));
    }
}
