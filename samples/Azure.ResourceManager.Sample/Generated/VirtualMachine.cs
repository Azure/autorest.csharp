// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachine along with the instance operations that can be performed on it. </summary>
    public class VirtualMachine : VirtualMachineOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachine"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachine(ResourceOperationsBase options, VirtualMachineData resource) : base(options, resource.Id as TenantResourceIdentifier)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineData. </summary>
        public VirtualMachineData Data { get; private set; }

        /// <inheritdoc />
        protected override VirtualMachine GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<VirtualMachine> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}
