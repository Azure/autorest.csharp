// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveNetworkSecurityGroupAssociation
    {
        internal static EffectiveNetworkSecurityGroupAssociation DeserializeEffectiveNetworkSecurityGroupAssociation(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<SubResource> subnet = default;
            Optional<SubResource> networkInterface = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("subnet"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    subnet = SubResource.DeserializeSubResource(property.Value);
                    continue;
                }
                if (property.NameEquals("networkInterface"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkInterface = SubResource.DeserializeSubResource(property.Value);
                    continue;
                }
            }
            return new EffectiveNetworkSecurityGroupAssociation(subnet.Value, networkInterface.Value);
        }
    }
}
