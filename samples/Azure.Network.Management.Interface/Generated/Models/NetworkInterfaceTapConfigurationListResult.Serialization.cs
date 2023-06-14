// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    internal partial class NetworkInterfaceTapConfigurationListResult
    {
        internal static NetworkInterfaceTapConfigurationListResult DeserializeNetworkInterfaceTapConfigurationListResult(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<IReadOnlyList<NetworkInterfaceTapConfiguration>> value = default;
            Optional<string> nextLink = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<NetworkInterfaceTapConfiguration> array = new List<NetworkInterfaceTapConfiguration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(item));
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"u8))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new NetworkInterfaceTapConfigurationListResult(Optional.ToList(value), nextLink.Value);
        }
    }
}
