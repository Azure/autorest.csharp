// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using static AutoRest.CSharp.Common.Input.Configuration;

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

        public static void WriteDictionary<T>(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, IEnumerable<KeyValuePair<string, T>> dict, JsonSerializerOptions options) where T : notnull
        {
            writer.WritePropertyName(propertyName);
            writer.WriteDictionaryValue(dict, options);
        }

        public static void WriteDictionaryValue<T>(this Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, T>> dict, JsonSerializerOptions options) where T : notnull
        {
            writer.WriteStartObject();

            foreach (var (key, value) in dict)
            {
                writer.WriteObject(key, value, options);
            }

            writer.WriteEndObject();
        }

        public static void WriteDictionary(this Utf8JsonWriter writer, ReadOnlySpan<char> propertyName, IEnumerable<KeyValuePair<string, BinaryData>> dict)
        {
            writer.WritePropertyName(propertyName);
            writer.WriteDictionaryValue(dict);
        }

        public static void WriteDictionaryValue(this Utf8JsonWriter writer, IEnumerable<KeyValuePair<string, BinaryData>> dict)
        {
            writer.WriteStartObject();

            foreach (var (key, value) in dict)
            {
                writer.WritePropertyName(key);
                writer.WriteRawValue(value);
            }

            writer.WriteEndObject();
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

        public static void WriteObjectOrReference<T>(this Utf8JsonWriter writer, T value, JsonSerializerOptions options, ReferenceResolver referenceResolver, Action<Utf8JsonWriter, T, JsonSerializerOptions> writeProperties) where T : class
        {
            var id = referenceResolver.GetReference(value, out var alreadyExists);
            writer.WriteStartObject();
            if (alreadyExists)
            {
                writer.WriteString("$ref", id);
            }
            else
            {
                // write id
                writer.WriteString("$id", id);
                // write its own properties
                writeProperties(writer, value, options);
            }
            writer.WriteEndObject();
        }
    }
}
