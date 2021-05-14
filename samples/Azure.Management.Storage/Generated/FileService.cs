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
    /// <summary> A Class representing a FileService along with the instance operations that can be performed on it. </summary>
    public class FileService : FileServiceOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "FileService"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal FileService(ResourceOperationsBase options, FileServiceData resource) : base(options, resource.Id as ResourceGroupResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the FileServiceData. </summary>
        public FileServiceData Data { get; private set; }

        /// <inheritdoc />
        protected override FileService GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<FileService> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
