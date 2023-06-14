// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// SSH configuration for Linux based VMs running on Azure
    /// Serialized Name: SshConfiguration
    /// </summary>
    internal partial class SshConfiguration
    {
        /// <summary> Initializes a new instance of SshConfiguration. </summary>
        public SshConfiguration()
        {
            PublicKeys = new ChangeTrackingList<SshPublicKeyInfo>();
        }

        /// <summary> Initializes a new instance of SshConfiguration. </summary>
        /// <param name="publicKeys">
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </param>
        internal SshConfiguration(IList<SshPublicKeyInfo> publicKeys)
        {
            PublicKeys = publicKeys;
        }

        /// <summary>
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </summary>
        public IList<SshPublicKeyInfo> PublicKeys { get; }
    }
}
