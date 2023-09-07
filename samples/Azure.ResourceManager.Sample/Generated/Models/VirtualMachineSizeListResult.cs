// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineSizeListResult
    /// </summary>
    internal partial class VirtualMachineSizeListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineSizeListResult"/>. </summary>
        internal VirtualMachineSizeListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineSize>();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineSizeListResult"/>. </summary>
        /// <param name="value">
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineSizeListResult(IReadOnlyList<VirtualMachineSize> value, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineSize> Value { get; }
    }
}
