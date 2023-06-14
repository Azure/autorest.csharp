// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// List of Virtual Machine Scale Set OS Upgrade History operation response.
    /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory
    /// </summary>
    internal partial class VirtualMachineScaleSetListOSUpgradeHistory
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetListOSUpgradeHistory. </summary>
        /// <param name="value">
        /// The list of OS upgrades performed on the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal VirtualMachineScaleSetListOSUpgradeHistory(IEnumerable<UpgradeOperationHistoricalStatusInfo> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetListOSUpgradeHistory. </summary>
        /// <param name="value">
        /// The list of OS upgrades performed on the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.value
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of OS Upgrade History. Call ListNext() with this to fetch the next page of history of upgrades.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.nextLink
        /// </param>
        internal VirtualMachineScaleSetListOSUpgradeHistory(IReadOnlyList<UpgradeOperationHistoricalStatusInfo> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of OS upgrades performed on the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.value
        /// </summary>
        public IReadOnlyList<UpgradeOperationHistoricalStatusInfo> Value { get; }
        /// <summary>
        /// The uri to fetch the next page of OS Upgrade History. Call ListNext() with this to fetch the next page of history of upgrades.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
