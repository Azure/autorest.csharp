// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set network profile's network configurations.
    /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration
    /// </summary>
    public partial class VirtualMachineScaleSetNetworkConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetNetworkConfiguration. </summary>
        /// <param name="name">
        /// The network configuration name.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.name
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineScaleSetNetworkConfiguration(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            IpConfigurations = new ChangeTrackingList<VirtualMachineScaleSetIPConfiguration>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetNetworkConfiguration. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="name">
        /// The network configuration name.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.name
        /// </param>
        /// <param name="primary">
        /// Specifies the primary network interface in case the virtual machine has more than 1 network interface.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.primary
        /// </param>
        /// <param name="enableAcceleratedNetworking">
        /// Specifies whether the network interface is accelerated networking-enabled.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.enableAcceleratedNetworking
        /// </param>
        /// <param name="networkSecurityGroup">
        /// The network security group.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.networkSecurityGroup
        /// </param>
        /// <param name="dnsSettings">
        /// The dns settings to be applied on the network interfaces.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.dnsSettings
        /// </param>
        /// <param name="ipConfigurations">
        /// Specifies the IP configurations of the network interface.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.ipConfigurations
        /// </param>
        /// <param name="enableIPForwarding">
        /// Whether IP forwarding enabled on this NIC.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.enableIPForwarding
        /// </param>
        internal VirtualMachineScaleSetNetworkConfiguration(string id, string name, bool? primary, bool? enableAcceleratedNetworking, WritableSubResource networkSecurityGroup, VirtualMachineScaleSetNetworkConfigurationDnsSettings dnsSettings, IList<VirtualMachineScaleSetIPConfiguration> ipConfigurations, bool? enableIPForwarding) : base(id)
        {
            Name = name;
            Primary = primary;
            EnableAcceleratedNetworking = enableAcceleratedNetworking;
            NetworkSecurityGroup = networkSecurityGroup;
            DnsSettings = dnsSettings;
            IpConfigurations = ipConfigurations;
            EnableIPForwarding = enableIPForwarding;
        }

        /// <summary>
        /// The network configuration name.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more than 1 network interface.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.primary
        /// </summary>
        public bool? Primary { get; set; }
        /// <summary>
        /// Specifies whether the network interface is accelerated networking-enabled.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.enableAcceleratedNetworking
        /// </summary>
        public bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>
        /// The network security group.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.networkSecurityGroup
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
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.dnsSettings
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
        /// Specifies the IP configurations of the network interface.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.ipConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetIPConfiguration> IpConfigurations { get; }
        /// <summary>
        /// Whether IP forwarding enabled on this NIC.
        /// Serialized Name: VirtualMachineScaleSetNetworkConfiguration.properties.enableIPForwarding
        /// </summary>
        public bool? EnableIPForwarding { get; set; }
    }
}
