// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Response from generation of an SSH key pair.
    /// Serialized Name: SshPublicKeyGenerateKeyPairResult
    /// </summary>
    public partial class SshPublicKeyGenerateKeyPairResult
    {
        /// <summary> Initializes a new instance of SshPublicKeyGenerateKeyPairResult. </summary>
        /// <param name="privateKey">
        /// Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.privateKey
        /// </param>
        /// <param name="publicKey">
        /// Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.publicKey
        /// </param>
        /// <param name="id">
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{SshPublicKeyName}
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.id
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="privateKey"/>, <paramref name="publicKey"/> or <paramref name="id"/> is null. </exception>
        internal SshPublicKeyGenerateKeyPairResult(string privateKey, string publicKey, string id)
        {
            Argument.AssertNotNull(privateKey, nameof(privateKey));
            Argument.AssertNotNull(publicKey, nameof(publicKey));
            Argument.AssertNotNull(id, nameof(id));

            PrivateKey = privateKey;
            PublicKey = publicKey;
            Id = id;
        }

        /// <summary>
        /// Private key portion of the key pair used to authenticate to a virtual machine through ssh. The private key is returned in RFC3447 format and should be treated as a secret.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.privateKey
        /// </summary>
        public string PrivateKey { get; }
        /// <summary>
        /// Public key portion of the key pair used to authenticate to a virtual machine through ssh. The public key is in ssh-rsa format.
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.publicKey
        /// </summary>
        public string PublicKey { get; }
        /// <summary>
        /// The ARM resource id in the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/sshPublicKeys/{SshPublicKeyName}
        /// Serialized Name: SshPublicKeyGenerateKeyPairResult.id
        /// </summary>
        public string Id { get; }
    }
}
