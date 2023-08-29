// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Sample.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary>
    /// A class representing the Image data model.
    /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
    /// Serialized Name: Image
    /// </summary>
    public partial class ImageData : TrackedResourceData
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.ImageData
        ///
        /// </summary>
        /// <param name="location"> The location. </param>
        public ImageData(AzureLocation location) : base(location)
        {
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.ImageData
        ///
        /// </summary>
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
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, WritableSubResource sourceVirtualMachine, ImageStorageProfile storageProfile, string provisioningState, HyperVGeneration? hyperVGeneration, Dictionary<string, BinaryData> rawData) : base(id, name, resourceType, systemData, tags, location)
        {
            SourceVirtualMachine = sourceVirtualMachine;
            StorageProfile = storageProfile;
            ProvisioningState = provisioningState;
            HyperVGeneration = hyperVGeneration;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ImageData"/> for deserialization. </summary>
        internal ImageData()
        {
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
        public HyperVGeneration? HyperVGeneration { get; set; }
    }
}
