// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Describes a virtual machine scale set VM network profile.
    /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration
    /// </summary>
    internal partial class VirtualMachineScaleSetVmNetworkProfileConfiguration
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmNetworkProfileConfiguration. </summary>
        public VirtualMachineScaleSetVmNetworkProfileConfiguration()
        {
            NetworkInterfaceConfigurations = new ChangeTrackingList<VirtualMachineScaleSetNetworkConfiguration>();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVmNetworkProfileConfiguration. </summary>
        /// <param name="networkInterfaceConfigurations">
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration.networkInterfaceConfigurations
        /// </param>
        internal VirtualMachineScaleSetVmNetworkProfileConfiguration(IList<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations)
        {
            NetworkInterfaceConfigurations = networkInterfaceConfigurations;
        }

        /// <summary>
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration.networkInterfaceConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get; }
    }
}
