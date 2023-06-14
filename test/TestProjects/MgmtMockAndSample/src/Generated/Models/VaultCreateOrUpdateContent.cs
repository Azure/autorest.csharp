// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtMockAndSample.Models
{
    /// <summary> Parameters for creating or updating a vault. </summary>
    public partial class VaultCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of VaultCreateOrUpdateContent. </summary>
        /// <param name="location"> The supported Azure location where the key vault should be created. </param>
        /// <param name="properties"> Properties of the vault. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public VaultCreateOrUpdateContent(AzureLocation location, VaultProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
            Properties = properties;
        }

        /// <summary> The supported Azure location where the key vault should be created. </summary>
        public AzureLocation Location { get; }
        /// <summary> The tags that will be assigned to the key vault. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> Properties of the vault. </summary>
        public VaultProperties Properties { get; }
        /// <summary> Identity for the virtual machine. </summary>
        public ManagedServiceIdentity Identity { get; set; }
    }
}
