// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtAcronymMapping;

namespace MgmtAcronymMapping.Models
{
    /// <summary>
    /// The List VM scale set extension operation response.
    /// Serialized Name: VirtualMachineScaleSetExtensionListResult
    /// </summary>
    internal partial class VirtualMachineScaleSetExtensionListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetExtensionListResult"/>. </summary>
        /// <param name="value">
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetExtensionListResult(IEnumerable<VirtualMachineScaleSetExtensionData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetExtensionListResult"/>. </summary>
        /// <param name="value">
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of VM scale set extensions. Call ListNext() with this to fetch the next page of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.nextLink
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetExtensionListResult(IReadOnlyList<VirtualMachineScaleSetExtensionData> value, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetExtensionListResult"/> for deserialization. </summary>
        internal VirtualMachineScaleSetExtensionListResult()
        {
        }

        /// <summary>
        /// The list of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetExtensionData> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of VM scale set extensions. Call ListNext() with this to fetch the next page of VM scale set extensions.
        /// Serialized Name: VirtualMachineScaleSetExtensionListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
