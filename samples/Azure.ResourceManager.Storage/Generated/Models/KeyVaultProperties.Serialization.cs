// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class KeyVaultProperties : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(KeyName))
            {
                writer.WritePropertyName("keyname"u8);
                writer.WriteStringValue(KeyName);
            }
            if (Optional.IsDefined(KeyVersion))
            {
                writer.WritePropertyName("keyversion"u8);
                writer.WriteStringValue(KeyVersion);
            }
            if (Optional.IsDefined(KeyVaultUri))
            {
                writer.WritePropertyName("keyvaulturi"u8);
                writer.WriteStringValue(KeyVaultUri.AbsoluteUri);
            }
            writer.WriteEndObject();
        }

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeKeyVaultProperties(doc.RootElement, options);
        }

        internal static KeyVaultProperties DeserializeKeyVaultProperties(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> keyname = default;
            Optional<string> keyversion = default;
            Optional<Uri> keyvaulturi = default;
            Optional<string> currentVersionedKeyIdentifier = default;
            Optional<DateTimeOffset> lastKeyRotationTimestamp = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyname"u8))
                {
                    keyname = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyversion"u8))
                {
                    keyversion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyvaulturi"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyvaulturi = new Uri(property.Value.GetString());
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
            return new KeyVaultProperties(keyname.Value, keyversion.Value, keyvaulturi.Value, currentVersionedKeyIdentifier.Value, Optional.ToNullable(lastKeyRotationTimestamp));
        }

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeKeyVaultProperties(doc.RootElement, options);
        }
    }
}
