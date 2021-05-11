// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineImage along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineImage : VirtualMachineImageOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineImage"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineImage(ResourceOperationsBase options, VirtualMachineImageData resource) : base(options, resource.Id as ResourceGroupResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineImageData. </summary>
        public VirtualMachineImageData Data { get; private set; }

        /// <inheritdoc />
        protected override VirtualMachineImage GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachineImage> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
