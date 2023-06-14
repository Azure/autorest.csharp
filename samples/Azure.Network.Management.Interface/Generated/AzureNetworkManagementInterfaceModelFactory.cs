// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AzureNetworkManagementInterfaceModelFactory
    {
        /// <summary> Initializes a new instance of NetworkInterface. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="virtualMachine"> The reference to a virtual machine. </param>
        /// <param name="networkSecurityGroup"> The reference to the NetworkSecurityGroup resource. </param>
        /// <param name="privateEndpoint"> A reference to the private endpoint to which the network interface is linked. </param>
        /// <param name="ipConfigurations"> A list of IPConfigurations of the network interface. </param>
        /// <param name="tapConfigurations"> A list of TapConfigurations of the network interface. </param>
        /// <param name="dnsSettings"> The DNS settings in network interface. </param>
        /// <param name="macAddress"> The MAC address of the network interface. </param>
        /// <param name="primary"> Whether this is a primary network interface on a virtual machine. </param>
        /// <param name="enableAcceleratedNetworking"> If the network interface is accelerated networking enabled. </param>
        /// <param name="enableIPForwarding"> Indicates whether IP forwarding is enabled on this network interface. </param>
        /// <param name="hostedWorkloads"> A list of references to linked BareMetal resources. </param>
        /// <param name="resourceGuid"> The resource GUID property of the network interface resource. </param>
        /// <param name="provisioningState"> The provisioning state of the network interface resource. </param>
        /// <returns> A new <see cref="Models.NetworkInterface"/> instance for mocking. </returns>
        public static NetworkInterface NetworkInterface(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, SubResource virtualMachine = null, NetworkSecurityGroup networkSecurityGroup = null, PrivateEndpoint privateEndpoint = null, IEnumerable<NetworkInterfaceIPConfiguration> ipConfigurations = null, IEnumerable<NetworkInterfaceTapConfiguration> tapConfigurations = null, NetworkInterfaceDnsSettings dnsSettings = null, string macAddress = null, bool? primary = null, bool? enableAcceleratedNetworking = null, bool? enableIPForwarding = null, IEnumerable<string> hostedWorkloads = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            ipConfigurations ??= new List<NetworkInterfaceIPConfiguration>();
            tapConfigurations ??= new List<NetworkInterfaceTapConfiguration>();
            hostedWorkloads ??= new List<string>();

            return new NetworkInterface(id, name, type, location, tags, etag, virtualMachine, networkSecurityGroup, privateEndpoint, ipConfigurations?.ToList(), tapConfigurations?.ToList(), dnsSettings, macAddress, primary, enableAcceleratedNetworking, enableIPForwarding, hostedWorkloads?.ToList(), resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of NetworkSecurityGroup. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="securityRules"> A collection of security rules of the network security group. </param>
        /// <param name="defaultSecurityRules"> The default security rules of network security group. </param>
        /// <param name="networkInterfaces"> A collection of references to network interfaces. </param>
        /// <param name="subnets"> A collection of references to subnets. </param>
        /// <param name="resourceGuid"> The resource GUID property of the network security group resource. </param>
        /// <param name="provisioningState"> The provisioning state of the network security group resource. </param>
        /// <returns> A new <see cref="Models.NetworkSecurityGroup"/> instance for mocking. </returns>
        public static NetworkSecurityGroup NetworkSecurityGroup(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, IEnumerable<SecurityRule> securityRules = null, IEnumerable<SecurityRule> defaultSecurityRules = null, IEnumerable<NetworkInterface> networkInterfaces = null, IEnumerable<Subnet> subnets = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            securityRules ??= new List<SecurityRule>();
            defaultSecurityRules ??= new List<SecurityRule>();
            networkInterfaces ??= new List<NetworkInterface>();
            subnets ??= new List<Subnet>();

            return new NetworkSecurityGroup(id, name, type, location, tags, etag, securityRules?.ToList(), defaultSecurityRules?.ToList(), networkInterfaces?.ToList(), subnets?.ToList(), resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of SecurityRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="description"> A description for this rule. Restricted to 140 chars. </param>
        /// <param name="protocol"> Network protocol this rule applies to. </param>
        /// <param name="sourcePortRange"> The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports. </param>
        /// <param name="destinationPortRange"> The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports. </param>
        /// <param name="sourceAddressPrefix"> The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. </param>
        /// <param name="sourceAddressPrefixes"> The CIDR or source IP ranges. </param>
        /// <param name="sourceApplicationSecurityGroups"> The application security group specified as source. </param>
        /// <param name="destinationAddressPrefix"> The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. </param>
        /// <param name="destinationAddressPrefixes"> The destination address prefixes. CIDR or destination IP ranges. </param>
        /// <param name="destinationApplicationSecurityGroups"> The application security group specified as destination. </param>
        /// <param name="sourcePortRanges"> The source port ranges. </param>
        /// <param name="destinationPortRanges"> The destination port ranges. </param>
        /// <param name="access"> The network traffic is allowed or denied. </param>
        /// <param name="priority"> The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule. </param>
        /// <param name="direction"> The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. </param>
        /// <param name="provisioningState"> The provisioning state of the security rule resource. </param>
        /// <returns> A new <see cref="Models.SecurityRule"/> instance for mocking. </returns>
        public static SecurityRule SecurityRule(string id = null, string name = null, string etag = null, string description = null, SecurityRuleProtocol? protocol = null, string sourcePortRange = null, string destinationPortRange = null, string sourceAddressPrefix = null, IEnumerable<string> sourceAddressPrefixes = null, IEnumerable<ApplicationSecurityGroup> sourceApplicationSecurityGroups = null, string destinationAddressPrefix = null, IEnumerable<string> destinationAddressPrefixes = null, IEnumerable<ApplicationSecurityGroup> destinationApplicationSecurityGroups = null, IEnumerable<string> sourcePortRanges = null, IEnumerable<string> destinationPortRanges = null, SecurityRuleAccess? access = null, int? priority = null, SecurityRuleDirection? direction = null, ProvisioningState? provisioningState = null)
        {
            sourceAddressPrefixes ??= new List<string>();
            sourceApplicationSecurityGroups ??= new List<ApplicationSecurityGroup>();
            destinationAddressPrefixes ??= new List<string>();
            destinationApplicationSecurityGroups ??= new List<ApplicationSecurityGroup>();
            sourcePortRanges ??= new List<string>();
            destinationPortRanges ??= new List<string>();

            return new SecurityRule(id, name, etag, description, protocol, sourcePortRange, destinationPortRange, sourceAddressPrefix, sourceAddressPrefixes?.ToList(), sourceApplicationSecurityGroups?.ToList(), destinationAddressPrefix, destinationAddressPrefixes?.ToList(), destinationApplicationSecurityGroups?.ToList(), sourcePortRanges?.ToList(), destinationPortRanges?.ToList(), access, priority, direction, provisioningState);
        }

        /// <summary> Initializes a new instance of ApplicationSecurityGroup. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="resourceGuid"> The resource GUID property of the application security group resource. It uniquely identifies a resource, even if the user changes its name or migrate the resource across subscriptions or resource groups. </param>
        /// <param name="provisioningState"> The provisioning state of the application security group resource. </param>
        /// <returns> A new <see cref="Models.ApplicationSecurityGroup"/> instance for mocking. </returns>
        public static ApplicationSecurityGroup ApplicationSecurityGroup(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();

            return new ApplicationSecurityGroup(id, name, type, location, tags, etag, resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <returns> A new <see cref="Models.Resource"/> instance for mocking. </returns>
        public static Resource Resource(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null)
        {
            tags ??= new Dictionary<string, string>();

            return new Resource(id, name, type, location, tags);
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
        /// <returns> A new <see cref="Models.Subnet"/> instance for mocking. </returns>
        public static Subnet Subnet(string id = null, string name = null, string etag = null, string addressPrefix = null, IEnumerable<string> addressPrefixes = null, NetworkSecurityGroup networkSecurityGroup = null, RouteTable routeTable = null, SubResource natGateway = null, IEnumerable<ServiceEndpointPropertiesFormat> serviceEndpoints = null, IEnumerable<ServiceEndpointPolicy> serviceEndpointPolicies = null, IEnumerable<PrivateEndpoint> privateEndpoints = null, IEnumerable<IPConfiguration> ipConfigurations = null, IEnumerable<IPConfigurationProfile> ipConfigurationProfiles = null, IEnumerable<ResourceNavigationLink> resourceNavigationLinks = null, IEnumerable<ServiceAssociationLink> serviceAssociationLinks = null, IEnumerable<Delegation> delegations = null, string purpose = null, ProvisioningState? provisioningState = null, string privateEndpointNetworkPolicies = null, string privateLinkServiceNetworkPolicies = null)
        {
            addressPrefixes ??= new List<string>();
            serviceEndpoints ??= new List<ServiceEndpointPropertiesFormat>();
            serviceEndpointPolicies ??= new List<ServiceEndpointPolicy>();
            privateEndpoints ??= new List<PrivateEndpoint>();
            ipConfigurations ??= new List<IPConfiguration>();
            ipConfigurationProfiles ??= new List<IPConfigurationProfile>();
            resourceNavigationLinks ??= new List<ResourceNavigationLink>();
            serviceAssociationLinks ??= new List<ServiceAssociationLink>();
            delegations ??= new List<Delegation>();

            return new Subnet(id, name, etag, addressPrefix, addressPrefixes?.ToList(), networkSecurityGroup, routeTable, natGateway, serviceEndpoints?.ToList(), serviceEndpointPolicies?.ToList(), privateEndpoints?.ToList(), ipConfigurations?.ToList(), ipConfigurationProfiles?.ToList(), resourceNavigationLinks?.ToList(), serviceAssociationLinks?.ToList(), delegations?.ToList(), purpose, provisioningState, privateEndpointNetworkPolicies, privateLinkServiceNetworkPolicies);
        }

        /// <summary> Initializes a new instance of RouteTable. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="routes"> Collection of routes contained within a route table. </param>
        /// <param name="subnets"> A collection of references to subnets. </param>
        /// <param name="disableBgpRoutePropagation"> Whether to disable the routes learned by BGP on that route table. True means disable. </param>
        /// <param name="provisioningState"> The provisioning state of the route table resource. </param>
        /// <returns> A new <see cref="Models.RouteTable"/> instance for mocking. </returns>
        public static RouteTable RouteTable(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, IEnumerable<Route> routes = null, IEnumerable<Subnet> subnets = null, bool? disableBgpRoutePropagation = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            routes ??= new List<Route>();
            subnets ??= new List<Subnet>();

            return new RouteTable(id, name, type, location, tags, etag, routes?.ToList(), subnets?.ToList(), disableBgpRoutePropagation, provisioningState);
        }

        /// <summary> Initializes a new instance of Route. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="addressPrefix"> The destination CIDR to which the route applies. </param>
        /// <param name="nextHopType"> The type of Azure hop the packet should be sent to. </param>
        /// <param name="nextHopIpAddress"> The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance. </param>
        /// <param name="provisioningState"> The provisioning state of the route resource. </param>
        /// <returns> A new <see cref="Models.Route"/> instance for mocking. </returns>
        public static Route Route(string id = null, string name = null, string etag = null, string addressPrefix = null, RouteNextHopType? nextHopType = null, string nextHopIpAddress = null, ProvisioningState? provisioningState = null)
        {
            return new Route(id, name, etag, addressPrefix, nextHopType, nextHopIpAddress, provisioningState);
        }

        /// <summary> Initializes a new instance of ServiceEndpointPropertiesFormat. </summary>
        /// <param name="service"> The type of the endpoint service. </param>
        /// <param name="locations"> A list of locations. </param>
        /// <param name="provisioningState"> The provisioning state of the service endpoint resource. </param>
        /// <returns> A new <see cref="Models.ServiceEndpointPropertiesFormat"/> instance for mocking. </returns>
        public static ServiceEndpointPropertiesFormat ServiceEndpointPropertiesFormat(string service = null, IEnumerable<string> locations = null, ProvisioningState? provisioningState = null)
        {
            locations ??= new List<string>();

            return new ServiceEndpointPropertiesFormat(service, locations?.ToList(), provisioningState);
        }

        /// <summary> Initializes a new instance of ServiceEndpointPolicy. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="serviceEndpointPolicyDefinitions"> A collection of service endpoint policy definitions of the service endpoint policy. </param>
        /// <param name="subnets"> A collection of references to subnets. </param>
        /// <param name="resourceGuid"> The resource GUID property of the service endpoint policy resource. </param>
        /// <param name="provisioningState"> The provisioning state of the service endpoint policy resource. </param>
        /// <returns> A new <see cref="Models.ServiceEndpointPolicy"/> instance for mocking. </returns>
        public static ServiceEndpointPolicy ServiceEndpointPolicy(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, IEnumerable<ServiceEndpointPolicyDefinition> serviceEndpointPolicyDefinitions = null, IEnumerable<Subnet> subnets = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            serviceEndpointPolicyDefinitions ??= new List<ServiceEndpointPolicyDefinition>();
            subnets ??= new List<Subnet>();

            return new ServiceEndpointPolicy(id, name, type, location, tags, etag, serviceEndpointPolicyDefinitions?.ToList(), subnets?.ToList(), resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of ServiceEndpointPolicyDefinition. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="description"> A description for this rule. Restricted to 140 chars. </param>
        /// <param name="service"> Service endpoint name. </param>
        /// <param name="serviceResources"> A list of service resources. </param>
        /// <param name="provisioningState"> The provisioning state of the service endpoint policy definition resource. </param>
        /// <returns> A new <see cref="Models.ServiceEndpointPolicyDefinition"/> instance for mocking. </returns>
        public static ServiceEndpointPolicyDefinition ServiceEndpointPolicyDefinition(string id = null, string name = null, string etag = null, string description = null, string service = null, IEnumerable<string> serviceResources = null, ProvisioningState? provisioningState = null)
        {
            serviceResources ??= new List<string>();

            return new ServiceEndpointPolicyDefinition(id, name, etag, description, service, serviceResources?.ToList(), provisioningState);
        }

        /// <summary> Initializes a new instance of PrivateEndpoint. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="subnet"> The ID of the subnet from which the private IP will be allocated. </param>
        /// <param name="networkInterfaces"> An array of references to the network interfaces created for this private endpoint. </param>
        /// <param name="provisioningState"> The provisioning state of the private endpoint resource. </param>
        /// <param name="privateLinkServiceConnections"> A grouping of information about the connection to the remote resource. </param>
        /// <param name="manualPrivateLinkServiceConnections"> A grouping of information about the connection to the remote resource. Used when the network admin does not have access to approve connections to the remote resource. </param>
        /// <returns> A new <see cref="Models.PrivateEndpoint"/> instance for mocking. </returns>
        public static PrivateEndpoint PrivateEndpoint(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, Subnet subnet = null, IEnumerable<NetworkInterface> networkInterfaces = null, ProvisioningState? provisioningState = null, IEnumerable<PrivateLinkServiceConnection> privateLinkServiceConnections = null, IEnumerable<PrivateLinkServiceConnection> manualPrivateLinkServiceConnections = null)
        {
            tags ??= new Dictionary<string, string>();
            networkInterfaces ??= new List<NetworkInterface>();
            privateLinkServiceConnections ??= new List<PrivateLinkServiceConnection>();
            manualPrivateLinkServiceConnections ??= new List<PrivateLinkServiceConnection>();

            return new PrivateEndpoint(id, name, type, location, tags, etag, subnet, networkInterfaces?.ToList(), provisioningState, privateLinkServiceConnections?.ToList(), manualPrivateLinkServiceConnections?.ToList());
        }

        /// <summary> Initializes a new instance of PrivateLinkServiceConnection. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="type"> The resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="provisioningState"> The provisioning state of the private link service connection resource. </param>
        /// <param name="privateLinkServiceId"> The resource id of private link service. </param>
        /// <param name="groupIds"> The ID(s) of the group(s) obtained from the remote resource that this private endpoint should connect to. </param>
        /// <param name="requestMessage"> A message passed to the owner of the remote resource with this connection request. Restricted to 140 chars. </param>
        /// <param name="privateLinkServiceConnectionState"> A collection of read-only information about the state of the connection to the remote resource. </param>
        /// <returns> A new <see cref="Models.PrivateLinkServiceConnection"/> instance for mocking. </returns>
        public static PrivateLinkServiceConnection PrivateLinkServiceConnection(string id = null, string name = null, string type = null, string etag = null, ProvisioningState? provisioningState = null, string privateLinkServiceId = null, IEnumerable<string> groupIds = null, string requestMessage = null, PrivateLinkServiceConnectionState privateLinkServiceConnectionState = null)
        {
            groupIds ??= new List<string>();

            return new PrivateLinkServiceConnection(id, name, type, etag, provisioningState, privateLinkServiceId, groupIds?.ToList(), requestMessage, privateLinkServiceConnectionState);
        }

        /// <summary> Initializes a new instance of IPConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="privateIPAddress"> The private IP address of the IP configuration. </param>
        /// <param name="privateIPAllocationMethod"> The private IP address allocation method. </param>
        /// <param name="subnet"> The reference to the subnet resource. </param>
        /// <param name="publicIPAddress"> The reference to the public IP resource. </param>
        /// <param name="provisioningState"> The provisioning state of the IP configuration resource. </param>
        /// <returns> A new <see cref="Models.IPConfiguration"/> instance for mocking. </returns>
        public static IPConfiguration IPConfiguration(string id = null, string name = null, string etag = null, string privateIPAddress = null, IPAllocationMethod? privateIPAllocationMethod = null, Subnet subnet = null, PublicIPAddress publicIPAddress = null, ProvisioningState? provisioningState = null)
        {
            return new IPConfiguration(id, name, etag, privateIPAddress, privateIPAllocationMethod, subnet, publicIPAddress, provisioningState);
        }

        /// <summary> Initializes a new instance of PublicIPAddress. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="sku"> The public IP address SKU. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="zones"> A list of availability zones denoting the IP allocated for the resource needs to come from. </param>
        /// <param name="publicIPAllocationMethod"> The public IP address allocation method. </param>
        /// <param name="publicIPAddressVersion"> The public IP address version. </param>
        /// <param name="ipConfiguration"> The IP configuration associated with the public IP address. </param>
        /// <param name="dnsSettings"> The FQDN of the DNS record associated with the public IP address. </param>
        /// <param name="ddosSettings"> The DDoS protection custom policy associated with the public IP address. </param>
        /// <param name="ipTags"> The list of tags associated with the public IP address. </param>
        /// <param name="ipAddress"> The IP address associated with the public IP address resource. </param>
        /// <param name="publicIPPrefix"> The Public IP Prefix this Public IP Address should be allocated from. </param>
        /// <param name="idleTimeoutInMinutes"> The idle timeout of the public IP address. </param>
        /// <param name="resourceGuid"> The resource GUID property of the public IP address resource. </param>
        /// <param name="provisioningState"> The provisioning state of the public IP address resource. </param>
        /// <returns> A new <see cref="Models.PublicIPAddress"/> instance for mocking. </returns>
        public static PublicIPAddress PublicIPAddress(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, PublicIPAddressSku sku = null, string etag = null, IEnumerable<string> zones = null, IPAllocationMethod? publicIPAllocationMethod = null, IPVersion? publicIPAddressVersion = null, IPConfiguration ipConfiguration = null, PublicIPAddressDnsSettings dnsSettings = null, DdosSettings ddosSettings = null, IEnumerable<IpTag> ipTags = null, string ipAddress = null, SubResource publicIPPrefix = null, int? idleTimeoutInMinutes = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            zones ??= new List<string>();
            ipTags ??= new List<IpTag>();

            return new PublicIPAddress(id, name, type, location, tags, sku, etag, zones?.ToList(), publicIPAllocationMethod, publicIPAddressVersion, ipConfiguration, dnsSettings, ddosSettings, ipTags?.ToList(), ipAddress, publicIPPrefix, idleTimeoutInMinutes, resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of IPConfigurationProfile. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource. This name can be used to access the resource. </param>
        /// <param name="type"> Sub Resource type. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="subnet"> The reference to the subnet resource to create a container network interface ip configuration. </param>
        /// <param name="provisioningState"> The provisioning state of the IP configuration profile resource. </param>
        /// <returns> A new <see cref="Models.IPConfigurationProfile"/> instance for mocking. </returns>
        public static IPConfigurationProfile IPConfigurationProfile(string id = null, string name = null, string type = null, string etag = null, Subnet subnet = null, ProvisioningState? provisioningState = null)
        {
            return new IPConfigurationProfile(id, name, type, etag, subnet, provisioningState);
        }

        /// <summary> Initializes a new instance of ResourceNavigationLink. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="linkedResourceType"> Resource type of the linked resource. </param>
        /// <param name="link"> Link to the external resource. </param>
        /// <param name="provisioningState"> The provisioning state of the resource navigation link resource. </param>
        /// <returns> A new <see cref="Models.ResourceNavigationLink"/> instance for mocking. </returns>
        public static ResourceNavigationLink ResourceNavigationLink(string id = null, string name = null, string etag = null, string type = null, string linkedResourceType = null, string link = null, ProvisioningState? provisioningState = null)
        {
            return new ResourceNavigationLink(id, name, etag, type, linkedResourceType, link, provisioningState);
        }

        /// <summary> Initializes a new instance of ServiceAssociationLink. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="linkedResourceType"> Resource type of the linked resource. </param>
        /// <param name="link"> Link to the external resource. </param>
        /// <param name="provisioningState"> The provisioning state of the service association link resource. </param>
        /// <param name="allowDelete"> If true, the resource can be deleted. </param>
        /// <param name="locations"> A list of locations. </param>
        /// <returns> A new <see cref="Models.ServiceAssociationLink"/> instance for mocking. </returns>
        public static ServiceAssociationLink ServiceAssociationLink(string id = null, string name = null, string etag = null, string type = null, string linkedResourceType = null, string link = null, ProvisioningState? provisioningState = null, bool? allowDelete = null, IEnumerable<string> locations = null)
        {
            locations ??= new List<string>();

            return new ServiceAssociationLink(id, name, etag, type, linkedResourceType, link, provisioningState, allowDelete, locations?.ToList());
        }

        /// <summary> Initializes a new instance of Delegation. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a subnet. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="serviceName"> The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers). </param>
        /// <param name="actions"> The actions permitted to the service upon delegation. </param>
        /// <param name="provisioningState"> The provisioning state of the service delegation resource. </param>
        /// <returns> A new <see cref="Models.Delegation"/> instance for mocking. </returns>
        public static Delegation Delegation(string id = null, string name = null, string etag = null, string serviceName = null, IEnumerable<string> actions = null, ProvisioningState? provisioningState = null)
        {
            actions ??= new List<string>();

            return new Delegation(id, name, etag, serviceName, actions?.ToList(), provisioningState);
        }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="virtualNetworkTaps"> The reference to Virtual Network Taps. </param>
        /// <param name="applicationGatewayBackendAddressPools"> The reference to ApplicationGatewayBackendAddressPool resource. </param>
        /// <param name="loadBalancerBackendAddressPools"> The reference to LoadBalancerBackendAddressPool resource. </param>
        /// <param name="loadBalancerInboundNatRules"> A list of references of LoadBalancerInboundNatRules. </param>
        /// <param name="privateIPAddress"> Private IP address of the IP configuration. </param>
        /// <param name="privateIPAllocationMethod"> The private IP address allocation method. </param>
        /// <param name="privateIPAddressVersion"> Whether the specific IP configuration is IPv4 or IPv6. Default is IPv4. </param>
        /// <param name="subnet"> Subnet bound to the IP configuration. </param>
        /// <param name="primary"> Whether this is a primary customer address on the network interface. </param>
        /// <param name="publicIPAddress"> Public IP address bound to the IP configuration. </param>
        /// <param name="applicationSecurityGroups"> Application security groups in which the IP configuration is included. </param>
        /// <param name="provisioningState"> The provisioning state of the network interface IP configuration. </param>
        /// <param name="privateLinkConnectionProperties"> PrivateLinkConnection properties for the network interface. </param>
        /// <returns> A new <see cref="Models.NetworkInterfaceIPConfiguration"/> instance for mocking. </returns>
        public static NetworkInterfaceIPConfiguration NetworkInterfaceIPConfiguration(string id = null, string name = null, string etag = null, IEnumerable<VirtualNetworkTap> virtualNetworkTaps = null, IEnumerable<ApplicationGatewayBackendAddressPool> applicationGatewayBackendAddressPools = null, IEnumerable<BackendAddressPool> loadBalancerBackendAddressPools = null, IEnumerable<InboundNatRule> loadBalancerInboundNatRules = null, string privateIPAddress = null, IPAllocationMethod? privateIPAllocationMethod = null, IPVersion? privateIPAddressVersion = null, Subnet subnet = null, bool? primary = null, PublicIPAddress publicIPAddress = null, IEnumerable<ApplicationSecurityGroup> applicationSecurityGroups = null, ProvisioningState? provisioningState = null, NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties privateLinkConnectionProperties = null)
        {
            virtualNetworkTaps ??= new List<VirtualNetworkTap>();
            applicationGatewayBackendAddressPools ??= new List<ApplicationGatewayBackendAddressPool>();
            loadBalancerBackendAddressPools ??= new List<BackendAddressPool>();
            loadBalancerInboundNatRules ??= new List<InboundNatRule>();
            applicationSecurityGroups ??= new List<ApplicationSecurityGroup>();

            return new NetworkInterfaceIPConfiguration(id, name, etag, virtualNetworkTaps?.ToList(), applicationGatewayBackendAddressPools?.ToList(), loadBalancerBackendAddressPools?.ToList(), loadBalancerInboundNatRules?.ToList(), privateIPAddress, privateIPAllocationMethod, privateIPAddressVersion, subnet, primary, publicIPAddress, applicationSecurityGroups?.ToList(), provisioningState, privateLinkConnectionProperties);
        }

        /// <summary> Initializes a new instance of VirtualNetworkTap. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="networkInterfaceTapConfigurations"> Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped. </param>
        /// <param name="resourceGuid"> The resource GUID property of the virtual network tap resource. </param>
        /// <param name="provisioningState"> The provisioning state of the virtual network tap resource. </param>
        /// <param name="destinationNetworkInterfaceIPConfiguration"> The reference to the private IP Address of the collector nic that will receive the tap. </param>
        /// <param name="destinationLoadBalancerFrontEndIPConfiguration"> The reference to the private IP address on the internal Load Balancer that will receive the tap. </param>
        /// <param name="destinationPort"> The VXLAN destination port that will receive the tapped traffic. </param>
        /// <returns> A new <see cref="Models.VirtualNetworkTap"/> instance for mocking. </returns>
        public static VirtualNetworkTap VirtualNetworkTap(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, string etag = null, IEnumerable<NetworkInterfaceTapConfiguration> networkInterfaceTapConfigurations = null, string resourceGuid = null, ProvisioningState? provisioningState = null, NetworkInterfaceIPConfiguration destinationNetworkInterfaceIPConfiguration = null, FrontendIPConfiguration destinationLoadBalancerFrontEndIPConfiguration = null, int? destinationPort = null)
        {
            tags ??= new Dictionary<string, string>();
            networkInterfaceTapConfigurations ??= new List<NetworkInterfaceTapConfiguration>();

            return new VirtualNetworkTap(id, name, type, location, tags, etag, networkInterfaceTapConfigurations?.ToList(), resourceGuid, provisioningState, destinationNetworkInterfaceIPConfiguration, destinationLoadBalancerFrontEndIPConfiguration, destinationPort);
        }

        /// <summary> Initializes a new instance of NetworkInterfaceTapConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within a resource group. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Sub Resource type. </param>
        /// <param name="virtualNetworkTap"> The reference to the Virtual Network Tap resource. </param>
        /// <param name="provisioningState"> The provisioning state of the network interface tap configuration resource. </param>
        /// <returns> A new <see cref="Models.NetworkInterfaceTapConfiguration"/> instance for mocking. </returns>
        public static NetworkInterfaceTapConfiguration NetworkInterfaceTapConfiguration(string id = null, string name = null, string etag = null, string type = null, VirtualNetworkTap virtualNetworkTap = null, ProvisioningState? provisioningState = null)
        {
            return new NetworkInterfaceTapConfiguration(id, name, etag, type, virtualNetworkTap, provisioningState);
        }

        /// <summary> Initializes a new instance of FrontendIPConfiguration. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="zones"> A list of availability zones denoting the IP allocated for the resource needs to come from. </param>
        /// <param name="inboundNatRules"> An array of references to inbound rules that use this frontend IP. </param>
        /// <param name="inboundNatPools"> An array of references to inbound pools that use this frontend IP. </param>
        /// <param name="outboundRules"> An array of references to outbound rules that use this frontend IP. </param>
        /// <param name="loadBalancingRules"> An array of references to load balancing rules that use this frontend IP. </param>
        /// <param name="privateIPAddress"> The private IP address of the IP configuration. </param>
        /// <param name="privateIPAllocationMethod"> The Private IP allocation method. </param>
        /// <param name="privateIPAddressVersion"> Whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4. </param>
        /// <param name="subnet"> The reference to the subnet resource. </param>
        /// <param name="publicIPAddress"> The reference to the Public IP resource. </param>
        /// <param name="publicIPPrefix"> The reference to the Public IP Prefix resource. </param>
        /// <param name="provisioningState"> The provisioning state of the frontend IP configuration resource. </param>
        /// <returns> A new <see cref="Models.FrontendIPConfiguration"/> instance for mocking. </returns>
        public static FrontendIPConfiguration FrontendIPConfiguration(string id = null, string name = null, string etag = null, string type = null, IEnumerable<string> zones = null, IEnumerable<SubResource> inboundNatRules = null, IEnumerable<SubResource> inboundNatPools = null, IEnumerable<SubResource> outboundRules = null, IEnumerable<SubResource> loadBalancingRules = null, string privateIPAddress = null, IPAllocationMethod? privateIPAllocationMethod = null, IPVersion? privateIPAddressVersion = null, Subnet subnet = null, PublicIPAddress publicIPAddress = null, SubResource publicIPPrefix = null, ProvisioningState? provisioningState = null)
        {
            zones ??= new List<string>();
            inboundNatRules ??= new List<SubResource>();
            inboundNatPools ??= new List<SubResource>();
            outboundRules ??= new List<SubResource>();
            loadBalancingRules ??= new List<SubResource>();

            return new FrontendIPConfiguration(id, name, etag, type, zones?.ToList(), inboundNatRules?.ToList(), inboundNatPools?.ToList(), outboundRules?.ToList(), loadBalancingRules?.ToList(), privateIPAddress, privateIPAllocationMethod, privateIPAddressVersion, subnet, publicIPAddress, publicIPPrefix, provisioningState);
        }

        /// <summary> Initializes a new instance of ApplicationGatewayBackendAddressPool. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Name of the backend address pool that is unique within an Application Gateway. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="backendIPConfigurations"> Collection of references to IPs defined in network interfaces. </param>
        /// <param name="backendAddresses"> Backend addresses. </param>
        /// <param name="provisioningState"> The provisioning state of the backend address pool resource. </param>
        /// <returns> A new <see cref="Models.ApplicationGatewayBackendAddressPool"/> instance for mocking. </returns>
        public static ApplicationGatewayBackendAddressPool ApplicationGatewayBackendAddressPool(string id = null, string name = null, string etag = null, string type = null, IEnumerable<NetworkInterfaceIPConfiguration> backendIPConfigurations = null, IEnumerable<ApplicationGatewayBackendAddress> backendAddresses = null, ProvisioningState? provisioningState = null)
        {
            backendIPConfigurations ??= new List<NetworkInterfaceIPConfiguration>();
            backendAddresses ??= new List<ApplicationGatewayBackendAddress>();

            return new ApplicationGatewayBackendAddressPool(id, name, etag, type, backendIPConfigurations?.ToList(), backendAddresses?.ToList(), provisioningState);
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
        /// <returns> A new <see cref="Models.BackendAddressPool"/> instance for mocking. </returns>
        public static BackendAddressPool BackendAddressPool(string id = null, string name = null, string etag = null, string type = null, IEnumerable<NetworkInterfaceIPConfiguration> backendIPConfigurations = null, IEnumerable<SubResource> loadBalancingRules = null, SubResource outboundRule = null, IEnumerable<SubResource> outboundRules = null, ProvisioningState? provisioningState = null)
        {
            backendIPConfigurations ??= new List<NetworkInterfaceIPConfiguration>();
            loadBalancingRules ??= new List<SubResource>();
            outboundRules ??= new List<SubResource>();

            return new BackendAddressPool(id, name, etag, type, backendIPConfigurations?.ToList(), loadBalancingRules?.ToList(), outboundRule, outboundRules?.ToList(), provisioningState);
        }

        /// <summary> Initializes a new instance of InboundNatRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of inbound NAT rules used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="frontendIPConfiguration"> A reference to frontend IP addresses. </param>
        /// <param name="backendIPConfiguration"> A reference to a private IP address defined on a network interface of a VM. Traffic sent to the frontend port of each of the frontend IP configurations is forwarded to the backend IP. </param>
        /// <param name="protocol"> The reference to the transport protocol used by the load balancing rule. </param>
        /// <param name="frontendPort"> The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534. </param>
        /// <param name="backendPort"> The port used for the internal endpoint. Acceptable values range from 1 to 65535. </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </param>
        /// <param name="enableFloatingIP"> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="provisioningState"> The provisioning state of the inbound NAT rule resource. </param>
        /// <returns> A new <see cref="Models.InboundNatRule"/> instance for mocking. </returns>
        public static InboundNatRule InboundNatRule(string id = null, string name = null, string etag = null, string type = null, SubResource frontendIPConfiguration = null, NetworkInterfaceIPConfiguration backendIPConfiguration = null, TransportProtocol? protocol = null, int? frontendPort = null, int? backendPort = null, int? idleTimeoutInMinutes = null, bool? enableFloatingIP = null, bool? enableTcpReset = null, ProvisioningState? provisioningState = null)
        {
            return new InboundNatRule(id, name, etag, type, frontendIPConfiguration, backendIPConfiguration, protocol, frontendPort, backendPort, idleTimeoutInMinutes, enableFloatingIP, enableTcpReset, provisioningState);
        }

        /// <summary> Initializes a new instance of NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties. </summary>
        /// <param name="groupId"> The group ID for current private link connection. </param>
        /// <param name="requiredMemberName"> The required member name for current private link connection. </param>
        /// <param name="fqdns"> List of FQDNs for current private link connection. </param>
        /// <returns> A new <see cref="Models.NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties"/> instance for mocking. </returns>
        public static NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(string groupId = null, string requiredMemberName = null, IEnumerable<string> fqdns = null)
        {
            fqdns ??= new List<string>();

            return new NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties(groupId, requiredMemberName, fqdns?.ToList());
        }

        /// <summary> Initializes a new instance of NetworkInterfaceDnsSettings. </summary>
        /// <param name="dnsServers"> List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection. </param>
        /// <param name="appliedDnsServers"> If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set. This property is what is configured on each of those VMs. </param>
        /// <param name="internalDnsNameLabel"> Relative DNS name for this NIC used for internal communications between VMs in the same virtual network. </param>
        /// <param name="internalFqdn"> Fully qualified DNS name supporting internal communications between VMs in the same virtual network. </param>
        /// <param name="internalDomainNameSuffix"> Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix. </param>
        /// <returns> A new <see cref="Models.NetworkInterfaceDnsSettings"/> instance for mocking. </returns>
        public static NetworkInterfaceDnsSettings NetworkInterfaceDnsSettings(IEnumerable<string> dnsServers = null, IEnumerable<string> appliedDnsServers = null, string internalDnsNameLabel = null, string internalFqdn = null, string internalDomainNameSuffix = null)
        {
            dnsServers ??= new List<string>();
            appliedDnsServers ??= new List<string>();

            return new NetworkInterfaceDnsSettings(dnsServers?.ToList(), appliedDnsServers?.ToList(), internalDnsNameLabel, internalFqdn, internalDomainNameSuffix);
        }

        /// <summary> Initializes a new instance of EffectiveRouteListResult. </summary>
        /// <param name="value"> A list of effective routes. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <returns> A new <see cref="Models.EffectiveRouteListResult"/> instance for mocking. </returns>
        public static EffectiveRouteListResult EffectiveRouteListResult(IEnumerable<EffectiveRoute> value = null, string nextLink = null)
        {
            value ??= new List<EffectiveRoute>();

            return new EffectiveRouteListResult(value?.ToList(), nextLink);
        }

        /// <summary> Initializes a new instance of EffectiveRoute. </summary>
        /// <param name="name"> The name of the user defined route. This is optional. </param>
        /// <param name="disableBgpRoutePropagation"> If true, on-premises routes are not propagated to the network interfaces in the subnet. </param>
        /// <param name="source"> Who created the route. </param>
        /// <param name="state"> The value of effective route. </param>
        /// <param name="addressPrefix"> The address prefixes of the effective routes in CIDR notation. </param>
        /// <param name="nextHopIpAddress"> The IP address of the next hop of the effective route. </param>
        /// <param name="nextHopType"> The type of Azure hop the packet should be sent to. </param>
        /// <returns> A new <see cref="Models.EffectiveRoute"/> instance for mocking. </returns>
        public static EffectiveRoute EffectiveRoute(string name = null, bool? disableBgpRoutePropagation = null, EffectiveRouteSource? source = null, EffectiveRouteState? state = null, IEnumerable<string> addressPrefix = null, IEnumerable<string> nextHopIpAddress = null, RouteNextHopType? nextHopType = null)
        {
            addressPrefix ??= new List<string>();
            nextHopIpAddress ??= new List<string>();

            return new EffectiveRoute(name, disableBgpRoutePropagation, source, state, addressPrefix?.ToList(), nextHopIpAddress?.ToList(), nextHopType);
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupListResult. </summary>
        /// <param name="value"> A list of effective network security groups. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityGroupListResult"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityGroupListResult EffectiveNetworkSecurityGroupListResult(IEnumerable<EffectiveNetworkSecurityGroup> value = null, string nextLink = null)
        {
            value ??= new List<EffectiveNetworkSecurityGroup>();

            return new EffectiveNetworkSecurityGroupListResult(value?.ToList(), nextLink);
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroup. </summary>
        /// <param name="networkSecurityGroup"> The ID of network security group that is applied. </param>
        /// <param name="association"> Associated resources. </param>
        /// <param name="effectiveSecurityRules"> A collection of effective security rules. </param>
        /// <param name="tagMap"> Mapping of tags to list of IP Addresses included within the tag. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityGroup"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityGroup EffectiveNetworkSecurityGroup(SubResource networkSecurityGroup = null, EffectiveNetworkSecurityGroupAssociation association = null, IEnumerable<EffectiveNetworkSecurityRule> effectiveSecurityRules = null, string tagMap = null)
        {
            effectiveSecurityRules ??= new List<EffectiveNetworkSecurityRule>();

            return new EffectiveNetworkSecurityGroup(networkSecurityGroup, association, effectiveSecurityRules?.ToList(), tagMap);
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityGroupAssociation. </summary>
        /// <param name="subnet"> The ID of the subnet if assigned. </param>
        /// <param name="networkInterface"> The ID of the network interface if assigned. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityGroupAssociation"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityGroupAssociation EffectiveNetworkSecurityGroupAssociation(SubResource subnet = null, SubResource networkInterface = null)
        {
            return new EffectiveNetworkSecurityGroupAssociation(subnet, networkInterface);
        }

        /// <summary> Initializes a new instance of EffectiveNetworkSecurityRule. </summary>
        /// <param name="name"> The name of the security rule specified by the user (if created by the user). </param>
        /// <param name="protocol"> The network protocol this rule applies to. </param>
        /// <param name="sourcePortRange"> The source port or range. </param>
        /// <param name="destinationPortRange"> The destination port or range. </param>
        /// <param name="sourcePortRanges"> The source port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g. 100-400), or an asterisk (*). </param>
        /// <param name="destinationPortRanges"> The destination port ranges. Expected values include a single integer between 0 and 65535, a range using '-' as separator (e.g. 100-400), or an asterisk (*). </param>
        /// <param name="sourceAddressPrefix"> The source address prefix. </param>
        /// <param name="destinationAddressPrefix"> The destination address prefix. </param>
        /// <param name="sourceAddressPrefixes"> The source address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer, Internet), System Tags, and the asterisk (*). </param>
        /// <param name="destinationAddressPrefixes"> The destination address prefixes. Expected values include CIDR IP ranges, Default Tags (VirtualNetwork, AzureLoadBalancer, Internet), System Tags, and the asterisk (*). </param>
        /// <param name="expandedSourceAddressPrefix"> The expanded source address prefix. </param>
        /// <param name="expandedDestinationAddressPrefix"> Expanded destination address prefix. </param>
        /// <param name="access"> Whether network traffic is allowed or denied. </param>
        /// <param name="priority"> The priority of the rule. </param>
        /// <param name="direction"> The direction of the rule. </param>
        /// <returns> A new <see cref="Models.EffectiveNetworkSecurityRule"/> instance for mocking. </returns>
        public static EffectiveNetworkSecurityRule EffectiveNetworkSecurityRule(string name = null, EffectiveSecurityRuleProtocol? protocol = null, string sourcePortRange = null, string destinationPortRange = null, IEnumerable<string> sourcePortRanges = null, IEnumerable<string> destinationPortRanges = null, string sourceAddressPrefix = null, string destinationAddressPrefix = null, IEnumerable<string> sourceAddressPrefixes = null, IEnumerable<string> destinationAddressPrefixes = null, IEnumerable<string> expandedSourceAddressPrefix = null, IEnumerable<string> expandedDestinationAddressPrefix = null, SecurityRuleAccess? access = null, int? priority = null, SecurityRuleDirection? direction = null)
        {
            sourcePortRanges ??= new List<string>();
            destinationPortRanges ??= new List<string>();
            sourceAddressPrefixes ??= new List<string>();
            destinationAddressPrefixes ??= new List<string>();
            expandedSourceAddressPrefix ??= new List<string>();
            expandedDestinationAddressPrefix ??= new List<string>();

            return new EffectiveNetworkSecurityRule(name, protocol, sourcePortRange, destinationPortRange, sourcePortRanges?.ToList(), destinationPortRanges?.ToList(), sourceAddressPrefix, destinationAddressPrefix, sourceAddressPrefixes?.ToList(), destinationAddressPrefixes?.ToList(), expandedSourceAddressPrefix?.ToList(), expandedDestinationAddressPrefix?.ToList(), access, priority, direction);
        }

        /// <summary> Initializes a new instance of LoadBalancer. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="sku"> The load balancer SKU. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="frontendIPConfigurations"> Object representing the frontend IPs to be used for the load balancer. </param>
        /// <param name="backendAddressPools"> Collection of backend address pools used by a load balancer. </param>
        /// <param name="loadBalancingRules"> Object collection representing the load balancing rules Gets the provisioning. </param>
        /// <param name="probes"> Collection of probe objects used in the load balancer. </param>
        /// <param name="inboundNatRules"> Collection of inbound NAT Rules used by a load balancer. Defining inbound NAT rules on your load balancer is mutually exclusive with defining an inbound NAT pool. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an Inbound NAT pool. They have to reference individual inbound NAT rules. </param>
        /// <param name="inboundNatPools"> Defines an external port range for inbound NAT to a single backend port on NICs associated with a load balancer. Inbound NAT rules are created automatically for each NIC associated with the Load Balancer using an external port from this range. Defining an Inbound NAT pool on your Load Balancer is mutually exclusive with defining inbound Nat rules. Inbound NAT pools are referenced from virtual machine scale sets. NICs that are associated with individual virtual machines cannot reference an inbound NAT pool. They have to reference individual inbound NAT rules. </param>
        /// <param name="outboundRules"> The outbound rules. </param>
        /// <param name="resourceGuid"> The resource GUID property of the load balancer resource. </param>
        /// <param name="provisioningState"> The provisioning state of the load balancer resource. </param>
        /// <returns> A new <see cref="Models.LoadBalancer"/> instance for mocking. </returns>
        public static LoadBalancer LoadBalancer(string id = null, string name = null, string type = null, string location = null, IDictionary<string, string> tags = null, LoadBalancerSku sku = null, string etag = null, IEnumerable<FrontendIPConfiguration> frontendIPConfigurations = null, IEnumerable<BackendAddressPool> backendAddressPools = null, IEnumerable<LoadBalancingRule> loadBalancingRules = null, IEnumerable<Probe> probes = null, IEnumerable<InboundNatRule> inboundNatRules = null, IEnumerable<InboundNatPool> inboundNatPools = null, IEnumerable<OutboundRule> outboundRules = null, string resourceGuid = null, ProvisioningState? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            frontendIPConfigurations ??= new List<FrontendIPConfiguration>();
            backendAddressPools ??= new List<BackendAddressPool>();
            loadBalancingRules ??= new List<LoadBalancingRule>();
            probes ??= new List<Probe>();
            inboundNatRules ??= new List<InboundNatRule>();
            inboundNatPools ??= new List<InboundNatPool>();
            outboundRules ??= new List<OutboundRule>();

            return new LoadBalancer(id, name, type, location, tags, sku, etag, frontendIPConfigurations?.ToList(), backendAddressPools?.ToList(), loadBalancingRules?.ToList(), probes?.ToList(), inboundNatRules?.ToList(), inboundNatPools?.ToList(), outboundRules?.ToList(), resourceGuid, provisioningState);
        }

        /// <summary> Initializes a new instance of LoadBalancingRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of load balancing rules used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="frontendIPConfiguration"> A reference to frontend IP addresses. </param>
        /// <param name="backendAddressPool"> A reference to a pool of DIPs. Inbound traffic is randomly load balanced across IPs in the backend IPs. </param>
        /// <param name="probe"> The reference to the load balancer probe used by the load balancing rule. </param>
        /// <param name="protocol"> The reference to the transport protocol used by the load balancing rule. </param>
        /// <param name="loadDistribution"> The load distribution policy for this rule. </param>
        /// <param name="frontendPort"> The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables "Any Port". </param>
        /// <param name="backendPort"> The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables "Any Port". </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </param>
        /// <param name="enableFloatingIP"> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="disableOutboundSnat"> Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule. </param>
        /// <param name="provisioningState"> The provisioning state of the load balancing rule resource. </param>
        /// <returns> A new <see cref="Models.LoadBalancingRule"/> instance for mocking. </returns>
        public static LoadBalancingRule LoadBalancingRule(string id = null, string name = null, string etag = null, string type = null, SubResource frontendIPConfiguration = null, SubResource backendAddressPool = null, SubResource probe = null, TransportProtocol? protocol = null, LoadDistribution? loadDistribution = null, int? frontendPort = null, int? backendPort = null, int? idleTimeoutInMinutes = null, bool? enableFloatingIP = null, bool? enableTcpReset = null, bool? disableOutboundSnat = null, ProvisioningState? provisioningState = null)
        {
            return new LoadBalancingRule(id, name, etag, type, frontendIPConfiguration, backendAddressPool, probe, protocol, loadDistribution, frontendPort, backendPort, idleTimeoutInMinutes, enableFloatingIP, enableTcpReset, disableOutboundSnat, provisioningState);
        }

        /// <summary> Initializes a new instance of Probe. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of probes used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="loadBalancingRules"> The load balancer rules that use this probe. </param>
        /// <param name="protocol"> The protocol of the end point. If 'Tcp' is specified, a received ACK is required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is required for the probe to be successful. </param>
        /// <param name="port"> The port for communicating the probe. Possible values range from 1 to 65535, inclusive. </param>
        /// <param name="intervalInSeconds"> The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of rotation. The default value is 15, the minimum value is 5. </param>
        /// <param name="numberOfProbes"> The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint. This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure. </param>
        /// <param name="requestPath"> The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is not allowed. There is no default value. </param>
        /// <param name="provisioningState"> The provisioning state of the probe resource. </param>
        /// <returns> A new <see cref="Models.Probe"/> instance for mocking. </returns>
        public static Probe Probe(string id = null, string name = null, string etag = null, string type = null, IEnumerable<SubResource> loadBalancingRules = null, ProbeProtocol? protocol = null, int? port = null, int? intervalInSeconds = null, int? numberOfProbes = null, string requestPath = null, ProvisioningState? provisioningState = null)
        {
            loadBalancingRules ??= new List<SubResource>();

            return new Probe(id, name, etag, type, loadBalancingRules?.ToList(), protocol, port, intervalInSeconds, numberOfProbes, requestPath, provisioningState);
        }

        /// <summary> Initializes a new instance of InboundNatPool. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of inbound NAT pools used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="frontendIPConfiguration"> A reference to frontend IP addresses. </param>
        /// <param name="protocol"> The reference to the transport protocol used by the inbound NAT pool. </param>
        /// <param name="frontendPortRangeStart"> The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65534. </param>
        /// <param name="frontendPortRangeEnd"> The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65535. </param>
        /// <param name="backendPort"> The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535. </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </param>
        /// <param name="enableFloatingIP"> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="provisioningState"> The provisioning state of the inbound NAT pool resource. </param>
        /// <returns> A new <see cref="Models.InboundNatPool"/> instance for mocking. </returns>
        public static InboundNatPool InboundNatPool(string id = null, string name = null, string etag = null, string type = null, SubResource frontendIPConfiguration = null, TransportProtocol? protocol = null, int? frontendPortRangeStart = null, int? frontendPortRangeEnd = null, int? backendPort = null, int? idleTimeoutInMinutes = null, bool? enableFloatingIP = null, bool? enableTcpReset = null, ProvisioningState? provisioningState = null)
        {
            return new InboundNatPool(id, name, etag, type, frontendIPConfiguration, protocol, frontendPortRangeStart, frontendPortRangeEnd, backendPort, idleTimeoutInMinutes, enableFloatingIP, enableTcpReset, provisioningState);
        }

        /// <summary> Initializes a new instance of OutboundRule. </summary>
        /// <param name="id"> Resource ID. </param>
        /// <param name="name"> The name of the resource that is unique within the set of outbound rules used by the load balancer. This name can be used to access the resource. </param>
        /// <param name="etag"> A unique read-only string that changes whenever the resource is updated. </param>
        /// <param name="type"> Type of the resource. </param>
        /// <param name="allocatedOutboundPorts"> The number of outbound ports to be used for NAT. </param>
        /// <param name="frontendIPConfigurations"> The Frontend IP addresses of the load balancer. </param>
        /// <param name="backendAddressPool"> A reference to a pool of DIPs. Outbound traffic is randomly load balanced across IPs in the backend IPs. </param>
        /// <param name="provisioningState"> The provisioning state of the outbound rule resource. </param>
        /// <param name="protocol"> The protocol for the outbound rule in load balancer. </param>
        /// <param name="enableTcpReset"> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </param>
        /// <param name="idleTimeoutInMinutes"> The timeout for the TCP idle connection. </param>
        /// <returns> A new <see cref="Models.OutboundRule"/> instance for mocking. </returns>
        public static OutboundRule OutboundRule(string id = null, string name = null, string etag = null, string type = null, int? allocatedOutboundPorts = null, IEnumerable<SubResource> frontendIPConfigurations = null, SubResource backendAddressPool = null, ProvisioningState? provisioningState = null, LoadBalancerOutboundRuleProtocol? protocol = null, bool? enableTcpReset = null, int? idleTimeoutInMinutes = null)
        {
            frontendIPConfigurations ??= new List<SubResource>();

            return new OutboundRule(id, name, etag, type, allocatedOutboundPorts, frontendIPConfigurations?.ToList(), backendAddressPool, provisioningState, protocol, enableTcpReset, idleTimeoutInMinutes);
        }
    }
}
