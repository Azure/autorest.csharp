// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to check the availability of the storage account name. </summary>
    public partial class StorageAccountCheckNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of StorageAccountCheckNameAvailabilityContent. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StorageAccountCheckNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            ResourceType = Type.MicrosoftStorageStorageAccounts;
        }

        /// <summary> The storage account name. </summary>
        public string Name { get; }
        /// <summary> The type of resource, Microsoft.Storage/storageAccounts. </summary>
        public Type ResourceType { get; }
    }
}
