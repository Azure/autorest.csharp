// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageUsage : IUtf8JsonSerializable, IModelJsonSerializable<StorageUsage>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<StorageUsage>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<StorageUsage>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Unit))
            {
                writer.WritePropertyName("unit"u8);
                writer.WriteStringValue(Unit.Value.ToSerialString());
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(CurrentValue))
            {
                writer.WritePropertyName("currentValue"u8);
                writer.WriteNumberValue(CurrentValue.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Limit))
            {
                writer.WritePropertyName("limit"u8);
                writer.WriteNumberValue(Limit.Value);
            }
            if (options.Format == ModelSerializerFormat.Json && Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteObjectValue(Name);
            }
            writer.WriteEndObject();
        }

        StorageUsage IModelJsonSerializable<StorageUsage>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStorageUsage(document.RootElement, options);
        }

        BinaryData IModelSerializable<StorageUsage>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        StorageUsage IModelSerializable<StorageUsage>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeStorageUsage(document.RootElement, options);
        }

        internal static StorageUsage DeserializeStorageUsage(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<UsageUnit> unit = default;
            Optional<int> currentValue = default;
            Optional<int> limit = default;
            Optional<UsageName> name = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("unit"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    unit = property.Value.GetString().ToUsageUnit();
                    continue;
                }
                if (property.NameEquals("currentValue"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    currentValue = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("limit"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    limit = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = UsageName.DeserializeUsageName(property.Value);
                    continue;
                }
            }
            return new StorageUsage(Optional.ToNullable(unit), Optional.ToNullable(currentValue), Optional.ToNullable(limit), name.Value);
        }
    }
}
