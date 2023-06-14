// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Extension operation response
    /// Serialized Name: VirtualMachineExtensionsListResult
    /// </summary>
    internal partial class VirtualMachineExtensionsListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        internal VirtualMachineExtensionsListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineExtensionData>();
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        /// <param name="value">
        /// The list of extensions
        /// Serialized Name: VirtualMachineExtensionsListResult.value
        /// </param>
        internal VirtualMachineExtensionsListResult(IReadOnlyList<VirtualMachineExtensionData> value)
        {
            Value = value;
        }

        /// <summary>
        /// The list of extensions
        /// Serialized Name: VirtualMachineExtensionsListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineExtensionData> Value { get; }
    }
}
