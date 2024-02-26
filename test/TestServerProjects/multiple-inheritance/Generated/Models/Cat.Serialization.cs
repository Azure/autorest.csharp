// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace multiple_inheritance.Models
{
    public partial class Cat : IUtf8JsonSerializable, IJsonModel<Cat>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Cat>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Cat>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cat>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Cat)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (LikesMilk.HasValue)
            {
                writer.WritePropertyName("likesMilk"u8);
                writer.WriteBooleanValue(LikesMilk.Value);
            }
            if (Meows.HasValue)
            {
                writer.WritePropertyName("meows"u8);
                writer.WriteBooleanValue(Meows.Value);
            }
            if (Hisses.HasValue)
            {
                writer.WritePropertyName("hisses"u8);
                writer.WriteBooleanValue(Hisses.Value);
            }
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

        Cat IJsonModel<Cat>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cat>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Cat)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCat(document.RootElement, options);
        }

        internal static Cat DeserializeCat(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool likesMilk = default;
            bool meows = default;
            bool hisses = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("likesMilk"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    likesMilk = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("meows"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    meows = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("hisses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hisses = property.Value.GetBoolean();
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
            return new Cat(name, serializedAdditionalRawData, likesMilk, meows, hisses);
        }

        BinaryData IPersistableModel<Cat>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cat>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(Cat)} does not support '{options.Format}' format.");
            }
        }

        Cat IPersistableModel<Cat>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cat>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCat(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Cat)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Cat>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
