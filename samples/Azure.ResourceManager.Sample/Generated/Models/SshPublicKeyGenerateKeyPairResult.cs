// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Sample
{
    /// <summary> Response from generation of an SSH key pair. </summary>
    public partial class SshPublicKeyGenerateKeyPairResult : SubResource<ResourceIdentifier>
    {
        /// <summary> Initializes a new instance of SshPublicKeyGenerateKeyPairResult. </summary>
        /// <param name="privateKey"> Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret. </param>
        /// <param name="publicKey"> Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateKey"/> or <paramref name="publicKey"/> is null. </exception>
        internal SshPublicKeyGenerateKeyPairResult(string privateKey, string publicKey)
        {
            if (privateKey == null)
            {
                throw new ArgumentNullException(nameof(privateKey));
            }
            if (publicKey == null)
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            PrivateKey = privateKey;
            PublicKey = publicKey;
        }

        /// <summary> Initializes a new instance of SshPublicKeyGenerateKeyPairResult. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="privateKey"> Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret. </param>
        /// <param name="publicKey"> Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format. </param>
        internal SshPublicKeyGenerateKeyPairResult(string id, string privateKey, string publicKey) : base(id)
        {
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }

        /// <summary> Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret. </summary>
        public string PrivateKey { get; }
        /// <summary> Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format. </summary>
        public string PublicKey { get; }
    }
}
