// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.Network.Management.Interface.Models
{
    public partial class PublicIPAddressDnsSettings : IUtf8JsonSerializable, IModelJsonSerializable<PublicIPAddressDnsSettings>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IModelJsonSerializable<PublicIPAddressDnsSettings>)this).Serialize(writer, ModelSerializerOptions.DefaultWireOptions);

        void IModelJsonSerializable<PublicIPAddressDnsSettings>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(DomainNameLabel))
            {
                writer.WritePropertyName("domainNameLabel"u8);
                writer.WriteStringValue(DomainNameLabel);
            }
            if (Optional.IsDefined(Fqdn))
            {
                writer.WritePropertyName("fqdn"u8);
                writer.WriteStringValue(Fqdn);
            }
            if (Optional.IsDefined(ReverseFqdn))
            {
                writer.WritePropertyName("reverseFqdn"u8);
                writer.WriteStringValue(ReverseFqdn);
            }
            writer.WriteEndObject();
        }

        PublicIPAddressDnsSettings IModelJsonSerializable<PublicIPAddressDnsSettings>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializePublicIPAddressDnsSettings(doc.RootElement, options);
        }

        BinaryData IModelSerializable<PublicIPAddressDnsSettings>.Serialize(ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);
            return ModelSerializer.SerializeCore(this, options);
        }

        PublicIPAddressDnsSettings IModelSerializable<PublicIPAddressDnsSettings>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            using JsonDocument document = JsonDocument.Parse(data);
            return DeserializePublicIPAddressDnsSettings(document.RootElement, options);
        }

        internal static PublicIPAddressDnsSettings DeserializePublicIPAddressDnsSettings(JsonElement element, ModelSerializerOptions options = null)
        {
            options ??= ModelSerializerOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<string> domainNameLabel = default;
            Optional<string> fqdn = default;
            Optional<string> reverseFqdn = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainNameLabel"u8))
                {
                    domainNameLabel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fqdn"u8))
                {
                    fqdn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reverseFqdn"u8))
                {
                    reverseFqdn = property.Value.GetString();
                    continue;
                }
            }
            return new PublicIPAddressDnsSettings(domainNameLabel.Value, fqdn.Value, reverseFqdn.Value);
        }
    }
}
