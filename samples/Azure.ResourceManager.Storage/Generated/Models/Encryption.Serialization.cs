// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class Encryption : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Services))
            {
                writer.WritePropertyName("services"u8);
                writer.WriteObjectValue(Services);
            }
            writer.WritePropertyName("keySource"u8);
            writer.WriteStringValue(KeySource.ToString());
            if (Optional.IsDefined(RequireInfrastructureEncryption))
            {
                writer.WritePropertyName("requireInfrastructureEncryption"u8);
                writer.WriteBooleanValue(RequireInfrastructureEncryption.Value);
            }
            if (Optional.IsDefined(KeyVaultProperties))
            {
                writer.WritePropertyName("keyvaultproperties"u8);
                writer.WriteObjectValue(KeyVaultProperties);
            }
            if (Optional.IsDefined(EncryptionIdentity))
            {
                writer.WritePropertyName("identity"u8);
                writer.WriteObjectValue(EncryptionIdentity);
            }
            writer.WriteEndObject();
        }

        internal static Encryption DeserializeEncryption(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<EncryptionServices> services = default;
            KeySource keySource = default;
            Optional<bool> requireInfrastructureEncryption = default;
            Optional<KeyVaultProperties> keyvaultproperties = default;
            Optional<EncryptionIdentity> identity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("services"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    services = EncryptionServices.DeserializeEncryptionServices(property.Value);
                    continue;
                }
                if (property.NameEquals("keySource"u8))
                {
                    keySource = new KeySource(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("requireInfrastructureEncryption"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requireInfrastructureEncryption = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("keyvaultproperties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyvaultproperties = KeyVaultProperties.DeserializeKeyVaultProperties(property.Value);
                    continue;
                }
                if (property.NameEquals("identity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    identity = EncryptionIdentity.DeserializeEncryptionIdentity(property.Value);
                    continue;
                }
            }
            return new Encryption(services.Value, keySource, Optional.ToNullable(requireInfrastructureEncryption), keyvaultproperties.Value, identity.Value);
        }
    }
}
