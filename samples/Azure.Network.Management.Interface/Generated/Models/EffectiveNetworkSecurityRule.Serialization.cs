// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;

namespace Azure.Network.Management.Interface.Models
{
    public partial class EffectiveNetworkSecurityRule
    {
        internal static EffectiveNetworkSecurityRule DeserializeEffectiveNetworkSecurityRule(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            EffectiveSecurityRuleProtocol? protocol = default;
            string sourcePortRange = default;
            string destinationPortRange = default;
            IReadOnlyList<string> sourcePortRanges = default;
            IReadOnlyList<string> destinationPortRanges = default;
            string sourceAddressPrefix = default;
            string destinationAddressPrefix = default;
            IReadOnlyList<string> sourceAddressPrefixes = default;
            IReadOnlyList<string> destinationAddressPrefixes = default;
            IReadOnlyList<string> expandedSourceAddressPrefix = default;
            IReadOnlyList<string> expandedDestinationAddressPrefix = default;
            SecurityRuleAccess? access = default;
            int? priority = default;
            SecurityRuleDirection? direction = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("protocol"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protocol = new EffectiveSecurityRuleProtocol(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("sourcePortRange"u8))
                {
                    sourcePortRange = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationPortRange"u8))
                {
                    destinationPortRange = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourcePortRanges"u8))
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
                    sourcePortRanges = array;
                    continue;
                }
                if (property.NameEquals("destinationPortRanges"u8))
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
                    destinationPortRanges = array;
                    continue;
                }
                if (property.NameEquals("sourceAddressPrefix"u8))
                {
                    sourceAddressPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("destinationAddressPrefix"u8))
                {
                    destinationAddressPrefix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sourceAddressPrefixes"u8))
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
                    sourceAddressPrefixes = array;
                    continue;
                }
                if (property.NameEquals("destinationAddressPrefixes"u8))
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
                    destinationAddressPrefixes = array;
                    continue;
                }
                if (property.NameEquals("expandedSourceAddressPrefix"u8))
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
                    expandedSourceAddressPrefix = array;
                    continue;
                }
                if (property.NameEquals("expandedDestinationAddressPrefix"u8))
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
                    expandedDestinationAddressPrefix = array;
                    continue;
                }
                if (property.NameEquals("access"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    access = new SecurityRuleAccess(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("priority"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    priority = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("direction"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    direction = new SecurityRuleDirection(property.Value.GetString());
                    continue;
                }
            }
            return new EffectiveNetworkSecurityRule(
                name,
                protocol,
                sourcePortRange,
                destinationPortRange,
                sourcePortRanges ?? new ChangeTrackingList<string>(),
                destinationPortRanges ?? new ChangeTrackingList<string>(),
                sourceAddressPrefix,
                destinationAddressPrefix,
                sourceAddressPrefixes ?? new ChangeTrackingList<string>(),
                destinationAddressPrefixes ?? new ChangeTrackingList<string>(),
                expandedSourceAddressPrefix ?? new ChangeTrackingList<string>(),
                expandedDestinationAddressPrefix ?? new ChangeTrackingList<string>(),
                access,
                priority,
                direction);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static EffectiveNetworkSecurityRule FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeEffectiveNetworkSecurityRule(document.RootElement);
        }
    }
}
