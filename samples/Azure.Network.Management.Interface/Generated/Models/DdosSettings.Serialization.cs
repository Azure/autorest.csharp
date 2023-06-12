// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class DdosSettings : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(DdosCustomPolicy))
            {
                writer.WritePropertyName("ddosCustomPolicy"u8);
                writer.WriteObjectValue(DdosCustomPolicy);
            }
            if (Optional.IsDefined(ProtectionCoverage))
            {
                writer.WritePropertyName("protectionCoverage"u8);
                writer.WriteStringValue(ProtectionCoverage.Value.ToString());
            }
            if (Optional.IsDefined(ProtectedIP))
            {
                writer.WritePropertyName("protectedIP"u8);
                writer.WriteBooleanValue(ProtectedIP.Value);
            }
            writer.WriteEndObject();
        }

        internal static DdosSettings DeserializeDdosSettings(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SubResource> ddosCustomPolicy = default;
            Optional<DdosSettingsProtectionCoverage> protectionCoverage = default;
            Optional<bool> protectedIP = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ddosCustomPolicy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    ddosCustomPolicy = SubResource.DeserializeSubResource(property.Value);
                    continue;
                }
                if (property.NameEquals("protectionCoverage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectionCoverage = new DdosSettingsProtectionCoverage(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("protectedIP"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedIP = property.Value.GetBoolean();
                    continue;
                }
            }
            return new DdosSettings(ddosCustomPolicy.Value, Optional.ToNullable(protectionCoverage), Optional.ToNullable(protectedIP));
        }
    }
}
