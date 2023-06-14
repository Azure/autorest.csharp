// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    public partial class KeyVaultSecretReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("secretUrl"u8);
            writer.WriteStringValue(SecretUri.AbsoluteUri);
            writer.WritePropertyName("sourceVault"u8);
            JsonSerializer.Serialize(writer, SourceVault); writer.WriteEndObject();
        }

        internal static KeyVaultSecretReference DeserializeKeyVaultSecretReference(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri secretUrl = default;
            WritableSubResource sourceVault = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("secretUrl"u8))
                {
                    secretUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceVault"u8))
                {
                    sourceVault = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
            }
            return new KeyVaultSecretReference(secretUrl, sourceVault);
        }
    }
}
