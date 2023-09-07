// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set network profile's network configurations.
    /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateNetworkConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateNetworkConfiguration"/>. </summary>
        public VirtualMachineScaleSetUpdateNetworkConfiguration()
        {
            IPConfigurations = new ChangeTrackingList<VirtualMachineScaleSetUpdateIPConfiguration>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateNetworkConfiguration"/>. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="name">
        /// The network configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.name
        /// </param>
        /// <param name="primary">
        /// Whether this is a primary NIC on a virtual machine.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.primary
        /// </param>
        /// <param name="enableAcceleratedNetworking">
        /// Specifies whether the network interface is accelerated networking-enabled.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.enableAcceleratedNetworking
        /// </param>
        /// <param name="networkSecurityGroup">
        /// The network security group.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.networkSecurityGroup
        /// </param>
        /// <param name="dnsSettings">
        /// The dns settings to be applied on the network interfaces.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.dnsSettings
        /// </param>
        /// <param name="ipConfigurations">
        /// The virtual machine scale set IP Configuration.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.ipConfigurations
        /// </param>
        /// <param name="enableIPForwarding">
        /// Whether IP forwarding enabled on this NIC.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.enableIPForwarding
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetUpdateNetworkConfiguration(string id, string name, bool? primary, bool? enableAcceleratedNetworking, WritableSubResource networkSecurityGroup, VirtualMachineScaleSetNetworkConfigurationDnsSettings dnsSettings, IList<VirtualMachineScaleSetUpdateIPConfiguration> ipConfigurations, bool? enableIPForwarding, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(id, serializedAdditionalRawData)
        {
            Name = name;
            Primary = primary;
            EnableAcceleratedNetworking = enableAcceleratedNetworking;
            NetworkSecurityGroup = networkSecurityGroup;
            DnsSettings = dnsSettings;
            IPConfigurations = ipConfigurations;
            EnableIPForwarding = enableIPForwarding;
        }

        /// <summary>
        /// The network configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Whether this is a primary NIC on a virtual machine.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.primary
        /// </summary>
        public bool? Primary { get; set; }
        /// <summary>
        /// Specifies whether the network interface is accelerated networking-enabled.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.enableAcceleratedNetworking
        /// </summary>
        public bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>
        /// The network security group.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.networkSecurityGroup
        /// </summary>
        internal WritableSubResource NetworkSecurityGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier NetworkSecurityGroupId
        {
            get => NetworkSecurityGroup is null ? default : NetworkSecurityGroup.Id;
            set
            {
                if (NetworkSecurityGroup is null)
                    NetworkSecurityGroup = new WritableSubResource();
                NetworkSecurityGroup.Id = value;
            }
        }

        /// <summary>
        /// The dns settings to be applied on the network interfaces.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.dnsSettings
        /// </summary>
        internal VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses
        /// Serialized Name: VirtualMachineScaleSetNetworkConfigurationDnsSettings.dnsServers
        /// </summary>
        public IList<string> DnsServers
        {
            get
            {
                if (DnsSettings is null)
                    DnsSettings = new VirtualMachineScaleSetNetworkConfigurationDnsSettings();
                return DnsSettings.DnsServers;
            }
        }

        /// <summary>
        /// The virtual machine scale set IP Configuration.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.ipConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetUpdateIPConfiguration> IPConfigurations { get; }
        /// <summary>
        /// Whether IP forwarding enabled on this NIC.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkConfiguration.properties.enableIPForwarding
        /// </summary>
        public bool? EnableIPForwarding { get; set; }
    }
}
