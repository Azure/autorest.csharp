// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveNetworkSecurityGroupListResult
    {
        internal static EffectiveNetworkSecurityGroupListResult DeserializeEffectiveNetworkSecurityGroupListResult(JsonElement element)
        {
            EffectiveNetworkSecurityGroupListResult result = new EffectiveNetworkSecurityGroupListResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Value = new List<EffectiveNetworkSecurityGroup>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Value.Add(EffectiveNetworkSecurityGroup.DeserializeEffectiveNetworkSecurityGroup(item));
                    }
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NextLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}
