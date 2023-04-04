// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonElementExpression(ValueExpression Untyped) : TypedValueExpression(typeof(JsonElement), Untyped)
    {
        public ValueExpression CallClone() => Call.Instance(Untyped, nameof(JsonElement.Clone));
        public ValueExpression EnumerateArray() => Call.Instance(Untyped, nameof(JsonElement.EnumerateArray));
        public ValueExpression EnumerateObject() => Call.Instance(Untyped, nameof(JsonElement.EnumerateObject));
        public ValueExpression GetBoolean() => Call.Instance(Untyped, nameof(JsonElement.GetBoolean));
        public ValueExpression GetBytesFromBase64(string? format) => Call.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetBytesFromBase64), Untyped, Literal(format));
        public ValueExpression GetChar() => Call.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetChar), Untyped);
        public ValueExpression GetDateTimeOffset(string? format) => Call.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetDateTimeOffset), Untyped, Literal(format));
        public ValueExpression GetDateTime() => Call.Instance(Untyped, nameof(JsonElement.GetDateTime));
        public ValueExpression GetDecimal() => Call.Instance(Untyped, nameof(JsonElement.GetDecimal));
        public ValueExpression GetDouble() => Call.Instance(Untyped, nameof(JsonElement.GetDouble));
        public ValueExpression GetGuid() => Call.Instance(Untyped, nameof(JsonElement.GetGuid));
        public ValueExpression GetInt16() => Call.Instance(Untyped, nameof(JsonElement.GetInt16));
        public ValueExpression GetInt32() => Call.Instance(Untyped, nameof(JsonElement.GetInt32));
        public ValueExpression GetInt64() => Call.Instance(Untyped, nameof(JsonElement.GetInt64));
        public ValueExpression GetObject() => Call.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetObject), Untyped);
        public StringExpression GetRawText() => new(Call.Instance(Untyped, nameof(JsonElement.GetRawText)));
        public ValueExpression GetSingle() => Call.Instance(Untyped, nameof(JsonElement.GetSingle));
        public StringExpression GetString() => new(Call.Instance(Untyped, nameof(JsonElement.GetString)));
        public ValueExpression GetTimeSpan(string? format) => Call.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetTimeSpan), Untyped, Literal(format));

        public ValueExpression ValueKindEqualsNull()
            => new BinaryOperatorExpression("==", new MemberReference(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.Null));

        public ValueExpression ValueKindEqualsString()
            => new BinaryOperatorExpression("==", new MemberReference(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.String));

        public MethodBodyStatement WriteTo(ValueExpression writer) => new InvokeInstanceMethodStatement(Untyped, nameof(JsonElement.WriteTo), new[]{writer}, false);

        public ValueExpression TryGetProperty(string elementName, string propertyName, out JsonElementExpression discriminator)
        {
            var discriminatorDeclaration = new CodeWriterDeclaration("discriminator");
            discriminator = new JsonElementExpression(discriminatorDeclaration);
            return new FormattableStringToExpression($"{elementName}.{nameof(System.Text.Json.JsonElement.TryGetProperty)}({propertyName:L}, out {typeof(JsonElement)} {discriminatorDeclaration:D})");
        }
    }
}
