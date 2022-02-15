// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary> Describes a virtual machine scale set network profile&apos;s IP configuration. </summary>
    public partial class VirtualMachineScaleSetIPConfiguration : SubResource
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetIPConfiguration. </summary>
        /// <param name="name"> The IP configuration name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VirtualMachineScaleSetIPConfiguration(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            ApplicationGatewayBackendAddressPools = new ChangeTrackingList<WritableSubResource>();
            ApplicationSecurityGroups = new ChangeTrackingList<WritableSubResource>();
            LoadBalancerBackendAddressPools = new ChangeTrackingList<WritableSubResource>();
            LoadBalancerInboundNatPools = new ChangeTrackingList<WritableSubResource>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetIPConfiguration. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> The IP configuration name. </param>
        /// <param name="subnet"> Specifies the identifier of the subnet. </param>
        /// <param name="primary"> Specifies the primary network interface in case the virtual machine has more than 1 network interface. </param>
        /// <param name="publicIPAddressConfiguration"> The publicIPAddressConfiguration. </param>
        /// <param name="privateIPAddressVersion"> Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: &apos;IPv4&apos; and &apos;IPv6&apos;. </param>
        /// <param name="applicationGatewayBackendAddressPools"> Specifies an array of references to backend address pools of application gateways. A scale set can reference backend address pools of multiple application gateways. Multiple scale sets cannot use the same application gateway. </param>
        /// <param name="applicationSecurityGroups"> Specifies an array of references to application security group. </param>
        /// <param name="loadBalancerBackendAddressPools"> Specifies an array of references to backend address pools of load balancers. A scale set can reference backend address pools of one public and one internal load balancer. Multiple scale sets cannot use the same basic sku load balancer. </param>
        /// <param name="loadBalancerInboundNatPools"> Specifies an array of references to inbound Nat pools of the load balancers. A scale set can reference inbound nat pools of one public and one internal load balancer. Multiple scale sets cannot use the same basic sku load balancer. </param>
        internal VirtualMachineScaleSetIPConfiguration(string id, string name, WritableSubResource subnet, bool? primary, VirtualMachineScaleSetPublicIPAddressConfiguration publicIPAddressConfiguration, IPVersion? privateIPAddressVersion, IList<WritableSubResource> applicationGatewayBackendAddressPools, IList<WritableSubResource> applicationSecurityGroups, IList<WritableSubResource> loadBalancerBackendAddressPools, IList<WritableSubResource> loadBalancerInboundNatPools) : base(id)
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
        /// <summary> Specifies the identifier of the subnet. </summary>
        public WritableSubResource Subnet { get; set; }
        /// <summary> Specifies the primary network interface in case the virtual machine has more than 1 network interface. </summary>
        public bool? Primary { get; set; }
        /// <summary> The publicIPAddressConfiguration. </summary>
        public VirtualMachineScaleSetPublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }
        /// <summary> Available from Api-Version 2017-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: &apos;IPv4&apos; and &apos;IPv6&apos;. </summary>
        public IPVersion? PrivateIPAddressVersion { get; set; }
        /// <summary> Specifies an array of references to backend address pools of application gateways. A scale set can reference backend address pools of multiple application gateways. Multiple scale sets cannot use the same application gateway. </summary>
        public IList<WritableSubResource> ApplicationGatewayBackendAddressPools { get; }
        /// <summary> Specifies an array of references to application security group. </summary>
        public IList<WritableSubResource> ApplicationSecurityGroups { get; }
        /// <summary> Specifies an array of references to backend address pools of load balancers. A scale set can reference backend address pools of one public and one internal load balancer. Multiple scale sets cannot use the same basic sku load balancer. </summary>
        public IList<WritableSubResource> LoadBalancerBackendAddressPools { get; }
        /// <summary> Specifies an array of references to inbound Nat pools of the load balancers. A scale set can reference inbound nat pools of one public and one internal load balancer. Multiple scale sets cannot use the same basic sku load balancer. </summary>
        public IList<WritableSubResource> LoadBalancerInboundNatPools { get; }
    }
}
