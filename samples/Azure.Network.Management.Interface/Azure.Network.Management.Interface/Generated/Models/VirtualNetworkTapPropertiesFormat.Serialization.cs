// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class VirtualNetworkTapPropertiesFormat : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (NetworkInterfaceTapConfigurations != null)
            {
                writer.WritePropertyName("networkInterfaceTapConfigurations");
                writer.WriteStartArray();
                foreach (var item in NetworkInterfaceTapConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (ResourceGuid != null)
            {
                writer.WritePropertyName("resourceGuid");
                writer.WriteStringValue(ResourceGuid);
            }
            if (ProvisioningState != null)
            {
                writer.WritePropertyName("provisioningState");
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (DestinationNetworkInterfaceIPConfiguration != null)
            {
                writer.WritePropertyName("destinationNetworkInterfaceIPConfiguration");
                writer.WriteObjectValue(DestinationNetworkInterfaceIPConfiguration);
            }
            if (DestinationLoadBalancerFrontEndIPConfiguration != null)
            {
                writer.WritePropertyName("destinationLoadBalancerFrontEndIPConfiguration");
                writer.WriteObjectValue(DestinationLoadBalancerFrontEndIPConfiguration);
            }
            if (DestinationPort != null)
            {
                writer.WritePropertyName("destinationPort");
                writer.WriteNumberValue(DestinationPort.Value);
            }
            writer.WriteEndObject();
        }
        internal static VirtualNetworkTapPropertiesFormat DeserializeVirtualNetworkTapPropertiesFormat(JsonElement element)
        {
            VirtualNetworkTapPropertiesFormat result = new VirtualNetworkTapPropertiesFormat();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("networkInterfaceTapConfigurations"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.NetworkInterfaceTapConfigurations = new List<NetworkInterfaceTapConfiguration>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.NetworkInterfaceTapConfigurations.Add(NetworkInterfaceTapConfiguration.DeserializeNetworkInterfaceTapConfiguration(item));
                    }
                    continue;
                }
                if (property.NameEquals("resourceGuid"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ResourceGuid = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("provisioningState"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.ProvisioningState = new ProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("destinationNetworkInterfaceIPConfiguration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DestinationNetworkInterfaceIPConfiguration = NetworkInterfaceIPConfiguration.DeserializeNetworkInterfaceIPConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("destinationLoadBalancerFrontEndIPConfiguration"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DestinationLoadBalancerFrontEndIPConfiguration = FrontendIPConfiguration.DeserializeFrontendIPConfiguration(property.Value);
                    continue;
                }
                if (property.NameEquals("destinationPort"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DestinationPort = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
    }
}
