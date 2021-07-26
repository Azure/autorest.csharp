// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes a virtual machine scale set network profile&apos;s IP configuration. NOTE: The subnet of a scale set may be modified as long as the original subnet and the new subnet are in the same virtual network. </summary>
    public partial class VirtualMachineScaleSetUpdateIPConfiguration : WritableSubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateIPConfiguration. </summary>
        public VirtualMachineScaleSetUpdateIPConfiguration()
        {
            ApplicationGatewayBackendAddressPools = new ChangeTrackingList<SubResource>();
            ApplicationSecurityGroups = new ChangeTrackingList<SubResource>();
            LoadBalancerBackendAddressPools = new ChangeTrackingList<SubResource>();
            LoadBalancerInboundNatPools = new ChangeTrackingList<SubResource>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateIPConfiguration. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The IP configuration name. </param>
        /// <param name="subnet"> The subnet. </param>
        /// <param name="primary"> Specifies the primary IP Configuration in case the network interface has more than one IP Configuration. </param>
        /// <param name="publicIPAddressConfiguration"> The publicIPAddressConfiguration. </param>
        /// <param name="privateIPAddressVersion"> Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: &apos;IPv4&apos; and &apos;IPv6&apos;. </param>
        /// <param name="applicationGatewayBackendAddressPools"> The application gateway backend address pools. </param>
        /// <param name="applicationSecurityGroups"> Specifies an array of references to application security group. </param>
        /// <param name="loadBalancerBackendAddressPools"> The load balancer backend address pools. </param>
        /// <param name="loadBalancerInboundNatPools"> The load balancer inbound nat pools. </param>
        internal VirtualMachineScaleSetUpdateIPConfiguration(string id, string name, ApiEntityReference subnet, bool? primary, VirtualMachineScaleSetUpdatePublicIPAddressConfiguration publicIPAddressConfiguration, IPVersion? privateIPAddressVersion, IList<SubResource> applicationGatewayBackendAddressPools, IList<SubResource> applicationSecurityGroups, IList<SubResource> loadBalancerBackendAddressPools, IList<SubResource> loadBalancerInboundNatPools) : base(id)
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

        /// <summary> The IP configuration name. </summary>
        public string Name { get; set; }
        /// <summary> The subnet. </summary>
        public ApiEntityReference Subnet { get; set; }
        /// <summary> Specifies the primary IP Configuration in case the network interface has more than one IP Configuration. </summary>
        public bool? Primary { get; set; }
        /// <summary> The publicIPAddressConfiguration. </summary>
        public VirtualMachineScaleSetUpdatePublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }
        /// <summary> Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: &apos;IPv4&apos; and &apos;IPv6&apos;. </summary>
        public IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary> The application gateway backend address pools. </summary>
        public IList<SubResource> ApplicationGatewayBackendAddressPools { get; }
        /// <summary> Specifies an array of references to application security group. </summary>
        public IList<SubResource> ApplicationSecurityGroups { get; }
        /// <summary> The load balancer backend address pools. </summary>
        public IList<SubResource> LoadBalancerBackendAddressPools { get; }
        /// <summary> The load balancer inbound nat pools. </summary>
        public IList<SubResource> LoadBalancerInboundNatPools { get; }
    }
}
