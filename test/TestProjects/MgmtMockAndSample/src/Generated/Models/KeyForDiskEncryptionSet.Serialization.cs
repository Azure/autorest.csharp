// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.ResourceManager.Resources.Models;

namespace MgmtMockAndSample.Models
{
    public partial class KeyForDiskEncryptionSet : IUtf8JsonSerializable, IModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelSerializable)this).Serialize(writer, new SerializableOptions());

        void IModelSerializable.Serialize(Utf8JsonWriter writer, SerializableOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(SourceVault))
            {
                writer.WritePropertyName("sourceVault"u8);
                JsonSerializer.Serialize(writer, SourceVault);
            }
            writer.WritePropertyName("keyUrl"u8);
            writer.WriteStringValue(KeyUri.AbsoluteUri);
            writer.WriteEndObject();
        }

        internal static KeyForDiskEncryptionSet DeserializeKeyForDiskEncryptionSet(JsonElement element, SerializableOptions options = default)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<WritableSubResource> sourceVault = default;
            Uri keyUrl = default;
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
                if (property.NameEquals("keyUrl"u8))
                {
                    keyUrl = new Uri(property.Value.GetString());
                    continue;
                }
            }
            return new KeyForDiskEncryptionSet(sourceVault, keyUrl);
        }
    }
}
