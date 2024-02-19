// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Cookiecuttershark : IUtf8JsonSerializable, IJsonModel<Cookiecuttershark>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<Cookiecuttershark>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<Cookiecuttershark>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cookiecuttershark>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Cookiecuttershark)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Age))
            {
                writer.WritePropertyName("age"u8);
                writer.WriteNumberValue(Age.Value);
            }
            writer.WritePropertyName("birthday"u8);
            writer.WriteStringValue(Birthday, "O");
            writer.WritePropertyName("fishtype"u8);
            writer.WriteStringValue(Fishtype);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length"u8);
            writer.WriteNumberValue(Length);
            if (Optional.IsCollectionDefined(Siblings))
            {
                writer.WritePropertyName("siblings"u8);
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    if (item != null)
                    {
                        ((IJsonModel<Fish>)item).Write(writer, options);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }
                }
                writer.WriteEndArray();
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

        Cookiecuttershark IJsonModel<Cookiecuttershark>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cookiecuttershark>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Cookiecuttershark)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCookiecuttershark(document.RootElement, options);
        }

        internal static Cookiecuttershark DeserializeCookiecuttershark(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> age = default;
            DateTimeOffset birthday = default;
            string fishtype = default;
            Optional<string> species = default;
            float length = default;
            Optional<IList<Fish>> siblings = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"u8))
                {
                    birthday = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("fishtype"u8))
                {
                    fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"u8))
                {
                    species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"u8))
                {
                    length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Fish> array = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(DeserializeFish(item));
                        }
                    }
                    siblings = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new Cookiecuttershark(fishtype, species.Value, length, Optional.ToList(siblings), serializedAdditionalRawData, Optional.ToNullable(age), birthday);
        }

        BinaryData IPersistableModel<Cookiecuttershark>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cookiecuttershark>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(Cookiecuttershark)} does not support '{options.Format}' format.");
            }
        }

        Cookiecuttershark IPersistableModel<Cookiecuttershark>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Cookiecuttershark>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCookiecuttershark(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Cookiecuttershark)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<Cookiecuttershark>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
