// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class VaultCertificate : IUtf8JsonSerializable, IModelJsonSerializable<VaultCertificate>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<VaultCertificate>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<VaultCertificate>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(CertificateUri))
            {
                writer.WritePropertyName("certificateUrl"u8);
                writer.WriteStringValue(CertificateUri.AbsoluteUri);
            }
            if (Optional.IsDefined(CertificateStore))
            {
                writer.WritePropertyName("certificateStore"u8);
                writer.WriteStringValue(CertificateStore);
            }
            writer.WriteEndObject();
        }

        VaultCertificate IModelJsonSerializable<VaultCertificate>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVaultCertificate(document.RootElement, options);
        }

        BinaryData IModelSerializable<VaultCertificate>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        VaultCertificate IModelSerializable<VaultCertificate>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializeVaultCertificate(document.RootElement, options);
        }

        internal static VaultCertificate DeserializeVaultCertificate(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<Uri> certificateUrl = default;
            Optional<string> certificateStore = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("certificateUrl"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    certificateUrl = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("certificateStore"u8))
                {
                    certificateStore = property.Value.GetString();
                    continue;
                }
            }
            return new VaultCertificate(certificateUrl.Value, certificateStore.Value);
        }
    }
}
