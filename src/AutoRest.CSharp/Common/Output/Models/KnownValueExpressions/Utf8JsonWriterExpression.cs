// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record Utf8JsonWriterExpression(ValueExpression Untyped) : ValueExpression<Utf8JsonWriter>(Untyped)
    {
        public MethodBodyLine WriteStartObject() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStartObject), Array.Empty<ValueExpression>(), false);
        public MethodBodyLine WriteEndObject() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteEndObject), Array.Empty<ValueExpression>(), false);
        public MethodBodyLine WriteStartArray() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStartArray), Array.Empty<ValueExpression>(), false);
        public MethodBodyLine WriteEndArray() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteEndArray), Array.Empty<ValueExpression>(), false);
        public MethodBodyLine WritePropertyName(string propertyName) => WritePropertyName(LiteralU8(propertyName));
        public MethodBodyLine WritePropertyName(ValueExpression propertyName) => new InstanceMethodCallLine(Untyped, nameof(System.Text.Json.Utf8JsonWriter.WritePropertyName), new[]{propertyName}, false);
        public MethodBodyLine WriteNull(string propertyName) => WriteNull(Literal(propertyName));
        public MethodBodyLine WriteNull(ValueExpression propertyName) => new InstanceMethodCallLine(Untyped, nameof(System.Text.Json.Utf8JsonWriter.WriteNull), new[]{propertyName}, false);
        public MethodBodyLine WriteNullValue() => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteNullValue), Array.Empty<ValueExpression>(), false);

        public MethodBodyLine WriteNumberValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteNumberValue), new[]{value}, false);

        public MethodBodyLine WriteStringValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteStringValue), new[]{value}, false);

        public MethodBodyLine WriteBooleanValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteBooleanValue), new[]{value}, false);

        public MethodBodyLine WriteRawValue(ValueExpression value)
            => new InstanceMethodCallLine(Untyped, nameof(Utf8JsonWriter.WriteRawValue), new[]{value}, false);

        public MethodBodyLine WriteNumberValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteNumberValue), new[]{Untyped, value, Literal(format)}, null, true);

        public MethodBodyLine WriteStringValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteStringValue), new[]{Untyped, value, Literal(format)}, null, true);

        public MethodBodyLine WriteObjectValue(ValueExpression value)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteObjectValue), new[]{Untyped, value}, null, true);

        public MethodBodyLine WriteBase64StringValue(ValueExpression value, string? format)
            => new StaticMethodCallLine(typeof(Utf8JsonWriterExtensions), nameof(Utf8JsonWriterExtensions.WriteBase64StringValue), new[]{Untyped, value, Literal(format)}, null, true);
    }
}
