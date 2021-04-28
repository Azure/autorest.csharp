// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineScaleSetExtension along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineScaleSetExtension : VirtualMachineScaleSetExtensionOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetExtension"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetExtension(ResourceOperationsBase options, VirtualMachineScaleSetExtensionData resource) : base(options, resource.Id as TenantResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineScaleSetExtensionData. </summary>
        public VirtualMachineScaleSetExtensionData Data { get; private set; }

        /// <inheritdoc />
        protected override VirtualMachineScaleSetExtension GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachineScaleSetExtension> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
