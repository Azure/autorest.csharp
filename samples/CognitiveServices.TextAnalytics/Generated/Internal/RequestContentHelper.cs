// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics
{
    internal static class RequestContentHelper
    {
        public static RequestContent FromEnumerable<T>(IEnumerable<T> enumerable)
        where T : notnull
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                content.JsonWriter.WriteObjectValue(item);
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static RequestContent FromEnumerable(IEnumerable<BinaryData> enumerable)
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                if (item == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(item);
#else
                    using (JsonDocument document = JsonDocument.Parse(item, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
                    }
#endif
                }
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static RequestContent FromEnumerable<T>(ReadOnlySpan<T> span)
        where T : notnull
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartArray();
            for (int i = 0; i < span.Length; i++)
            {
                content.JsonWriter.WriteObjectValue(span[i]);
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static RequestContent FromDictionary<TValue>(IDictionary<string, TValue> dictionary)
        where TValue : notnull
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value);
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static RequestContent FromDictionary(IDictionary<string, BinaryData> dictionary)
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
                    }
#endif
                }
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static RequestContent FromObject(object value)
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue<object>(value);
            return content;
        }

        public static RequestContent FromObject(BinaryData value)
        {
            Utf8JsonRequestContent content = new Utf8JsonRequestContent();
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(value);
#else
            using (JsonDocument document = JsonDocument.Parse(value, ModelSerializationExtensions.JsonDocumentOptions))
            {
                JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
            }
#endif
            return content;
        }
    }
}
