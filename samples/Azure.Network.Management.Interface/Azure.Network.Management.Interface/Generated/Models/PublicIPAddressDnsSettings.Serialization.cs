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
            if (DomainNameLabel != null)
            {
                writer.WritePropertyName("domainNameLabel");
                writer.WriteStringValue(DomainNameLabel);
            }
            if (Fqdn != null)
            {
                writer.WritePropertyName("fqdn");
                writer.WriteStringValue(Fqdn);
            }
            if (ReverseFqdn != null)
            {
                writer.WritePropertyName("reverseFqdn");
                writer.WriteStringValue(ReverseFqdn);
            }
            writer.WriteEndObject();
        }

        internal static PublicIPAddressDnsSettings DeserializePublicIPAddressDnsSettings(JsonElement element)
        {
            string domainNameLabel = default;
            string fqdn = default;
            string reverseFqdn = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("domainNameLabel"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    domainNameLabel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fqdn"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    fqdn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("reverseFqdn"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    reverseFqdn = property.Value.GetString();
                    continue;
                }
            }
            return new PublicIPAddressDnsSettings(domainNameLabel, fqdn, reverseFqdn);
        }
    }
}
