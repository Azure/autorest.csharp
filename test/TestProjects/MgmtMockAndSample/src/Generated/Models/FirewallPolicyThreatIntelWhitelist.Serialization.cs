// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace MgmtMockAndSample.Models
{
    public partial class FirewallPolicyThreatIntelWhitelist : IUtf8JsonSerializable, IJsonModelSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable)this).Serialize(writer, ModelSerializerOptions.AzureServiceDefault);

        void IJsonModelSerializable.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
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

        object IModelSerializable.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeFirewallPolicyThreatIntelWhitelist(doc.RootElement, options);
        }

        internal static FirewallPolicyThreatIntelWhitelist DeserializeFirewallPolicyThreatIntelWhitelist(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.AzureServiceDefault;
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

        object IJsonModelSerializable.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeFirewallPolicyThreatIntelWhitelist(doc.RootElement, options);
        }
    }
}
