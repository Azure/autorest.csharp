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
    /// <summary> Describes a virtual machine scale set network profile&apos;s network configurations. </summary>
    public partial class VirtualMachineScaleSetNetworkConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetNetworkConfiguration. </summary>
        /// <param name="name"> The network configuration name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineScaleSetNetworkConfiguration(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            IpConfigurations = new ChangeTrackingList<VirtualMachineScaleSetIPConfiguration>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetNetworkConfiguration. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> The network configuration name. </param>
        /// <param name="primary"> Specifies the primary network interface in case the virtual machine has more than 1 network interface. </param>
        /// <param name="enableAcceleratedNetworking"> Specifies whether the network interface is accelerated networking-enabled. </param>
        /// <param name="networkSecurityGroup"> The network security group. </param>
        /// <param name="dnsSettings"> The dns settings to be applied on the network interfaces. </param>
        /// <param name="ipConfigurations"> Specifies the IP configurations of the network interface. </param>
        /// <param name="enableIPForwarding"> Whether IP forwarding enabled on this NIC. </param>
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

        /// <summary> The network configuration name. </summary>
        public string Name { get; set; }
        /// <summary> Specifies the primary network interface in case the virtual machine has more than 1 network interface. </summary>
        public bool? Primary { get; set; }
        /// <summary> Specifies whether the network interface is accelerated networking-enabled. </summary>
        public bool? EnableAcceleratedNetworking { get; set; }
        /// <summary> The network security group. </summary>
        internal WritableSubResource NetworkSecurityGroup { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier NetworkSecurityGroupId
        {
            get => NetworkSecurityGroup is null ? default : NetworkSecurityGroup.Id;
            set
            {
                if (value is not null)
                {
                    if (NetworkSecurityGroup is null)
                        NetworkSecurityGroup = new WritableSubResource();
                    NetworkSecurityGroup.Id = value;
                }
                else
                {
                    NetworkSecurityGroup = null;
                }
            }
        }

        /// <summary> The dns settings to be applied on the network interfaces. </summary>
        internal VirtualMachineScaleSetNetworkConfigurationDnsSettings DnsSettings { get; set; }
        /// <summary> List of DNS servers IP addresses. </summary>
        public IList<string> DnsServers
        {
            get
            {
                if (DnsSettings is null)
                    DnsSettings = new VirtualMachineScaleSetNetworkConfigurationDnsSettings();
                return DnsSettings.DnsServers;
            }
        }

        /// <summary> Specifies the IP configurations of the network interface. </summary>
        public IList<VirtualMachineScaleSetIPConfiguration> IpConfigurations { get; }
        /// <summary> Whether IP forwarding enabled on this NIC. </summary>
        public bool? EnableIPForwarding { get; set; }
    }
}
