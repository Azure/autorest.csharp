// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class NetworkInterfaceTapConfigurationListResult
    {
        internal static NetworkInterfaceTapConfigurationListResult DeserializeNetworkInterfaceTapConfigurationListResult(JsonElement element)
        {
            IReadOnlyList<NetworkInterfaceTapConfiguration> value = default;
            string nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    List<NetworkInterfaceTapConfiguration> array = new List<NetworkInterfaceTapConfiguration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new NetworkInterfaceTapConfigurationListResult(value, nextLink);
        }
    }
}
