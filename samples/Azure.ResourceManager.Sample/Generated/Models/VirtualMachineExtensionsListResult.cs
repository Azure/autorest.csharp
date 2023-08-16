// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineExtensionsListResult
        ///
        /// </summary>
        internal VirtualMachineExtensionsListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineExtensionData>();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.VirtualMachineExtensionsListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of extensions
        /// Serialized Name: VirtualMachineExtensionsListResult.value
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineExtensionsListResult(IReadOnlyList<VirtualMachineExtensionData> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of extensions
        /// Serialized Name: VirtualMachineExtensionsListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineExtensionData> Value { get; }
    }
}
