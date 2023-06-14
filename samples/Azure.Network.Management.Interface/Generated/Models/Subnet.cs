// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Subnet in a virtual network resource. </summary>
    public partial class Subnet : SubResource
    {
        /// <summary> Initializes a new instance of Subnet. </summary>
        public Subnet()
        {
            AddressPrefixes = new ChangeTrackingList<string>();
            ServiceEndpoints = new ChangeTrackingList<ServiceEndpointPropertiesFormat>();
            ServiceEndpointPolicies = new ChangeTrackingList<ServiceEndpointPolicy>();
            PrivateEndpoints = new ChangeTrackingList<PrivateEndpoint>();
            IpConfigurations = new ChangeTrackingList<IPConfiguration>();
            IpConfigurationProfiles = new ChangeTrackingList<IPConfigurationProfile>();
            ResourceNavigationLinks = new ChangeTrackingList<ResourceNavigationLink>();
            ServiceAssociationLinks = new ChangeTrackingList<ServiceAssociationLink>();
            Delegations = new ChangeTrackingList<Delegation>();
        }

        /// <summary> Initializes a new instance of Subnet. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="addressPrefix"> The address prefix for the subnet. </param>
        /// <param name="addressPrefixes"> List of address prefixes for the subnet. </param>
        /// <param name="networkSecurityGroup"> The reference to the NetworkSecurityGroup resource. </param>
        /// <param name="routeTable"> The reference to the RouteTable resource. </param>
        /// <param name="natGateway"> Nat gateway associated with this subnet. </param>
        /// <param name="serviceEndpoints"> An array of service endpoints. </param>
        /// <param name="serviceEndpointPolicies"> An array of service endpoint policies. </param>
        /// <param name="privateEndpoints"> An array of references to private endpoints. </param>
        /// <param name="ipConfigurations"> An array of references to the network interface IP configurations using subnet. </param>
        /// <param name="ipConfigurationProfiles"> Array of IP configuration profiles which reference this subnet. </param>
        /// <param name="resourceNavigationLinks"> An array of references to the external resources using subnet. </param>
        /// <param name="serviceAssociationLinks"> An array of references to services injecting into this subnet. </param>
        /// <param name="delegations"> An array of references to the delegations on the subnet. </param>
        /// <param name="purpose"> A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties. </param>
        /// <param name="provisioningState"> The provisioning state of the subnet resource. </param>
        /// <param name="privateEndpointNetworkPolicies"> Enable or Disable apply network policies on private end point in the subnet. </param>
        /// <param name="privateLinkServiceNetworkPolicies"> Enable or Disable apply network policies on private link service in the subnet. </param>
        internal Subnet(string id, string name, string etag, string addressPrefix, IList<string> addressPrefixes, NetworkSecurityGroup networkSecurityGroup, RouteTable routeTable, SubResource natGateway, IList<ServiceEndpointPropertiesFormat> serviceEndpoints, IList<ServiceEndpointPolicy> serviceEndpointPolicies, IReadOnlyList<PrivateEndpoint> privateEndpoints, IReadOnlyList<IPConfiguration> ipConfigurations, IReadOnlyList<IPConfigurationProfile> ipConfigurationProfiles, IReadOnlyList<ResourceNavigationLink> resourceNavigationLinks, IReadOnlyList<ServiceAssociationLink> serviceAssociationLinks, IList<Delegation> delegations, string purpose, ProvisioningState? provisioningState, string privateEndpointNetworkPolicies, string privateLinkServiceNetworkPolicies) : base(id)
        {
            Name = name;
            Etag = etag;
            AddressPrefix = addressPrefix;
            AddressPrefixes = addressPrefixes;
            NetworkSecurityGroup = networkSecurityGroup;
            RouteTable = routeTable;
            NatGateway = natGateway;
            ServiceEndpoints = serviceEndpoints;
            ServiceEndpointPolicies = serviceEndpointPolicies;
            PrivateEndpoints = privateEndpoints;
            IpConfigurations = ipConfigurations;
            IpConfigurationProfiles = ipConfigurationProfiles;
            ResourceNavigationLinks = resourceNavigationLinks;
            ServiceAssociationLinks = serviceAssociationLinks;
            Delegations = delegations;
            Purpose = purpose;
            ProvisioningState = provisioningState;
            PrivateEndpointNetworkPolicies = privateEndpointNetworkPolicies;
            PrivateLinkServiceNetworkPolicies = privateLinkServiceNetworkPolicies;
        }

        /// <summary> The name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> The address prefix for the subnet. </summary>
        public string AddressPrefix { get; set; }
        /// <summary> List of address prefixes for the subnet. </summary>
        public IList<string> AddressPrefixes { get; }
        /// <summary> The reference to the NetworkSecurityGroup resource. </summary>
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }
        /// <summary> The reference to the RouteTable resource. </summary>
        public RouteTable RouteTable { get; set; }
        /// <summary> Nat gateway associated with this subnet. </summary>
        public SubResource NatGateway { get; set; }
        /// <summary> An array of service endpoints. </summary>
        public IList<ServiceEndpointPropertiesFormat> ServiceEndpoints { get; }
        /// <summary> An array of service endpoint policies. </summary>
        public IList<ServiceEndpointPolicy> ServiceEndpointPolicies { get; }
        /// <summary> An array of references to private endpoints. </summary>
        public IReadOnlyList<PrivateEndpoint> PrivateEndpoints { get; }
        /// <summary> An array of references to the network interface IP configurations using subnet. </summary>
        public IReadOnlyList<IPConfiguration> IpConfigurations { get; }
        /// <summary> Array of IP configuration profiles which reference this subnet. </summary>
        public IReadOnlyList<IPConfigurationProfile> IpConfigurationProfiles { get; }
        /// <summary> An array of references to the external resources using subnet. </summary>
        public IReadOnlyList<ResourceNavigationLink> ResourceNavigationLinks { get; }
        /// <summary> An array of references to services injecting into this subnet. </summary>
        public IReadOnlyList<ServiceAssociationLink> ServiceAssociationLinks { get; }
        /// <summary> An array of references to the delegations on the subnet. </summary>
        public IList<Delegation> Delegations { get; }
        /// <summary> A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties. </summary>
        public string Purpose { get; }
        /// <summary> The provisioning state of the subnet resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> Enable or Disable apply network policies on private end point in the subnet. </summary>
        public string PrivateEndpointNetworkPolicies { get; set; }
        /// <summary> Enable or Disable apply network policies on private link service in the subnet. </summary>
        public string PrivateLinkServiceNetworkPolicies { get; set; }
    }
}
