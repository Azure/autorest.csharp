// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtAcronymMapping.Models
{
    public partial class AutomaticOSUpgradePolicy : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (EnableAutomaticOSUpgrade.HasValue)
            {
                writer.WritePropertyName("enableAutomaticOSUpgrade"u8);
                writer.WriteBooleanValue(EnableAutomaticOSUpgrade.Value);
            }
            if (DisableAutomaticRollback.HasValue)
            {
                writer.WritePropertyName("disableAutomaticRollback"u8);
                writer.WriteBooleanValue(DisableAutomaticRollback.Value);
            }
            writer.WriteEndObject();
        }

        internal static AutomaticOSUpgradePolicy DeserializeAutomaticOSUpgradePolicy(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<bool> enableAutomaticOSUpgrade = default;
            Optional<bool> disableAutomaticRollback = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enableAutomaticOSUpgrade"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableAutomaticOSUpgrade = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("disableAutomaticRollback"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    disableAutomaticRollback = property.Value.GetBoolean();
                    continue;
                }
            }
            return new AutomaticOSUpgradePolicy(Optional.ToNullable(enableAutomaticOSUpgrade), Optional.ToNullable(disableAutomaticRollback));
        }
    }
}
