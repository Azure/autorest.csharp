// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The parameters used to check the availability of the storage account name. </summary>
    public partial class StorageAccountCheckNameAvailabilityContent
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="StorageAccountCheckNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StorageAccountCheckNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            ResourceType = Type.MicrosoftStorageStorageAccounts;
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountCheckNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The storage account name. </param>
        /// <param name="resourceType"> The type of resource, Microsoft.Storage/storageAccounts. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal StorageAccountCheckNameAvailabilityContent(string name, Type resourceType, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            ResourceType = resourceType;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="StorageAccountCheckNameAvailabilityContent"/> for deserialization. </summary>
        internal StorageAccountCheckNameAvailabilityContent()
        {
        }

        /// <summary> The storage account name. </summary>
        public string Name { get; }
        /// <summary> The type of resource, Microsoft.Storage/storageAccounts. </summary>
        public Type ResourceType { get; }
    }
}
