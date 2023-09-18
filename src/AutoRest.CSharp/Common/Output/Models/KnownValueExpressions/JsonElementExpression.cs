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
        public JsonElementExpression(TypedValueExpression typed) : this(ValidateType(typed, typeof(JsonElement))) {}
        public JsonElementExpression(CodeWriterDeclaration declaration) : this(new VariableReference(typeof(JsonElement), declaration)) {}

        public EnumerableExpression EnumerateArray() => new(typeof(JsonElement), Untyped.Invoke(nameof(JsonElement.EnumerateArray)));
        public EnumerableExpression EnumerateObject() => new(typeof(JsonProperty), Untyped.Invoke(nameof(JsonElement.EnumerateObject)));
        public JsonElementExpression this[int index] =>new(new IndexerExpression(Untyped, Int(index)));
        public JsonElementExpression GetProperty(string propertyName) => new(Untyped.Invoke(nameof(JsonElement.GetProperty), Literal(propertyName)));

        public ValueExpression InvokeClone() => Untyped.Invoke(nameof(JsonElement.Clone));
        public ValueExpression GetBoolean() => Untyped.Invoke(nameof(JsonElement.GetBoolean));
        public ValueExpression GetBytesFromBase64(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetBytesFromBase64), Untyped, Literal(format));
        public ValueExpression GetChar() => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetChar), Untyped);
        public ValueExpression GetDateTimeOffset(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetDateTimeOffset), Untyped, Literal(format));
        public ValueExpression GetDateTime() => Untyped.Invoke(nameof(JsonElement.GetDateTime));
        public ValueExpression GetDecimal() => Untyped.Invoke(nameof(JsonElement.GetDecimal));
        public ValueExpression GetDouble() => Untyped.Invoke(nameof(JsonElement.GetDouble));
        public ValueExpression GetGuid() => Untyped.Invoke(nameof(JsonElement.GetGuid));
        public ValueExpression GetInt16() => Untyped.Invoke(nameof(JsonElement.GetInt16));
        public ValueExpression GetInt32() => Untyped.Invoke(nameof(JsonElement.GetInt32));
        public ValueExpression GetInt64() => Untyped.Invoke(nameof(JsonElement.GetInt64));
        public ValueExpression GetObject() => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetObject), Untyped);
        public StringExpression GetRawText() => new(Untyped.Invoke(nameof(JsonElement.GetRawText)));
        public ValueExpression GetSingle() => Untyped.Invoke(nameof(JsonElement.GetSingle));
        public StringExpression GetString() => new(Untyped.Invoke(nameof(JsonElement.GetString)));
        public ValueExpression GetTimeSpan(string? format) => InvokeStaticMethodExpression.Extension(typeof(JsonElementExtensions), nameof(JsonElementExtensions.GetTimeSpan), Untyped, Literal(format));

        public BoolExpression ValueKindEqualsNull()
            => new(new BinaryOperatorExpression("==", new MemberExpression(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.Null)));

        public BoolExpression ValueKindEqualsString()
            => new(new BinaryOperatorExpression("==", new MemberExpression(Untyped, nameof(JsonElement.ValueKind)), FrameworkEnumValue(JsonValueKind.String)));

        public MethodBodyStatement WriteTo(ValueExpression writer) => new InvokeInstanceMethodStatement(Untyped, nameof(JsonElement.WriteTo), new[]{writer}, false);

        public BoolExpression TryGetProperty(string elementName, string propertyName, out JsonElementExpression discriminator)
        {
            var discriminatorDeclaration = new VariableReference(typeof(JsonElement), "discriminator");
            discriminator = new JsonElementExpression(discriminatorDeclaration);
            return new BoolExpression(new FormattableStringToExpression($"{elementName}.{nameof(System.Text.Json.JsonElement.TryGetProperty)}({propertyName:L}, out {typeof(JsonElement)} {discriminatorDeclaration.Declaration:D})"));
        }
    }
}
