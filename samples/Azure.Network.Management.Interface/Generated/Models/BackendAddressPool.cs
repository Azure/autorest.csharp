// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Pool of backend IP addresses. </summary>
    public partial class BackendAddressPool : SubResource
    {
        /// <summary> Initializes a new instance of BackendAddressPool. </summary>
        public BackendAddressPool()
        {
            BackendIPConfigurations = new ChangeTrackingList<NetworkInterfaceIPConfiguration>();
            LoadBalancingRules = new ChangeTrackingList<SubResource>();
            OutboundRules = new ChangeTrackingList<SubResource>();
        }

        /// <summary> Initializes a new instance of BackendAddressPool. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of backend address pools used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="backendIPConfigurations"> An array of references to IP addresses defined in network interfaces. </param>
        /// <param name="loadBalancingRules"> An array of references to load balancing rules that use this backend address pool. </param>
        /// <param name="outboundRule"> A reference to an outbound rule that uses this backend address pool. </param>
        /// <param name="outboundRules"> An array of references to outbound rules that use this backend address pool. </param>
        /// <param name="provisioningState"> The provisioning state of the backend address pool resource. </param>
        internal BackendAddressPool(string id, string name, string etag, string type, IReadOnlyList<NetworkInterfaceIPConfiguration> backendIPConfigurations, IReadOnlyList<SubResource> loadBalancingRules, SubResource outboundRule, IReadOnlyList<SubResource> outboundRules, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            BackendIPConfigurations = backendIPConfigurations;
            LoadBalancingRules = loadBalancingRules;
            OutboundRule = outboundRule;
            OutboundRules = outboundRules;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within the set of backend address pools used by the load balancer. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Type of the resource. </summary>
        public string Type { get; }
        /// <summary> An array of references to IP addresses defined in network interfaces. </summary>
        public IReadOnlyList<NetworkInterfaceIPConfiguration> BackendIPConfigurations { get; }
        /// <summary> An array of references to load balancing rules that use this backend address pool. </summary>
        public IReadOnlyList<SubResource> LoadBalancingRules { get; }
        /// <summary> A reference to an outbound rule that uses this backend address pool. </summary>
        public SubResource OutboundRule { get; }
        /// <summary> An array of references to outbound rules that use this backend address pool. </summary>
        public IReadOnlyList<SubResource> OutboundRules { get; }
        /// <summary> The provisioning state of the backend address pool resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
