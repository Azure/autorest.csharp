// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class DnsSettings : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Servers))
            {
                writer.WritePropertyName("servers"u8);
                writer.WriteStartArray();
                foreach (var item in Servers)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(EnableProxy))
            {
                writer.WritePropertyName("enableProxy"u8);
                writer.WriteBooleanValue(EnableProxy.Value);
            }
            if (Optional.IsDefined(RequireProxyForNetworkRules))
            {
                if (RequireProxyForNetworkRules != null)
                {
                    writer.WritePropertyName("requireProxyForNetworkRules"u8);
                    writer.WriteBooleanValue(RequireProxyForNetworkRules.Value);
                }
                else
                {
                    writer.WriteNull("requireProxyForNetworkRules");
                }
            }
            writer.WriteEndObject();
        }

        internal static DnsSettings DeserializeDnsSettings(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<string>> servers = default;
            Optional<bool> enableProxy = default;
            Optional<bool?> requireProxyForNetworkRules = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("servers"u8))
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
                    servers = array;
                    continue;
                }
                if (property.NameEquals("enableProxy"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableProxy = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("requireProxyForNetworkRules"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        requireProxyForNetworkRules = null;
                        continue;
                    }
                    requireProxyForNetworkRules = property.Value.GetBoolean();
                    continue;
                }
            }
            return new DnsSettings(Optional.ToList(servers), Optional.ToNullable(enableProxy), Optional.ToNullable(requireProxyForNetworkRules));
        }
    }
}
