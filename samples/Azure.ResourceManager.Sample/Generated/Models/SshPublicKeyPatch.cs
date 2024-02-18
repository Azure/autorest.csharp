// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies information about the SSH public key.
    /// Serialized Name: SshPublicKeyUpdateResource
    /// </summary>
    public partial class SshPublicKeyPatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="SshPublicKeyPatch"/>. </summary>
        public SshPublicKeyPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SshPublicKeyPatch"/>. </summary>
        /// <param name="tags">
        /// Resource tags
        /// Serialized Name: UpdateResource.tags
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="publicKey">
        /// SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format.
        /// Serialized Name: SshPublicKeyUpdateResource.properties.publicKey
        /// </param>
        internal SshPublicKeyPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData, string publicKey) : base(tags, serializedAdditionalRawData)
        {
            PublicKey = publicKey;
        }

        /// <summary>
        /// SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format.
        /// Serialized Name: SshPublicKeyUpdateResource.properties.publicKey
        /// </summary>
        [WirePath("properties.publicKey")]
        public string PublicKey { get; set; }
    }
}
