// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    public partial class KeyVaultKeyReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keyUrl"u8);
            writer.WriteStringValue(KeyUri.AbsoluteUri);
            writer.WritePropertyName("sourceVault"u8);
            JsonSerializer.Serialize(writer, SourceVault); writer.WriteEndObject();
        }

        internal static KeyVaultKeyReference DeserializeKeyVaultKeyReference(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Uri keyUrl = default;
            WritableSubResource sourceVault = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyUrl"u8))
                {
                    keyUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourceVault"u8))
                {
                    sourceVault = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
            }
            return new KeyVaultKeyReference(keyUrl, sourceVault);
        }
    }
}
