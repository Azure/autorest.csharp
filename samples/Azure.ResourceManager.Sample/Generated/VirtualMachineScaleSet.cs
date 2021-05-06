// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineScaleSet along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineScaleSet : VirtualMachineScaleSetOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSet"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSet(ResourceOperationsBase options, VirtualMachineScaleSetData resource) : base(options, resource.Id as ResourceGroupResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineScaleSetData. </summary>
        public VirtualMachineScaleSetData Data { get; private set; }

        /// <inheritdoc />
        protected override VirtualMachineScaleSet GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachineScaleSet> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
