// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set network profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateNetworkProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateNetworkProfile. </summary>
        public VirtualMachineScaleSetUpdateNetworkProfile()
        {
            NetworkInterfaceConfigurations = new ChangeTrackingList<VirtualMachineScaleSetUpdateNetworkConfiguration>();
        }

        /// <summary>
        /// A reference to a load balancer probe used to determine the health of an instance in the virtual machine scale set. The reference will be in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}'.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile.healthProbe
        /// </summary>
        internal WritableSubResource HealthProbe { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier HealthProbeId
        {
            get => HealthProbe is null ? default : HealthProbe.Id;
            set
            {
                if (HealthProbe is null)
                    HealthProbe = new WritableSubResource();
                HealthProbe.Id = value;
            }
        }

        /// <summary>
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile.networkInterfaceConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetUpdateNetworkConfiguration> NetworkInterfaceConfigurations { get; }
    }
}
