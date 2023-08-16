// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The status of virtual machine patch operations.
    /// Serialized Name: VirtualMachinePatchStatus
    /// </summary>
    public partial class VirtualMachinePatchStatus
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachinePatchStatus
        ///
        /// </summary>
        internal VirtualMachinePatchStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachinePatchStatus
        ///
        /// </summary>
        /// <param name="availablePatchSummary">
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.availablePatchSummary
        /// </param>
        /// <param name="lastPatchInstallationSummary">
        /// The installation summary of the latest installation operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.lastPatchInstallationSummary
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachinePatchStatus(AvailablePatchSummary availablePatchSummary, LastPatchInstallationSummary lastPatchInstallationSummary, Dictionary<string, BinaryData> rawData)
        {
            AvailablePatchSummary = availablePatchSummary;
            LastPatchInstallationSummary = lastPatchInstallationSummary;
            _rawData = rawData;
        }

        /// <summary>
        /// The available patch summary of the latest assessment operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.availablePatchSummary
        /// </summary>
        public AvailablePatchSummary AvailablePatchSummary { get; }
        /// <summary>
        /// The installation summary of the latest installation operation for the virtual machine.
        /// Serialized Name: VirtualMachinePatchStatus.lastPatchInstallationSummary
        /// </summary>
        public LastPatchInstallationSummary LastPatchInstallationSummary { get; }
    }
}
