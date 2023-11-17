// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class CorsRule : IUtf8JsonSerializable, IJsonModel<CorsRule>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CorsRule>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CorsRule>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if ((options.Format != "W" || ((IPersistableModel<CorsRule>)this).GetFormatFromOptions(options) != "J") && options.Format != "J")
            {
                throw new InvalidOperationException($"Must use 'J' format when calling the {nameof(IJsonModel<CorsRule>)} interface");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("allowedOrigins"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedOrigins)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedMethods"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedMethods)
            {
                writer.WriteStringValue(item.ToString());
            }
            writer.WriteEndArray();
            writer.WritePropertyName("maxAgeInSeconds"u8);
            writer.WriteNumberValue(MaxAgeInSeconds);
            writer.WritePropertyName("exposedHeaders"u8);
            writer.WriteStartArray();
            foreach (var item in ExposedHeaders)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("allowedHeaders"u8);
            writer.WriteStartArray();
            foreach (var item in AllowedHeaders)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
            if (_serializedAdditionalRawData != null && options.Format == "J")
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        CorsRule IJsonModel<CorsRule>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CorsRule)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCorsRule(document.RootElement, options);
        }

        internal static CorsRule DeserializeCorsRule(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> allowedOrigins = default;
            IList<CorsRuleAllowedMethodsItem> allowedMethods = default;
            int maxAgeInSeconds = default;
            IList<string> exposedHeaders = default;
            IList<string> allowedHeaders = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("allowedOrigins"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedOrigins = array;
                    continue;
                }
                if (property.NameEquals("allowedMethods"u8))
                {
                    List<CorsRuleAllowedMethodsItem> array = new List<CorsRuleAllowedMethodsItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new CorsRuleAllowedMethodsItem(item.GetString()));
                    }
                    allowedMethods = array;
                    continue;
                }
                if (property.NameEquals("maxAgeInSeconds"u8))
                {
                    maxAgeInSeconds = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("exposedHeaders"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    exposedHeaders = array;
                    continue;
                }
                if (property.NameEquals("allowedHeaders"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    allowedHeaders = array;
                    continue;
                }
                if (options.Format == "J")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CorsRule(allowedOrigins, allowedMethods, maxAgeInSeconds, exposedHeaders, allowedHeaders, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CorsRule>.Write(ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CorsRule)} does not support '{options.Format}' format.");
            }

            return ModelReaderWriter.Write(this, options);
        }

        CorsRule IPersistableModel<CorsRule>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            bool isValid = options.Format == "J" || options.Format == "W";
            if (!isValid)
            {
                throw new FormatException($"The model {nameof(CorsRule)} does not support '{options.Format}' format.");
            }

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeCorsRule(document.RootElement, options);
        }

        string IPersistableModel<CorsRule>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
