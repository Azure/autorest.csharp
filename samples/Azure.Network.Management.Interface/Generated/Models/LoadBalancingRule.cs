// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> A load balancing rule for a load balancer. </summary>
    public partial class LoadBalancingRule : SubResource
    {
        /// <summary> Initializes a new instance of LoadBalancingRule. </summary>
        public LoadBalancingRule()
        {
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
        internal LoadBalancingRule(string id, string name, string etag, string type, SubResource frontendIPConfiguration, SubResource backendAddressPool, SubResource probe, TransportProtocol? protocol, LoadDistribution? loadDistribution, int? frontendPort, int? backendPort, int? idleTimeoutInMinutes, bool? enableFloatingIP, bool? enableTcpReset, bool? disableOutboundSnat, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            FrontendIPConfiguration = frontendIPConfiguration;
            BackendAddressPool = backendAddressPool;
            Probe = probe;
            Protocol = protocol;
            LoadDistribution = loadDistribution;
            FrontendPort = frontendPort;
            BackendPort = backendPort;
            IdleTimeoutInMinutes = idleTimeoutInMinutes;
            EnableFloatingIP = enableFloatingIP;
            EnableTcpReset = enableTcpReset;
            DisableOutboundSnat = disableOutboundSnat;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within the set of load balancing rules used by the load balancer. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Type of the resource. </summary>
        public string Type { get; }
        /// <summary> A reference to frontend IP addresses. </summary>
        public SubResource FrontendIPConfiguration { get; set; }
        /// <summary> A reference to a pool of DIPs. Inbound traffic is randomly load balanced across IPs in the backend IPs. </summary>
        public SubResource BackendAddressPool { get; set; }
        /// <summary> The reference to the load balancer probe used by the load balancing rule. </summary>
        public SubResource Probe { get; set; }
        /// <summary> The reference to the transport protocol used by the load balancing rule. </summary>
        public TransportProtocol? Protocol { get; set; }
        /// <summary> The load distribution policy for this rule. </summary>
        public LoadDistribution? LoadDistribution { get; set; }
        /// <summary> The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values are between 0 and 65534. Note that value 0 enables "Any Port". </summary>
        public int? FrontendPort { get; set; }
        /// <summary> The port used for internal connections on the endpoint. Acceptable values are between 0 and 65535. Note that value 0 enables "Any Port". </summary>
        public int? BackendPort { get; set; }
        /// <summary> The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP. </summary>
        public int? IdleTimeoutInMinutes { get; set; }
        /// <summary> Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint. </summary>
        public bool? EnableFloatingIP { get; set; }
        /// <summary> Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP. </summary>
        public bool? EnableTcpReset { get; set; }
        /// <summary> Configures SNAT for the VMs in the backend pool to use the publicIP address specified in the frontend of the load balancing rule. </summary>
        public bool? DisableOutboundSnat { get; set; }
        /// <summary> The provisioning state of the load balancing rule resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
