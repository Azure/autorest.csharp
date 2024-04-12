// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class EncryptionKey : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("keyVaultKeyName"u8);
            writer.WriteStringValue(KeyVaultKeyName);
            writer.WritePropertyName("keyVaultKeyVersion"u8);
            writer.WriteStringValue(KeyVaultKeyVersion);
            writer.WritePropertyName("keyVaultUri"u8);
            writer.WriteStringValue(KeyVaultUri);
            if (Optional.IsDefined(AccessCredentials))
            {
                writer.WritePropertyName("accessCredentials"u8);
                writer.WriteObjectValue(AccessCredentials);
            }
            writer.WriteEndObject();
        }

        internal static EncryptionKey DeserializeEncryptionKey(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string keyVaultKeyName = default;
            string keyVaultKeyVersion = default;
            string keyVaultUri = default;
            AzureActiveDirectoryApplicationCredentials accessCredentials = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("keyVaultKeyName"u8))
                {
                    keyVaultKeyName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyVaultKeyVersion"u8))
                {
                    keyVaultKeyVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("keyVaultUri"u8))
                {
                    keyVaultUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accessCredentials"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    accessCredentials = AzureActiveDirectoryApplicationCredentials.DeserializeAzureActiveDirectoryApplicationCredentials(property.Value);
                    continue;
                }
            }
            return new EncryptionKey(keyVaultKeyName, keyVaultKeyVersion, keyVaultUri, accessCredentials);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static EncryptionKey FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeEncryptionKey(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            BinaryData binaryData = ModelReaderWriter.Write(this, new ModelReaderWriterOptions("W"));
            return RequestContent.Create(binaryData);
        }
    }
}
