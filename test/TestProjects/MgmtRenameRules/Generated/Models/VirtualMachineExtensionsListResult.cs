// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    /// <summary> The List Extension operation response. </summary>
    public partial class VirtualMachineExtensionsListResult
    {
        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        internal VirtualMachineExtensionsListResult()
        {
            Value = new ChangeTrackingList<VirtualMachineExtensionData>();
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionsListResult. </summary>
        /// <param name="value"> The list of extensions. </param>
        internal VirtualMachineExtensionsListResult(IReadOnlyList<VirtualMachineExtensionData> value)
        {
            Value = value;
        }

        /// <summary> The list of extensions. </summary>
        public IReadOnlyList<VirtualMachineExtensionData> Value { get; }
    }
}
