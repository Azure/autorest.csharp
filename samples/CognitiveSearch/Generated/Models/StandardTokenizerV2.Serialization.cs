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

namespace CognitiveSearch.Models
{
    public partial class StandardTokenizerV2 : IUtf8JsonSerializable, IJsonModel<StandardTokenizerV2>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<StandardTokenizerV2>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<StandardTokenizerV2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StandardTokenizerV2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(StandardTokenizerV2)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(OdataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
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

        StandardTokenizerV2 IJsonModel<StandardTokenizerV2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StandardTokenizerV2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(StandardTokenizerV2)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStandardTokenizerV2(document.RootElement, options);
        }

        internal static StandardTokenizerV2 DeserializeStandardTokenizerV2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> maxTokenLength = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new StandardTokenizerV2(odataType, name, serializedAdditionalRawData, Optional.ToNullable(maxTokenLength));
        }

        BinaryData IPersistableModel<StandardTokenizerV2>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StandardTokenizerV2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(StandardTokenizerV2)} does not support '{options.Format}' format.");
            }
        }

        StandardTokenizerV2 IPersistableModel<StandardTokenizerV2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StandardTokenizerV2>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeStandardTokenizerV2(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(StandardTokenizerV2)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<StandardTokenizerV2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
