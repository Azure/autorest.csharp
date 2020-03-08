// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> A load balancer probe. </summary>
    public partial class Probe : SubResource
    {
        /// <summary> The name of the resource that is unique within the set of probes used by the load balancer. This name can be used to access the resource. </summary>
        public string Name { get; set; }
        /// <summary> A unique read-only string that changes whenever the resource is updated. </summary>
        public string Etag { get; internal set; }
        /// <summary> Type of the resource. </summary>
        public string Type { get; internal set; }
        /// <summary> The load balancer rules that use this probe. </summary>
        public IList<SubResource> LoadBalancingRules { get; internal set; }
        /// <summary> The protocol of the end point. If &apos;Tcp&apos; is specified, a received ACK is required for the probe to be successful. If &apos;Http&apos; or &apos;Https&apos; is specified, a 200 OK response from the specifies URI is required for the probe to be successful. </summary>
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
        public ProvisioningState? ProvisioningState { get; internal set; }
    }
}
