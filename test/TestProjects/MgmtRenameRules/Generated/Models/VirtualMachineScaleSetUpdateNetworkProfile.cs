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
    /// <summary>
    /// Describes a virtual machine scale set network profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateNetworkProfile
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateNetworkProfile"/>. </summary>
        public VirtualMachineScaleSetUpdateNetworkProfile()
        {
            NetworkInterfaceConfigurations = new ChangeTrackingList<VirtualMachineScaleSetUpdateNetworkConfiguration>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateNetworkProfile"/>. </summary>
        /// <param name="healthProbe">
        /// A reference to a load balancer probe used to determine the health of an instance in the virtual machine scale set. The reference will be in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}'.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile.healthProbe
        /// </param>
        /// <param name="networkInterfaceConfigurations">
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetUpdateNetworkProfile.networkInterfaceConfigurations
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetUpdateNetworkProfile(WritableSubResource healthProbe, IList<VirtualMachineScaleSetUpdateNetworkConfiguration> networkInterfaceConfigurations, Dictionary<string, BinaryData> rawData)
        {
            HealthProbe = healthProbe;
            NetworkInterfaceConfigurations = networkInterfaceConfigurations;
            _rawData = rawData;
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
