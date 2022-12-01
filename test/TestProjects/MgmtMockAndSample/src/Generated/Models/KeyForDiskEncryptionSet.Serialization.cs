// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class KeyForDiskEncryptionSet : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SourceVault))
            {
                writer.WritePropertyName("sourceVault");
                JsonSerializer.Serialize(writer, SourceVault);
            }
            writer.WritePropertyName("keyUrl");
            writer.WriteStringValue(KeyUri.AbsoluteUri);
            writer.WriteEndObject();
        }

        internal static KeyForDiskEncryptionSet DeserializeKeyForDiskEncryptionSet(JsonElement element)
        {
            Optional<WritableSubResource> sourceVault = default;
            Uri keyUrl = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceVault"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    sourceVault = JsonSerializer.Deserialize<WritableSubResource>(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("keyUrl"))
                {
                    keyUrl = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new KeyForDiskEncryptionSet(sourceVault, keyUrl);
        }
    }
}
