// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using body_complex;

namespace body_complex.Models
{
    public partial class DotSalmon : IUtf8JsonSerializable, IJsonModel<DotSalmon>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DotSalmon>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DotSalmon>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotSalmon>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DotSalmon)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location);
            }
            if (Optional.IsDefined(Iswild))
            {
                writer.WritePropertyName("iswild"u8);
                writer.WriteBooleanValue(Iswild.Value);
            }
            writer.WritePropertyName("fish.type"u8);
            writer.WriteStringValue(FishType);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
            }
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

        DotSalmon IJsonModel<DotSalmon>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotSalmon>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DotSalmon)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDotSalmon(document.RootElement, options);
        }

        internal static DotSalmon DeserializeDotSalmon(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string location = default;
            bool? iswild = default;
            string fishType = default;
            string species = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    location = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("iswild"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    iswild = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("fish.type"u8))
                {
                    fishType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"u8))
                {
                    species = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new DotSalmon(fishType, species, serializedAdditionalRawData, location, iswild);
        }

        BinaryData IPersistableModel<DotSalmon>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotSalmon>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DotSalmon)} does not support '{options.Format}' format.");
            }
        }

        DotSalmon IPersistableModel<DotSalmon>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotSalmon>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDotSalmon(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DotSalmon)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<DotSalmon>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
