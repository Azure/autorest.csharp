// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    public partial class NetworkInterfaceIPConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Id))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(VirtualNetworkTaps))
            {
                writer.WritePropertyName("virtualNetworkTaps"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualNetworkTaps)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(ApplicationGatewayBackendAddressPools))
            {
                writer.WritePropertyName("applicationGatewayBackendAddressPools"u8);
                writer.WriteStartArray();
                foreach (var item in ApplicationGatewayBackendAddressPools)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(LoadBalancerBackendAddressPools))
            {
                writer.WritePropertyName("loadBalancerBackendAddressPools"u8);
                writer.WriteStartArray();
                foreach (var item in LoadBalancerBackendAddressPools)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(LoadBalancerInboundNatRules))
            {
                writer.WritePropertyName("loadBalancerInboundNatRules"u8);
                writer.WriteStartArray();
                foreach (var item in LoadBalancerInboundNatRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(PrivateIPAddress))
            {
                writer.WritePropertyName("privateIPAddress"u8);
                writer.WriteStringValue(PrivateIPAddress);
            }
            if (Optional.IsDefined(PrivateIPAllocationMethod))
            {
                writer.WritePropertyName("privateIPAllocationMethod"u8);
                writer.WriteStringValue(PrivateIPAllocationMethod.Value.ToString());
            }
            if (Optional.IsDefined(PrivateIPAddressVersion))
            {
                writer.WritePropertyName("privateIPAddressVersion"u8);
                writer.WriteStringValue(PrivateIPAddressVersion.Value.ToString());
            }
            if (Optional.IsDefined(Subnet))
            {
                writer.WritePropertyName("subnet"u8);
                writer.WriteObjectValue(Subnet);
            }
            if (Optional.IsDefined(Primary))
            {
                writer.WritePropertyName("primary"u8);
                writer.WriteBooleanValue(Primary.Value);
            }
            if (Optional.IsDefined(PublicIPAddress))
            {
                writer.WritePropertyName("publicIPAddress"u8);
                writer.WriteObjectValue(PublicIPAddress);
            }
            if (Optional.IsCollectionDefined(ApplicationSecurityGroups))
            {
                writer.WritePropertyName("applicationSecurityGroups"u8);
                writer.WriteStartArray();
                foreach (var item in ApplicationSecurityGroups)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static NetworkInterfaceIPConfiguration DeserializeNetworkInterfaceIPConfiguration(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> etag = default;
            Optional<string> id = default;
            Optional<IList<VirtualNetworkTap>> virtualNetworkTaps = default;
            Optional<IList<ApplicationGatewayBackendAddressPool>> applicationGatewayBackendAddressPools = default;
            Optional<IList<BackendAddressPool>> loadBalancerBackendAddressPools = default;
            Optional<IList<InboundNatRule>> loadBalancerInboundNatRules = default;
            Optional<string> privateIPAddress = default;
            Optional<IPAllocationMethod> privateIPAllocationMethod = default;
            Optional<IPVersion> privateIPAddressVersion = default;
            Optional<Subnet> subnet = default;
            Optional<bool> primary = default;
            Optional<PublicIPAddress> publicIPAddress = default;
            Optional<IList<ApplicationSecurityGroup>> applicationSecurityGroups = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties> privateLinkConnectionProperties = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("etag"u8))
                {
                    etag = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("virtualNetworkTaps"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<VirtualNetworkTap> array = new List<VirtualNetworkTap>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(VirtualNetworkTap.DeserializeVirtualNetworkTap(item));
                            }
                            virtualNetworkTaps = array;
                            continue;
                        }
                        if (property0.NameEquals("applicationGatewayBackendAddressPools"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationGatewayBackendAddressPool> array = new List<ApplicationGatewayBackendAddressPool>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ApplicationGatewayBackendAddressPool.DeserializeApplicationGatewayBackendAddressPool(item));
                            }
                            applicationGatewayBackendAddressPools = array;
                            continue;
                        }
                        if (property0.NameEquals("loadBalancerBackendAddressPools"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<BackendAddressPool> array = new List<BackendAddressPool>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(BackendAddressPool.DeserializeBackendAddressPool(item));
                            }
                            loadBalancerBackendAddressPools = array;
                            continue;
                        }
                        if (property0.NameEquals("loadBalancerInboundNatRules"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<InboundNatRule> array = new List<InboundNatRule>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(InboundNatRule.DeserializeInboundNatRule(item));
                            }
                            loadBalancerInboundNatRules = array;
                            continue;
                        }
                        if (property0.NameEquals("privateIPAddress"u8))
                        {
                            privateIPAddress = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("privateIPAllocationMethod"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateIPAllocationMethod = new IPAllocationMethod(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateIPAddressVersion"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            privateIPAddressVersion = new IPVersion(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("subnet"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            subnet = Subnet.DeserializeSubnet(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("primary"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            primary = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("publicIPAddress"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            publicIPAddress = PublicIPAddress.DeserializePublicIPAddress(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("applicationSecurityGroups"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<ApplicationSecurityGroup> array = new List<ApplicationSecurityGroup>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(ApplicationSecurityGroup.DeserializeApplicationSecurityGroup(item));
                            }
                            applicationSecurityGroups = array;
                            continue;
                        }
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            provisioningState = new ProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("privateLinkConnectionProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            privateLinkConnectionProperties = NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties.DeserializeNetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new NetworkInterfaceIPConfiguration(id.Value, name.Value, etag.Value, Optional.ToList(virtualNetworkTaps), Optional.ToList(applicationGatewayBackendAddressPools), Optional.ToList(loadBalancerBackendAddressPools), Optional.ToList(loadBalancerInboundNatRules), privateIPAddress.Value, Optional.ToNullable(privateIPAllocationMethod), Optional.ToNullable(privateIPAddressVersion), subnet.Value, Optional.ToNullable(primary), publicIPAddress.Value, Optional.ToList(applicationSecurityGroups), Optional.ToNullable(provisioningState), privateLinkConnectionProperties.Value);
        }
    }
}
