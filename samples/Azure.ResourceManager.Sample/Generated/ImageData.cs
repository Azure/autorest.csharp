// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the Image data model. </summary>
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
        /// <param name="sourceVirtualMachine"> The source virtual machine from which Image is created. </param>
        /// <param name="storageProfile"> Specifies the storage settings for the virtual machine disks. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="hyperVGeneration"> Gets the HyperVGenerationType of the VirtualMachine created from the image. </param>
        internal ImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, WritableSubResource sourceVirtualMachine, ImageStorageProfile storageProfile, string provisioningState, HyperVGenerationTypes? hyperVGeneration) : base(id, name, resourceType, systemData, tags, location)
        {
            SourceVirtualMachine = sourceVirtualMachine;
            StorageProfile = storageProfile;
            ProvisioningState = provisioningState;
            HyperVGeneration = hyperVGeneration;
        }

        /// <summary> The source virtual machine from which Image is created. </summary>
        internal WritableSubResource SourceVirtualMachine { get; set; }
        /// <summary> Gets or sets Id. </summary>
        public ResourceIdentifier SourceVirtualMachineId
        {
            get => SourceVirtualMachine is null ? default : SourceVirtualMachine.Id;
            set
            {
                if (value is not null)
                {
                    if (SourceVirtualMachine is null)
                        SourceVirtualMachine = new WritableSubResource();
                    SourceVirtualMachine.Id = value;
                }
                else
                {
                    SourceVirtualMachine = null;
                }
            }
        }

        /// <summary> Specifies the storage settings for the virtual machine disks. </summary>
        public ImageStorageProfile StorageProfile { get; set; }
        /// <summary> The provisioning state. </summary>
        public string ProvisioningState { get; }
        /// <summary> Gets the HyperVGenerationType of the VirtualMachine created from the image. </summary>
        public HyperVGenerationTypes? HyperVGeneration { get; set; }
    }
}
