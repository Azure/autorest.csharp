// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The Virtual Machine Scale Set List Skus operation response.
    /// Serialized Name: VirtualMachineScaleSetListSkusResult
    /// </summary>
    internal partial class VirtualMachineScaleSetListSkusResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetListSkusResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of skus available for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListSkusResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListSkusResult(IEnumerable<VirtualMachineScaleSetSku> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineScaleSetListSkusResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of skus available for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListSkusResult.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of Virtual Machine Scale Set Skus. Call ListNext() with this to fetch the next page of VMSS Skus.
        /// Serialized Name: VirtualMachineScaleSetListSkusResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetListSkusResult(IReadOnlyList<VirtualMachineScaleSetSku> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListSkusResult"/> for deserialization. </summary>
        internal VirtualMachineScaleSetListSkusResult()
        {
        }

        /// <summary>
        /// The list of skus available for the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListSkusResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineScaleSetSku> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of Virtual Machine Scale Set Skus. Call ListNext() with this to fetch the next page of VMSS Skus.
        /// Serialized Name: VirtualMachineScaleSetListSkusResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
