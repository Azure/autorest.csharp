// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a StorageAccount along with the instance operations that can be performed on it. </summary>
    public class StorageAccount : StorageAccountOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "StorageAccount"/> class for mocking. </summary>
        internal StorageAccount() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "StorageAccount"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal StorageAccount(OperationsBase options, StorageAccountData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the StorageAccountData. </summary>
        public StorageAccountData Data { get; private set; }
    }
}
