// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoRest.CSharp.Common.Input
{
    internal static class Utf8JsonWriterExtensions
    {
        public static void WriteStringIfPresent(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, string? value)
        {
            if (value == null)
            {
                return;
            }
            writer.WriteString(propertyName, value);
        }

        public static void WriteArray<T>(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, IEnumerable<T> value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteArrayValue(value, options);
        }

        public static void WriteArrayValue<T>(this Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var item in value)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }

        public static void WriteObjectIfPresent<T>(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, T? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                return;
            }
            writer.WriteObject(propertyName, value, options);
        }

        public static void WriteObject<T>(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, T? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                writer.WriteNull(propertyName);
            }
            else
            {
                writer.WritePropertyName(propertyName);
                writer.WriteObjectValue(value, options);
            }
        }

        public static void WriteObjectValue<T>(this Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var converter = (JsonConverter<T>)options.GetConverter(typeof(T));
            converter.Write(writer, value, options);
        }

        public static void WriteReferenceId(this Utf8JsonWriter writer, string id)
            => writer.WriteString("$id", id);

        public static void WriteObjectReference(this Utf8JsonWriter writer, string id)
        {
            writer.WriteStartObject();
            writer.WriteString("$ref", id);
            writer.WriteEndObject();
        }
    }
}
