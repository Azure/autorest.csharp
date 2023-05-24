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
    public partial class VaultCertificate : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IUtf8JsonSerializable)this).Write(writer, new SerializableOptions());

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer, SerializableOptions options)
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

        internal static VaultCertificate DeserializeVaultCertificate(JsonElement element, SerializableOptions options = default)
        {
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
