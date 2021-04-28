// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace SupersetInheritance
{
    /// <summary> A Class representing a SupersetModel1 along with the instance operations that can be performed on it. </summary>
    public class SupersetModel1 : SupersetModel1Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "SupersetModel1"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal SupersetModel1(ResourceOperationsBase options, SupersetModel1Data resource) : base(options, resource.Id as TenantResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the SupersetModel1Data. </summary>
        public SupersetModel1Data Data { get; private set; }

        /// <inheritdoc />
        protected override SupersetModel1 GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<SupersetModel1> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
