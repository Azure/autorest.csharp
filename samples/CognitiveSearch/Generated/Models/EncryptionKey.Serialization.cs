// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace CognitiveSearch.Models
{
    public partial class EncryptionKey : IUtf8JsonSerializable, IModelJsonSerializable<EncryptionKey>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<EncryptionKey>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<EncryptionKey>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

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
            if (_rawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _rawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static EncryptionKey DeserializeEncryptionKey(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string keyVaultKeyName = default;
            string keyVaultKeyVersion = default;
            string keyVaultUri = default;
            Optional<AzureActiveDirectoryApplicationCredentials> accessCredentials = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();
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
                if (options.Format == ModelSerializerFormat.Json)
                {
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new EncryptionKey(keyVaultKeyName, keyVaultKeyVersion, keyVaultUri, accessCredentials.Value, rawData);
        }

        EncryptionKey IModelJsonSerializable<EncryptionKey>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeEncryptionKey(doc.RootElement, options);
        }

        BinaryData IModelSerializable<EncryptionKey>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        EncryptionKey IModelSerializable<EncryptionKey>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeEncryptionKey(doc.RootElement, options);
        }

        public static implicit operator RequestContent(EncryptionKey model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        public static explicit operator EncryptionKey(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeEncryptionKey(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
