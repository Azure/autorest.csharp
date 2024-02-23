// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtAcronymMapping.Models
{
    public partial class VaultSecretGroup : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (SourceVault != null)
            {
                writer.WritePropertyName("sourceVault"u8);
                JsonSerializer.Serialize(writer, SourceVault);
            }
            if (!(VaultCertificates is ChangeTrackingList<VaultCertificate> collection && collection.IsUndefined))
            {
                writer.WritePropertyName("vaultCertificates"u8);
                writer.WriteStartArray();
                foreach (var item in VaultCertificates)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static VaultSecretGroup DeserializeVaultSecretGroup(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<WritableSubResource> sourceVault = default;
            Optional<IList<VaultCertificate>> vaultCertificates = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceVault"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    sourceVault = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("vaultCertificates"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<VaultCertificate> array = new List<VaultCertificate>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(VaultCertificate.DeserializeVaultCertificate(item));
                    }
                    vaultCertificates = array;
                    continue;
                }
            }
            return new VaultSecretGroup(sourceVault, Optional.ToList(vaultCertificates));
        }
    }
}
