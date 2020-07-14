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
            writer.WriteEndObject();
        }

        internal static NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties DeserializeNetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(JsonElement element)
        {
            Optional<string> groupId = default;
            Optional<string> requiredMemberName = default;
            Optional<IList<string>> fqdns = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("groupId"))
                {
                    groupId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredMemberName"))
                {
                    requiredMemberName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fqdns"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    fqdns = array;
                    continue;
                }
            }
            return new NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(groupId.Value, requiredMemberName.Value, Optional.ToList(fqdns));
        }
    }
}
