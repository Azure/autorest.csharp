// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyThreatIntelWhitelist : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(IpAddresses))
            {
                writer.WritePropertyName("ipAddresses"u8);
                writer.WriteStartArray();
                foreach (var item in IpAddresses)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Fqdns))
            {
                writer.WritePropertyName("fqdns"u8);
                writer.WriteStartArray();
                foreach (var item in Fqdns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static FirewallPolicyThreatIntelWhitelist DeserializeFirewallPolicyThreatIntelWhitelist(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IList<IPAddress>> ipAddresses = default;
            Optional<IList<string>> fqdns = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ipAddresses"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<IPAddress> array = new List<IPAddress>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(IPAddress.Parse(item.GetString()));
                        }
                    }
                    ipAddresses = array;
                    continue;
                }
                if (property.NameEquals("fqdns"u8))
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
                    fqdns = array;
                    continue;
                }
            }
            return new FirewallPolicyThreatIntelWhitelist(Optional.ToList(ipAddresses), Optional.ToList(fqdns));
        }
    }
}
