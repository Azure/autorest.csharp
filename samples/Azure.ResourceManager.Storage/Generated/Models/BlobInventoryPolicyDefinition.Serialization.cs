// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class BlobInventoryPolicyDefinition : IUtf8JsonSerializable, IModelJsonSerializable<BlobInventoryPolicyDefinition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<BlobInventoryPolicyDefinition>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<BlobInventoryPolicyDefinition>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
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
            writer.WriteEndObject();
        }

        BlobInventoryPolicyDefinition IModelJsonSerializable<BlobInventoryPolicyDefinition>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeBlobInventoryPolicyDefinition(document.RootElement, options);
        }

        BinaryData IModelSerializable<BlobInventoryPolicyDefinition>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        BlobInventoryPolicyDefinition IModelSerializable<BlobInventoryPolicyDefinition>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeBlobInventoryPolicyDefinition(document.RootElement, options);
        }

        internal static BlobInventoryPolicyDefinition DeserializeBlobInventoryPolicyDefinition(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BlobInventoryPolicyFilter> filters = default;
            Format format = default;
            Schedule schedule = default;
            ObjectType objectType = default;
            IList<string> schemaFields = default;
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
            }
            return new BlobInventoryPolicyDefinition(filters.Value, format, schedule, objectType, schemaFields);
        }
    }
}
