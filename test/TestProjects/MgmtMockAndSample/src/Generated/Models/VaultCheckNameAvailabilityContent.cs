// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The parameters used to check the availability of the vault name. </summary>
    public partial class VaultCheckNameAvailabilityContent
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="VaultCheckNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The vault name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VaultCheckNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            ResourceType = EncryptionType.MicrosoftKeyVaultVaults;
        }

        /// <summary> Initializes a new instance of <see cref="VaultCheckNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The vault name. </param>
        /// <param name="resourceType"> The type of resource, Microsoft.KeyVault/vaults. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VaultCheckNameAvailabilityContent(string name, EncryptionType resourceType, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="VaultCheckNameAvailabilityContent"/> for deserialization. </summary>
        internal VaultCheckNameAvailabilityContent()
        {
        }

        /// <summary> The vault name. </summary>
        public string Name { get; }
        /// <summary> The type of resource, Microsoft.KeyVault/vaults. </summary>
        public EncryptionType ResourceType { get; }
    }
}
