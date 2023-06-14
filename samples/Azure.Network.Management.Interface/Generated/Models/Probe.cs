// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> A load balancer probe. </summary>
    public partial class Probe : SubResource
    {
        /// <summary> Initializes a new instance of Probe. </summary>
        public Probe()
        {
            LoadBalancingRules = new ChangeTrackingList<SubResource>();
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
        internal Probe(string id, string name, string etag, string type, IReadOnlyList<SubResource> loadBalancingRules, ProbeProtocol? protocol, int? port, int? intervalInSeconds, int? numberOfProbes, string requestPath, ProvisioningState? provisioningState) : base(id)
        {
            Name = name;
            Etag = etag;
            Type = type;
            LoadBalancingRules = loadBalancingRules;
            Protocol = protocol;
            Port = port;
            IntervalInSeconds = intervalInSeconds;
            NumberOfProbes = numberOfProbes;
            RequestPath = requestPath;
            ProvisioningState = provisioningState;
        }

        /// <summary> The name of the resource that is unique within the set of probes used by the load balancer. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; }
        /// <summary> Type of the resource. </summary>
        public string Type { get; }
        /// <summary> The load balancer rules that use this probe. </summary>
        public IReadOnlyList<SubResource> LoadBalancingRules { get; }
        /// <summary> The protocol of the end point. If 'Tcp' is specified, a received ACK is required for the probe to be successful. If 'Http' or 'Https' is specified, a 200 OK response from the specifies URI is required for the probe to be successful. </summary>
        public ProbeProtocol? Protocol { get; set; }
        /// <summary> The port for communicating the probe. Possible values range from 1 to 65535, inclusive. </summary>
        public int? Port { get; set; }
        /// <summary> The interval, in seconds, for how frequently to probe the endpoint for health status. Typically, the interval is slightly less than half the allocated timeout period (in seconds) which allows two full probes before taking the instance out of rotation. The default value is 15, the minimum value is 5. </summary>
        public int? IntervalInSeconds { get; set; }
        /// <summary> The number of probes where if no response, will result in stopping further traffic from being delivered to the endpoint. This values allows endpoints to be taken out of rotation faster or slower than the typical times used in Azure. </summary>
        public int? NumberOfProbes { get; set; }
        /// <summary> The URI used for requesting health status from the VM. Path is required if a protocol is set to http. Otherwise, it is not allowed. There is no default value. </summary>
        public string RequestPath { get; set; }
        /// <summary> The provisioning state of the probe resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
    }
}
