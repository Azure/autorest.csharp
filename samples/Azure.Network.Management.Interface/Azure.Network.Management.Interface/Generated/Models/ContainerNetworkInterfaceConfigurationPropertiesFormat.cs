// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Container network interface configuration properties. </summary>
    public partial class ContainerNetworkInterfaceConfigurationPropertiesFormat
    {
        /// <summary> A list of ip configurations of the container network interface configuration. </summary>
        public ICollection<IPConfigurationProfile> IpConfigurations { get; set; }
        /// <summary> A list of container network interfaces created from this container network interface configuration. </summary>
        public ICollection<SubResource> ContainerNetworkInterfaces { get; set; }
        /// <summary> The provisioning state of the container network interface configuration resource. </summary>
        public ProvisioningState? ProvisioningState { get; internal set; }
    }
}
