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
                var converter = (JsonConverter<T>)options.GetConverter(typeof(T));
                converter.Write(writer, item, options);
            }
            writer.WriteEndArray();
        }
    }
}
