// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SshConfiguration"/>. </summary>
        public SshConfiguration()
        {
            PublicKeys = new ChangeTrackingList<SshPublicKeyInfo>();
        }

        /// <summary> Initializes a new instance of <see cref="SshConfiguration"/>. </summary>
        /// <param name="publicKeys">
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SshConfiguration(IList<SshPublicKeyInfo> publicKeys, Dictionary<string, BinaryData> rawData)
        {
            PublicKeys = publicKeys;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of SSH public keys used to authenticate with linux based VMs.
        /// Serialized Name: SshConfiguration.publicKeys
        /// </summary>
        public IList<SshPublicKeyInfo> PublicKeys { get; }
    }
}
