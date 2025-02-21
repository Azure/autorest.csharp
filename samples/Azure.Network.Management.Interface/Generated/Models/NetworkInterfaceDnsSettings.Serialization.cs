// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class NetworkInterfaceDnsSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(DnsServers))
            {
                writer.WritePropertyName("dnsServers"u8);
                writer.WriteStartArray();
                foreach (var item in DnsServers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(InternalDnsNameLabel))
            {
                writer.WritePropertyName("internalDnsNameLabel"u8);
                writer.WriteStringValue(InternalDnsNameLabel);
            }
            writer.WriteEndObject();
        }

        internal static NetworkInterfaceDnsSettings DeserializeNetworkInterfaceDnsSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<string> dnsServers = default;
            IReadOnlyList<string> appliedDnsServers = default;
            string internalDnsNameLabel = default;
            string internalFqdn = default;
            string internalDomainNameSuffix = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("dnsServers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    dnsServers = array;
                    continue;
                }
                if (property.NameEquals("appliedDnsServers"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    appliedDnsServers = array;
                    continue;
                }
                if (property.NameEquals("internalDnsNameLabel"u8))
                {
                    internalDnsNameLabel = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("internalFqdn"u8))
                {
                    internalFqdn = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("internalDomainNameSuffix"u8))
                {
                    internalDomainNameSuffix = property.Value.GetString();
                    continue;
                }
            }
            return new NetworkInterfaceDnsSettings(dnsServers ?? new ChangeTrackingList<string>(), appliedDnsServers ?? new ChangeTrackingList<string>(), internalDnsNameLabel, internalFqdn, internalDomainNameSuffix);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static NetworkInterfaceDnsSettings FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, new JsonDocumentOptions { MaxDepth = 256 });
            return DeserializeNetworkInterfaceDnsSettings(document.RootElement);
        }

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
