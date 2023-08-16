// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set VM network profile.
    /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration
    /// </summary>
    internal partial class VirtualMachineScaleSetVMNetworkProfileConfiguration
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetVMNetworkProfileConfiguration
        ///
        /// </summary>
        public VirtualMachineScaleSetVMNetworkProfileConfiguration()
        {
            NetworkInterfaceConfigurations = new ChangeTrackingList<VirtualMachineScaleSetNetworkConfiguration>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineScaleSetVMNetworkProfileConfiguration
        ///
        /// </summary>
        /// <param name="networkInterfaceConfigurations">
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration.networkInterfaceConfigurations
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetVMNetworkProfileConfiguration(IList<VirtualMachineScaleSetNetworkConfiguration> networkInterfaceConfigurations, Dictionary<string, BinaryData> rawData)
        {
            NetworkInterfaceConfigurations = networkInterfaceConfigurations;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of network configurations.
        /// Serialized Name: VirtualMachineScaleSetVMNetworkProfileConfiguration.networkInterfaceConfigurations
        /// </summary>
        public IList<VirtualMachineScaleSetNetworkConfiguration> NetworkInterfaceConfigurations { get; }
    }
}
