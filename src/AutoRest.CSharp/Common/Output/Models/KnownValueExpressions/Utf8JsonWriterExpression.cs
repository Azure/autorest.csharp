// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record Utf8JsonWriterExpression(ValueExpression Untyped) : TypedValueExpression(typeof(Utf8JsonWriter), Untyped)
    {
        public MethodBodyStatement WriteStartObject() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStartObject), Array.Empty<ValueExpression>(), false);
        public MethodBodyStatement WriteEndObject() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteEndObject), Array.Empty<ValueExpression>(), false);
        public MethodBodyStatement WriteStartArray() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStartArray), Array.Empty<ValueExpression>(), false);
        public MethodBodyStatement WriteEndArray() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteEndArray), Array.Empty<ValueExpression>(), false);
        public MethodBodyStatement WritePropertyName(string propertyName) => WritePropertyName(LiteralU8(propertyName));
        public MethodBodyStatement WritePropertyName(ValueExpression propertyName) => new InstanceMethodCallLine(Untyped, nameof(System.Text.Json.Utf8JsonWriter.WritePropertyName), new[]{propertyName}, false);
        public MethodBodyStatement WriteNull(string propertyName) => WriteNull(Literal(propertyName));
        public MethodBodyStatement WriteNull(ValueExpression propertyName) => new InstanceMethodCallLine(Untyped, nameof(System.Text.Json.Utf8JsonWriter.WriteNull), new[]{propertyName}, false);
        public MethodBodyStatement WriteNullValue() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteNullValue), Array.Empty<ValueExpression>(), false);

        public MethodBodyStatement WriteNumberValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteNumberValue), new[]{value}, false);

        public MethodBodyStatement WriteStringValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStringValue), new[]{value}, false);

        public MethodBodyStatement WriteBooleanValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteBooleanValue), new[]{value}, false);

        public MethodBodyStatement WriteRawValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteRawValue), new[]{value}, false);

        public MethodBodyStatement WriteNumberValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteNumberValue), new[]{Untyped, value, Literal(format)}, null, true);

        public MethodBodyStatement WriteStringValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteStringValue), new[]{Untyped, value, Literal(format)}, null, true);

        public MethodBodyStatement WriteObjectValue(ValueExpression value)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteObjectValue), new[]{Untyped, value}, null, true);

        public MethodBodyStatement WriteBase64StringValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteBase64StringValue), new[]{Untyped, value, Literal(format)}, null, true);
    }
}
