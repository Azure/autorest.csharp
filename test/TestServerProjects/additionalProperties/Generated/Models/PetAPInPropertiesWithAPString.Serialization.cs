// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace additionalProperties.Models
{
    public partial class PetAPInPropertiesWithAPString : IUtf8JsonSerializable, IJsonModel<PetAPInPropertiesWithAPString>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PetAPInPropertiesWithAPString>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PetAPInPropertiesWithAPString>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetAPInPropertiesWithAPString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PetAPInPropertiesWithAPString)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteNumberValue(Id);
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format != "W" && Status.HasValue)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteBooleanValue(Status.Value);
            }
            writer.WritePropertyName("@odata.location"u8);
            writer.WriteStringValue(OdataLocation);
            if (!(AdditionalProperties is ChangeTrackingDictionary<string, float> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("additionalProperties"u8);
                writer.WriteStartObject();
                foreach (var item in AdditionalProperties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            foreach (var item in MoreAdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteStringValue(item.Value);
            }
            writer.WriteEndObject();
        }

        PetAPInPropertiesWithAPString IJsonModel<PetAPInPropertiesWithAPString>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetAPInPropertiesWithAPString>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PetAPInPropertiesWithAPString)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePetAPInPropertiesWithAPString(document.RootElement, options);
        }

        internal static PetAPInPropertiesWithAPString DeserializePetAPInPropertiesWithAPString(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int id = default;
            Optional<string> name = default;
            Optional<bool> status = default;
            string odataLocation = default;
            IDictionary<string, float> additionalProperties = default;
            IDictionary<string, string> moreAdditionalProperties = default;
            Dictionary<string, string> additionalPropertiesDictionary = new Dictionary<string, string>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    status = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("@odata.location"u8))
                {
                    odataLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("additionalProperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, float> dictionary = new Dictionary<string, float>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetSingle());
                    }
                    additionalProperties = dictionary;
                    continue;
                }
                additionalPropertiesDictionary.Add(property.Name, property.Value.GetString());
            }
            moreAdditionalProperties = additionalPropertiesDictionary;
            return new PetAPInPropertiesWithAPString(id, name.Value, Optional.ToNullable(status), odataLocation, additionalProperties ?? new ChangeTrackingDictionary<string, float>(), moreAdditionalProperties);
        }

        BinaryData IPersistableModel<PetAPInPropertiesWithAPString>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetAPInPropertiesWithAPString>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(PetAPInPropertiesWithAPString)} does not support '{options.Format}' format.");
            }
        }

        PetAPInPropertiesWithAPString IPersistableModel<PetAPInPropertiesWithAPString>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PetAPInPropertiesWithAPString>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePetAPInPropertiesWithAPString(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PetAPInPropertiesWithAPString)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<PetAPInPropertiesWithAPString>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
