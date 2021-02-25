// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample
{
    /// <summary> Specifies information about the SSH public key. </summary>
    public partial class SshPublicKeyResource : Resource
    {
        /// <summary> Initializes a new instance of SshPublicKeyResource. </summary>
        /// <param name="location"> Resource location. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        public SshPublicKeyResource(string location) : base(location)
        {
            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }
        }

        /// <summary> Initializes a new instance of SshPublicKeyResource. </summary>
        /// <param name="id"> Resource Id. </param>
        /// <param name="name"> Resource name. </param>
        /// <param name="type"> Resource type. </param>
        /// <param name="location"> Resource location. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="publicKey"> SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format. </param>
        internal SshPublicKeyResource(string id, string name, string type, string location, IDictionary<string, string> tags, string publicKey) : base(id, name, type, location, tags)
        {
            PublicKey = publicKey;
        }

        /// <summary> SSH public key used to authenticate to a virtual machine through ssh. If this property is not initially provided when the resource is created, the publicKey property will be populated when generateKeyPair is called. If the public key is provided upon resource creation, the provided public key needs to be at least 2048-bit and in ssh-rsa format. </summary>
        public string PublicKey { get; set; }
    }
}
