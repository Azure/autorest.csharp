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
    public partial class ManagementPolicyBaseBlob : IUtf8JsonSerializable, IModelJsonSerializable<ManagementPolicyBaseBlob>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<ManagementPolicyBaseBlob>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<ManagementPolicyBaseBlob>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(TierToCool))
            {
                writer.WritePropertyName("tierToCool"u8);
                writer.WriteObjectValue(TierToCool);
            }
            if (Optional.IsDefined(TierToArchive))
            {
                writer.WritePropertyName("tierToArchive"u8);
                writer.WriteObjectValue(TierToArchive);
            }
            if (Optional.IsDefined(Delete))
            {
                writer.WritePropertyName("delete"u8);
                writer.WriteObjectValue(Delete);
            }
            if (Optional.IsDefined(EnableAutoTierToHotFromCool))
            {
                writer.WritePropertyName("enableAutoTierToHotFromCool"u8);
                writer.WriteBooleanValue(EnableAutoTierToHotFromCool.Value);
            }
            writer.WriteEndObject();
        }

        ManagementPolicyBaseBlob IModelJsonSerializable<ManagementPolicyBaseBlob>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeManagementPolicyBaseBlob(doc.RootElement, options);
        }

        BinaryData IModelSerializable<ManagementPolicyBaseBlob>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        ManagementPolicyBaseBlob IModelSerializable<ManagementPolicyBaseBlob>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeManagementPolicyBaseBlob(document.RootElement, options);
        }

        internal static ManagementPolicyBaseBlob DeserializeManagementPolicyBaseBlob(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<DateAfterModification> tierToCool = default;
            Optional<DateAfterModification> tierToArchive = default;
            Optional<DateAfterModification> delete = default;
            Optional<bool> enableAutoTierToHotFromCool = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tierToCool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tierToCool = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("tierToArchive"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    tierToArchive = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("delete"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    delete = DateAfterModification.DeserializeDateAfterModification(property.Value);
                    continue;
                }
                if (property.NameEquals("enableAutoTierToHotFromCool"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutoTierToHotFromCool = property.Value.GetBoolean();
                    continue;
                }
            }
            return new ManagementPolicyBaseBlob(tierToCool.Value, tierToArchive.Value, delete.Value, Optional.ToNullable(enableAutoTierToHotFromCool));
        }
    }
}
