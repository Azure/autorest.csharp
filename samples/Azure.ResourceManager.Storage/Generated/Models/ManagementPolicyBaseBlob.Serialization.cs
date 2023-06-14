// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class ManagementPolicyBaseBlob : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static ManagementPolicyBaseBlob DeserializeManagementPolicyBaseBlob(JsonElement element)
        {
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
