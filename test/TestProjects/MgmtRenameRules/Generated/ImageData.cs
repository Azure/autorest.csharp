// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using MgmtRenameRules.Models;

namespace MgmtRenameRules
{
    /// <summary>
    /// A class representing the Image data model.
    /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
    /// Serialized Name: Image
    /// </summary>
    public partial class ImageData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of ImageData. </summary>
        /// <param name="location"> The location. </param>
        public ImageData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ImageData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sourceVirtualMachine">
        /// The source virtual machine from which Image is created.
        /// Serialized Name: Image.properties.sourceVirtualMachine
        /// </param>
        /// <param name="storageProfile">
        /// Specifies the storage settings for the virtual machine disks.
        /// Serialized Name: Image.properties.storageProfile
        /// </param>
        /// <param name="provisioningState">
        /// The provisioning state.
        /// Serialized Name: Image.properties.provisioningState
        /// </param>
        /// <param name="hyperVGeneration">
        /// Gets the HyperVGenerationType of the VirtualMachine created from the image
        /// Serialized Name: Image.properties.hyperVGeneration
        /// </param>
        internal ImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, WritableSubResource sourceVirtualMachine, ImageStorageProfile storageProfile, string provisioningState, HyperVGenerationType? hyperVGeneration) : base(id, name, resourceType, systemData, tags, location)
        {
            SourceVirtualMachine = sourceVirtualMachine;
            StorageProfile = storageProfile;
            ProvisioningState = provisioningState;
            HyperVGeneration = hyperVGeneration;
        }

        /// <summary>
        /// The source virtual machine from which Image is created.
        /// Serialized Name: Image.properties.sourceVirtualMachine
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
        /// Serialized Name: Image.properties.storageProfile
        /// </summary>
        public ImageStorageProfile StorageProfile { get; set; }
        /// <summary>
        /// The provisioning state.
        /// Serialized Name: Image.properties.provisioningState
        /// </summary>
        public string ProvisioningState { get; }
        /// <summary>
        /// Gets the HyperVGenerationType of the VirtualMachine created from the image
        /// Serialized Name: Image.properties.hyperVGeneration
        /// </summary>
        public HyperVGenerationType? HyperVGeneration { get; set; }
    }
}
