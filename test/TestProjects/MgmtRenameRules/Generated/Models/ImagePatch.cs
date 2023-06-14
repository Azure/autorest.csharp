// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The source user image virtual hard disk. Only tags may be updated.
    /// Serialized Name: ImageUpdate
    /// </summary>
    public partial class ImagePatch : UpdateResource
    {
        /// <summary> Initializes a new instance of ImagePatch. </summary>
        public ImagePatch()
        {
        }

        /// <summary>
        /// The source virtual machine from which Image is created.
        /// Serialized Name: ImageUpdate.properties.sourceVirtualMachine
        /// </summary>
        internal WritableSubResource SourceVirtualMachine { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SourceVirtualMachineId
        {
            get => SourceVirtualMachine is null ? default : SourceVirtualMachine.Id;
            set
            {
                if (SourceVirtualMachine is null)
                    SourceVirtualMachine = new WritableSubResource();
                SourceVirtualMachine.Id = value;
            }
        }

        /// <summary>
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: ImageUpdate.properties.storageProfile
        /// </summary>
        public ImageStorageProfile StorageProfile { get; set; }
        /// <summary>
        /// The provisioning state.
        /// Serialized Name: ImageUpdate.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// Gets the HyperVGenerationType of the VirtualMachine created from the image
        /// Serialized Name: ImageUpdate.properties.hyperVGeneration
        /// </summary>
        public HyperVGenerationType? HyperVGeneration { get; set; }
    }
}
