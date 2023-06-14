// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The parameters used to check the availability of the vault name. </summary>
    public partial class VaultCheckNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of VaultCheckNameAvailabilityContent. </summary>
        /// <param name="name"> The vault name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public VaultCheckNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            ResourceType = EncryptionType.MicrosoftKeyVaultVaults;
        }

        /// <summary> The vault name. </summary>
        public string Name { get; }
        /// <summary> The type of resource, Microsoft.KeyVault/vaults. </summary>
        public EncryptionType ResourceType { get; }
    }
}
