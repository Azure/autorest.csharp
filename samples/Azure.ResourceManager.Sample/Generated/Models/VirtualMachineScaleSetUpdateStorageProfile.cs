// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> Describes a virtual machine scale set storage profile. </summary>
    public partial class VirtualMachineScaleSetUpdateStorageProfile
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetUpdateStorageProfile. </summary>
        public VirtualMachineScaleSetUpdateStorageProfile()
        {
            DataDisks = new ChangeTrackingList<VirtualMachineScaleSetDataDisk>();
        }

        /// <summary> The image reference. </summary>
        public ImageReference ImageReference { get; set; }
        /// <summary> The OS disk. </summary>
        public VirtualMachineScaleSetUpdateOSDisk OsDisk { get; set; }
        /// <summary> The data disks. </summary>
        public IList<VirtualMachineScaleSetDataDisk> DataDisks { get; }
    }
}
