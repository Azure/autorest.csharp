// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A Class representing a EncryptionScope along with the instance operations that can be performed on it. </summary>
    public class EncryptionScope : EncryptionScopeOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "EncryptionScope"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal EncryptionScope(ResourceOperationsBase options, EncryptionScopeData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary>
        /// Gets or sets the global::Azure.Management.Storage.Models.EncryptionScopeData
        /// 
        /// .
        /// </summary>
        public EncryptionScopeData

         Data
        { get; private set; }

        /// <inheritdoc />
        protected override EncryptionScope GetResource()
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<EncryptionScope> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
