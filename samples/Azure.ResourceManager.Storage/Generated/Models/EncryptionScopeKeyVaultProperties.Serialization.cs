// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class EncryptionScopeKeyVaultProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(KeyUri))
            {
                writer.WritePropertyName("keyUri"u8);
                writer.WriteStringValue(KeyUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        internal static EncryptionScopeKeyVaultProperties DeserializeEncryptionScopeKeyVaultProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> keyUri = default;
            Optional<string> currentVersionedKeyIdentifier = default;
            Optional<DateTimeOffset> lastKeyRotationTimestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("currentVersionedKeyIdentifier"u8))
                {
                    currentVersionedKeyIdentifier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastKeyRotationTimestamp"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastKeyRotationTimestamp = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new EncryptionScopeKeyVaultProperties(keyUri.Value, currentVersionedKeyIdentifier.Value, Optional.ToNullable(lastKeyRotationTimestamp));
        }
    }
}
