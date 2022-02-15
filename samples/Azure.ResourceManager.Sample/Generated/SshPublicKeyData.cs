// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing the SshPublicKey data model. </summary>
    public partial class SshPublicKeyData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of SshPublicKeyData. </summary>
        /// <param name="location"> The location. </param>
        public SshPublicKeyData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of SshPublicKeyData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="publicKey"> SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format. </param>
        internal SshPublicKeyData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string publicKey) : base(id, name, type, systemData, tags, location)
        {
            PublicKey = publicKey;
        }

        /// <summary> SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format. </summary>
        public string PublicKey { get; set; }
    }
}
