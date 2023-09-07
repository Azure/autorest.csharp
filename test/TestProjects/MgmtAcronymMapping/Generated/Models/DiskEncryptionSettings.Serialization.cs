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

namespace MgmtAcronymMapping.Models
{
    public partial class DiskEncryptionSettings : IUtf8JsonSerializable, IModelJsonSerializable<DiskEncryptionSettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<DiskEncryptionSettings>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<DiskEncryptionSettings>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            writer.WriteStartObject();
            if (Optional.IsDefined(DiskEncryptionKey))
            {
                writer.WritePropertyName("diskEncryptionKey"u8);
                if (DiskEncryptionKey is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<KeyVaultSecretReference>)DiskEncryptionKey).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(KeyEncryptionKey))
            {
                writer.WritePropertyName("keyEncryptionKey"u8);
                if (KeyEncryptionKey is null)
                {
                    writer.WriteNullValue();
                }
                else
                {
                    ((IModelJsonSerializable<KeyVaultKeyReference>)KeyEncryptionKey).Serialize(writer, options);
                }
            }
            if (Optional.IsDefined(Enabled))
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }
            if (_serializedAdditionalRawData is not null && options.Format == ModelSerializerFormat.Json)
            {
                foreach (var property in _serializedAdditionalRawData)
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

        internal static DiskEncryptionSettings DeserializeDiskEncryptionSettings(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<KeyVaultSecretReference> diskEncryptionKey = default;
            Optional<KeyVaultKeyReference> keyEncryptionKey = default;
            Optional<bool> enabled = default;
            Dictionary<string, BinaryData> serializedAdditionalRawData = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("diskEncryptionKey"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    diskEncryptionKey = KeyVaultSecretReference.DeserializeKeyVaultSecretReference(property.Value);
                    continue;
                }
                if (property.NameEquals("keyEncryptionKey"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    keyEncryptionKey = KeyVaultKeyReference.DeserializeKeyVaultKeyReference(property.Value);
                    continue;
                }
                if (property.NameEquals("enabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format == ModelSerializerFormat.Json)
                {
                    serializedAdditionalRawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                    continue;
                }
            }
            return new DiskEncryptionSettings(diskEncryptionKey.Value, keyEncryptionKey.Value, Optional.ToNullable(enabled), serializedAdditionalRawData);
        }

        DiskEncryptionSettings IModelJsonSerializable<DiskEncryptionSettings>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeDiskEncryptionSettings(doc.RootElement, options);
        }

        BinaryData IModelSerializable<DiskEncryptionSettings>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelSerializer.SerializeCore(this, options);
        }

        DiskEncryptionSettings IModelSerializable<DiskEncryptionSettings>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.Parse(data);
            return DeserializeDiskEncryptionSettings(doc.RootElement, options);
        }

        /// <summary> Converts a <see cref="DiskEncryptionSettings"/> into a <see cref="RequestContent"/>. </summary>
        /// <param name="model"> The <see cref="DiskEncryptionSettings"/> to convert. </param>
        public static implicit operator RequestContent(DiskEncryptionSettings model)
        {
            if (model is null)
            {
                return null;
            }

            return RequestContent.Create(model, ModelSerializerOptions.DefaultWireOptions);
        }

        /// <summary> Converts a <see cref="Response"/> into a <see cref="DiskEncryptionSettings"/>. </summary>
        /// <param name="response"> The <see cref="Response"/> to convert. </param>
        public static explicit operator DiskEncryptionSettings(Response response)
        {
            if (response is null)
            {
                return null;
            }

            using JsonDocument doc = JsonDocument.Parse(response.ContentStream);
            return DeserializeDiskEncryptionSettings(doc.RootElement, ModelSerializerOptions.DefaultWireOptions);
        }
    }
}
