// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Writers;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record JsonElementExpression(ValueExpression Untyped) : TypedValueExpression(typeof(JsonElement), Untyped)
    {
        public EnumerableExpression EnumerateArray() => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.EnumerateArray)));
        public EnumerableExpression EnumerateObject() => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.EnumerateObject)));
        public JsonElementExpression this[int index] =>new(new IndexerExpression(Untyped, Int(index)));
        public JsonElementExpression GetProperty(string propertyName) => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetProperty), Literal(propertyName)));

        public ValueExpression CallClone() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.Clone));
        public ValueExpression GetBoolean() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetBoolean));
        public ValueExpression GetBytesFromBase64(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetBytesFromBase64), Untyped, Literal(format));
        public ValueExpression GetChar() => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetChar), Untyped);
        public ValueExpression GetDateTimeOffset(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetDateTimeOffset), Untyped, Literal(format));
        public ValueExpression GetDateTime() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetDateTime));
        public ValueExpression GetDecimal() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetDecimal));
        public ValueExpression GetDouble() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetDouble));
        public ValueExpression GetGuid() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetGuid));
        public ValueExpression GetInt16() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetInt16));
        public ValueExpression GetInt32() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetInt32));
        public ValueExpression GetInt64() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetInt64));
        public ValueExpression GetObject() => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetObject), Untyped);
        public StringExpression GetRawText() => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetRawText)));
        public ValueExpression GetSingle() => new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetSingle));
        public StringExpression GetString() => new(new InvokeInstanceMethodExpression(Untyped, nameof(JsonElement.GetString)));
        public ValueExpression GetTimeSpan(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetTimeSpan), Untyped, Literal(format));

        public BoolExpression ValueKindEqualsNull()
            => new(new BinaryOperatorExpression("==", new MemberExpression(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.Null)));

        public BoolExpression ValueKindEqualsString()
            => new(new BinaryOperatorExpression("==", new MemberExpression(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.String)));

        public MethodBodyStatement WriteTo(ValueExpression writer) => new InvokeInstanceMethodStatement(Untyped, nameof(JsonElement.WriteTo), new[]{writer}, false);

        public BoolExpression TryGetProperty(string elementName, string propertyName, out JsonElementExpression discriminator)
        {
            var discriminatorDeclaration = new CodeWriterDeclaration("discriminator");
            discriminator = new JsonElementExpression(discriminatorDeclaration);
            return new BoolExpression(new FormattableStringToExpression($"{elementName}.{nameof(System.Text.Json.JsonElement.TryGetProperty)}({propertyName:L}, out {typeof(JsonElement)} {discriminatorDeclaration:D})"));
        }
    }
}
