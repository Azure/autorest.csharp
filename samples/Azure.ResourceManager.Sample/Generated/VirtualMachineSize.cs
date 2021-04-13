// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineSize along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineSize : VirtualMachineSizeOperations
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineSize"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineSize(ResourceOperationsBase options, VirtualMachineSizeData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the availability set data. </summary>
        public VirtualMachineSizeData Data { get; private set; }
    }
}
