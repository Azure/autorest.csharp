// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Route resource. </summary>
    public partial class Route : SubResource
    {
        /// <summary> Initializes a new instance of <see cref="Route"/>. </summary>
        public Route()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Route"/>. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="addressPrefix"> The destination CIDR to which the route applies. </param>
        /// <param name="nextHopType"> The type of Azure hop the packet should be sent to. </param>
        /// <param name="nextHopIpAddress"> The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance. </param>
        /// <param name="provisioningState"> The provisioning state of the route resource. </param>
        internal Route(string id, string name, string etag, string addressPrefix, RouteNextHopType? nextHopType, string nextHopIpAddress, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            AddressPrefix = addressPrefix;
            NextHopType = nextHopType;
            NextHopIpAddress = nextHopIpAddress;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The destination CIDR to which the route applies. </summary>
        public string AddressPrefix { get; set; }
        /// <summary> The type of Azure hop the packet should be sent to. </summary>
        public RouteNextHopType? NextHopType { get; set; }
        /// <summary> The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance. </summary>
        public string NextHopIpAddress { get; set; }
        /// <summary> The provisioning state of the route resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
