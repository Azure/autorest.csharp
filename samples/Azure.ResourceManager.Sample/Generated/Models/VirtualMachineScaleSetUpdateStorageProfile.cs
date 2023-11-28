// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Describes a virtual machine scale set storage profile.
    /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateStorageProfile
    {
        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateStorageProfile"/>. </summary>
        public VirtualMachineScaleSetUpdateStorageProfile()
        {
            DataDisks = new ChangeTrackingList<VirtualMachineScaleSetDataDisk>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetUpdateStorageProfile"/>. </summary>
        /// <param name="imageReference">
        /// The image reference.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.imageReference
        /// </param>
        /// <param name="osDisk">
        /// The OS disk.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.osDisk
        /// </param>
        /// <param name="dataDisks">
        /// The data disks.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.dataDisks
        /// </param>
        internal VirtualMachineScaleSetUpdateStorageProfile(ImageReference imageReference, VirtualMachineScaleSetUpdateOSDisk osDisk, IList<VirtualMachineScaleSetDataDisk> dataDisks)
        {
            ImageReference = imageReference;
            OSDisk = osDisk;
            DataDisks = dataDisks;
        }

        /// <summary>
        /// The image reference.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.imageReference
        /// </summary>
        public ImageReference ImageReference { get; set; }
        /// <summary>
        /// The OS disk.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.osDisk
        /// </summary>
        public VirtualMachineScaleSetUpdateOSDisk OSDisk { get; set; }
        /// <summary>
        /// The data disks.
        /// Serialized Name: VirtualMachineScaleSetUpdateStorageProfile.dataDisks
        /// </summary>
        public IList<VirtualMachineScaleSetDataDisk> DataDisks { get; }
    }
}
