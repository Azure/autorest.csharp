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

namespace Azure.AI.FormRecognizer.Models
{
    public partial class KeysResult : IUtf8JsonSerializable, IJsonModel<KeysResult>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<KeysResult>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<KeysResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeysResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(KeysResult)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("clusters"u8);
            writer.WriteStartObject();
            foreach (var item in Clusters)
            {
                writer.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
                writer.WriteStartArray();
                foreach (var item0 in item.Value)
                {
                    writer.WriteStringValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            if (options.Format != "W" && _serializedAdditionalRawData != null)
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

        KeysResult IJsonModel<KeysResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeysResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(KeysResult)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeKeysResult(document.RootElement, options);
        }

        internal static KeysResult DeserializeKeysResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IReadOnlyDictionary<string, IList<string>> clusters = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("clusters"u8))
                {
                    Dictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(property0.Name, null);
                        }
                        else
                        {
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            dictionary.Add(property0.Name, array);
                        }
                    }
                    clusters = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new KeysResult(clusters, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<KeysResult>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeysResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(KeysResult)} does not support '{options.Format}' format.");
            }
        }

        KeysResult IPersistableModel<KeysResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeysResult>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeKeysResult(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(KeysResult)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<KeysResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
