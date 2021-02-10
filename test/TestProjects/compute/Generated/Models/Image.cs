// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace compute.Models
{
    /// <summary> The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist. </summary>
    public partial class Image : Resource
    {
        /// <summary> Initializes a new instance of Image. </summary>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public Image(string location) : base(location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
        }

        /// <summary> Initializes a new instance of Image. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="sourceVirtualMachine"> The source virtual machine from which Image is created. </param>
        /// <param name="storageProfile"> Specifies the storage settings for the virtual machine disks. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="hyperVGeneration"> Gets the HyperVGenerationType of the VirtualMachine created from the image. </param>
        internal Image(string id, string name, string type, string location, IDictionary<string, string> tags, SubResource sourceVirtualMachine, ImageStorageProfile storageProfile, string provisioningState, HyperVGenerationTypes? hyperVGeneration) : base(id, name, type, location, tags)
        {
            SourceVirtualMachine = sourceVirtualMachine;
            StorageProfile = storageProfile;
            ProvisioningState = provisioningState;
            HyperVGeneration = hyperVGeneration;
        }

        /// <summary> The source virtual machine from which Image is created. </summary>
        public SubResource SourceVirtualMachine { get; set; }
        /// <summary> Specifies the storage settings for the virtual machine disks. </summary>
        public ImageStorageProfile StorageProfile { get; set; }
        /// <summary> The provisioning state. </summary>
        public string ProvisioningState { get; }
        /// <summary> Gets the HyperVGenerationType of the VirtualMachine created from the image. </summary>
        public HyperVGenerationTypes? HyperVGeneration { get; set; }
    }
}
