// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// The List Virtual Machine operation response.
    /// Serialized Name: VirtualMachineSizeListResult
    /// </summary>
    internal partial class VirtualMachineSizeListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineSizeListResult
        ///
        /// </summary>
        internal VirtualMachineSizeListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineSize>();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.VirtualMachineSizeListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineSizeListResult(IReadOnlyList<VirtualMachineSize> value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of virtual machine sizes.
        /// Serialized Name: VirtualMachineSizeListResult.value
        /// </summary>
        public IReadOnlyList<VirtualMachineSize> Value { get; }
    }
}
