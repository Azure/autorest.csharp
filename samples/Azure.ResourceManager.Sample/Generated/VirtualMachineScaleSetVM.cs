// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineScaleSetVM along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineScaleSetVM : VirtualMachineScaleSetVMOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetVM"/> class for mocking. </summary>
        internal VirtualMachineScaleSetVM() : base()
        {
        }
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineScaleSetVM"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineScaleSetVM(OperationsBase options, VirtualMachineScaleSetVMData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineScaleSetVMData. </summary>
        public VirtualMachineScaleSetVMData Data { get; private set; }
    }
}
