// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A Class representing a VirtualMachineExtensionImage along with the instance operations that can be performed on it. </summary>
    public class VirtualMachineExtensionImage : VirtualMachineExtensionImageOperations
    {
        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineExtensionImage"/> class for mocking. </summary>
        internal VirtualMachineExtensionImage() : base()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "VirtualMachineExtensionImage"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal VirtualMachineExtensionImage(OperationsBase options, VirtualMachineExtensionImageData resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the VirtualMachineExtensionImageData. </summary>
        public VirtualMachineExtensionImageData Data { get; private set; }
    }
}
