// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (GroupId != null)
            {
                writer.WritePropertyName("groupId");
                writer.WriteStringValue(GroupId);
            }
            if (RequiredMemberName != null)
            {
                writer.WritePropertyName("requiredMemberName");
                writer.WriteStringValue(RequiredMemberName);
            }
            if (Fqdns != null)
            {
                writer.WritePropertyName("fqdns");
                writer.WriteStartArray();
                foreach (var item in Fqdns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties DeserializeNetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(JsonElement element)
        {
            NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties result;
            string groupId = default;
            string requiredMemberName = default;
            IList<string> fqdns = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("groupId"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    groupId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredMemberName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requiredMemberName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fqdns"))
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
            result = new NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(groupId, requiredMemberName, fqdns);
            return result;
        }
    }
}
