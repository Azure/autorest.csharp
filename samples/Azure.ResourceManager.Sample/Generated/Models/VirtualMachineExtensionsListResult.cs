// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> The List Extension operation response. </summary>
    public partial class VirtualMachineExtensionsListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        internal VirtualMachineExtensionsListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineExtension>();
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        /// <param name="value"> The list of extensions. </param>
        internal VirtualMachineExtensionsListResult(IReadOnlyList<VirtualMachineExtension> value)
        {
            Value = value;
        }

        /// <summary> The list of extensions. </summary>
        public IReadOnlyList<VirtualMachineExtension> Value { get; }
    }
}
