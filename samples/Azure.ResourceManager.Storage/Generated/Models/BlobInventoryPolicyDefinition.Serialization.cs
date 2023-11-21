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
    public partial class BlobInventoryPolicyDefinition : IUtf8JsonSerializable, IJsonModel<BlobInventoryPolicyDefinition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<BlobInventoryPolicyDefinition>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<BlobInventoryPolicyDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobInventoryPolicyDefinition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BlobInventoryPolicyDefinition)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Filters))
            {
                writer.WritePropertyName("filters"u8);
                writer.WriteObjectValue(Filters);
            }
            writer.WritePropertyName("format"u8);
            writer.WriteStringValue(Format.ToString());
            writer.WritePropertyName("schedule"u8);
            writer.WriteStringValue(Schedule.ToString());
            writer.WritePropertyName("objectType"u8);
            writer.WriteStringValue(ObjectType.ToString());
            writer.WritePropertyName("schemaFields"u8);
            writer.WriteStartArray();
            foreach (var item in SchemaFields)
            {
                writer.WriteStringValue(item);
            }
            writer.WriteEndArray();
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

        BlobInventoryPolicyDefinition IJsonModel<BlobInventoryPolicyDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobInventoryPolicyDefinition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(BlobInventoryPolicyDefinition)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobInventoryPolicyDefinition(document.RootElement, options);
        }

        internal static BlobInventoryPolicyDefinition DeserializeBlobInventoryPolicyDefinition(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BlobInventoryPolicyFilter> filters = default;
            Format format = default;
            Schedule schedule = default;
            ObjectType objectType = default;
            IList<string> schemaFields = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("filters"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    filters = BlobInventoryPolicyFilter.DeserializeBlobInventoryPolicyFilter(property.Value);
                    continue;
                }
                if (property.NameEquals("format"u8))
                {
                    format = new Format(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("schedule"u8))
                {
                    schedule = new Schedule(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("objectType"u8))
                {
                    objectType = new ObjectType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("schemaFields"u8))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    schemaFields = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new BlobInventoryPolicyDefinition(filters.Value, format, schedule, objectType, schemaFields, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<BlobInventoryPolicyDefinition>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobInventoryPolicyDefinition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new InvalidOperationException($"The model {nameof(BlobInventoryPolicyDefinition)} does not support '{options.Format}' format.");
            }
        }

        BlobInventoryPolicyDefinition IPersistableModel<BlobInventoryPolicyDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<BlobInventoryPolicyDefinition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeBlobInventoryPolicyDefinition(document.RootElement, options);
                    }
                default:
                    throw new InvalidOperationException($"The model {nameof(BlobInventoryPolicyDefinition)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<BlobInventoryPolicyDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
