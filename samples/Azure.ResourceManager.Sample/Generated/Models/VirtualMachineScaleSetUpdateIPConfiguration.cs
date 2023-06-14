// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set network profile's IP configuration. NOTE: The subnet of a scale set may be modified as long as the original subnet and the new subnet are in the same virtual network
    /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateIPConfiguration. </summary>
        public VirtualMachineScaleSetUpdateIPConfiguration()
        {
            ApplicationGatewayBackendAddressPools = new ChangeTrackingList<WritableSubResource>();
            ApplicationSecurityGroups = new ChangeTrackingList<WritableSubResource>();
            LoadBalancerBackendAddressPools = new ChangeTrackingList<WritableSubResource>();
            LoadBalancerInboundNatPools = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateIPConfiguration. </summary>
        /// <param name="id">
        /// Resource Id
        /// Serialized Name: SubResource.id
        /// </param>
        /// <param name="name">
        /// The IP configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.name
        /// </param>
        /// <param name="subnet">
        /// The subnet.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.subnet
        /// </param>
        /// <param name="primary">
        /// Specifies the primary IP Configuration in case the network interface has more than one IP Configuration.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.primary
        /// </param>
        /// <param name="publicIPAddressConfiguration">
        /// The publicIPAddressConfiguration.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.publicIPAddressConfiguration
        /// </param>
        /// <param name="privateIPAddressVersion">
        /// Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.privateIPAddressVersion
        /// </param>
        /// <param name="applicationGatewayBackendAddressPools">
        /// The application gateway backend address pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.applicationGatewayBackendAddressPools
        /// </param>
        /// <param name="applicationSecurityGroups">
        /// Specifies an array of references to application security group.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.applicationSecurityGroups
        /// </param>
        /// <param name="loadBalancerBackendAddressPools">
        /// The load balancer backend address pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.loadBalancerBackendAddressPools
        /// </param>
        /// <param name="loadBalancerInboundNatPools">
        /// The load balancer inbound nat pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.loadBalancerInboundNatPools
        /// </param>
        internal VirtualMachineScaleSetUpdateIPConfiguration(string id, string name, WritableSubResource subnet, bool? primary, VirtualMachineScaleSetUpdatePublicIPAddressConfiguration publicIPAddressConfiguration, IPVersion? privateIPAddressVersion, IList<WritableSubResource> applicationGatewayBackendAddressPools, IList<WritableSubResource> applicationSecurityGroups, IList<WritableSubResource> loadBalancerBackendAddressPools, IList<WritableSubResource> loadBalancerInboundNatPools) : base(id)
        {
            Name = name;
            Subnet = subnet;
            Primary = primary;
            PublicIPAddressConfiguration = publicIPAddressConfiguration;
            PrivateIPAddressVersion = privateIPAddressVersion;
            ApplicationGatewayBackendAddressPools = applicationGatewayBackendAddressPools;
            ApplicationSecurityGroups = applicationSecurityGroups;
            LoadBalancerBackendAddressPools = loadBalancerBackendAddressPools;
            LoadBalancerInboundNatPools = loadBalancerInboundNatPools;
        }

        /// <summary>
        /// The IP configuration name.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The subnet.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.subnet
        /// </summary>
        internal WritableSubResource Subnet { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SubnetId
        {
            get => Subnet is null ? default : Subnet.Id;
            set
            {
                if (Subnet is null)
                    Subnet = new WritableSubResource();
                Subnet.Id = value;
            }
        }

        /// <summary>
        /// Specifies the primary IP Configuration in case the network interface has more than one IP Configuration.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.primary
        /// </summary>
        public bool? Primary { get; set; }
        /// <summary>
        /// The publicIPAddressConfiguration.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.publicIPAddressConfiguration
        /// </summary>
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }
        /// <summary>
        /// Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.privateIPAddressVersion
        /// </summary>
        public IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary>
        /// The application gateway backend address pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.applicationGatewayBackendAddressPools
        /// </summary>
        public IList<WritableSubResource> ApplicationGatewayBackendAddressPools { get; }
        /// <summary>
        /// Specifies an array of references to application security group.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.applicationSecurityGroups
        /// </summary>
        public IList<WritableSubResource> ApplicationSecurityGroups { get; }
        /// <summary>
        /// The load balancer backend address pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.loadBalancerBackendAddressPools
        /// </summary>
        public IList<WritableSubResource> LoadBalancerBackendAddressPools { get; }
        /// <summary>
        /// The load balancer inbound nat pools.
        /// Serialized Name: VirtualMachineScaleSetUpdateIPConfiguration.properties.loadBalancerInboundNatPools
        /// </summary>
        public IList<WritableSubResource> LoadBalancerInboundNatPools { get; }
    }
}
