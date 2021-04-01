// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Sample
{
    /// <summary> The status of virtual machine patch operations. </summary>
    public partial class VirtualMachinePatchStatus
    {
        /// <summary> Initializes a new instance of VirtualMachinePatchStatus. </summary>
        internal VirtualMachinePatchStatus()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachinePatchStatus. </summary>
        /// <param name="availablePatchSummary"> The available patch summary of the latest assessment operation for the virtual machine. </param>
        /// <param name="lastPatchInstallationSummary"> The installation summary of the latest installation operation for the virtual machine. </param>
        internal VirtualMachinePatchStatus(AvailablePatchSummary availablePatchSummary, LastPatchInstallationSummary lastPatchInstallationSummary)
        {
            AvailablePatchSummary = availablePatchSummary;
            LastPatchInstallationSummary = lastPatchInstallationSummary;
        }

        /// <summary> The available patch summary of the latest assessment operation for the virtual machine. </summary>
        public AvailablePatchSummary AvailablePatchSummary { get; }
        /// <summary> The installation summary of the latest installation operation for the virtual machine. </summary>
        public LastPatchInstallationSummary LastPatchInstallationSummary { get; }
    }
}
