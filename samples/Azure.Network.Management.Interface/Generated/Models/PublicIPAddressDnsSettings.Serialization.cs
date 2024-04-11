// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class PublicIPAddressDnsSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
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

        internal static PublicIPAddressDnsSettings DeserializePublicIPAddressDnsSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string domainNameLabel = default;
            string fqdn = default;
            string reverseFqdn = default;
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
            return new PublicIPAddressDnsSettings(domainNameLabel, fqdn, reverseFqdn);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static PublicIPAddressDnsSettings FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializePublicIPAddressDnsSettings(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
