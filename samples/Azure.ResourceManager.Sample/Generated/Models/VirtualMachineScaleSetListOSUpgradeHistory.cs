// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// List of Virtual Machine Scale Set OS Upgrade History operation response.
    /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory
    /// </summary>
    internal partial class VirtualMachineScaleSetListOSUpgradeHistory
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListOSUpgradeHistory"/>. </summary>
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

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListOSUpgradeHistory"/>. </summary>
        /// <param name="value">
        /// The list of OS upgrades performed on the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.value
        /// </param>
        /// <param name="etag">
        /// Modified whenever there is a change.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.etag
        /// </param>
        /// <param name="nextLink">
        /// The uri to fetch the next page of OS Upgrade History. Call ListNext() with this to fetch the next page of history of upgrades.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.nextLink
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VirtualMachineScaleSetListOSUpgradeHistory(IReadOnlyList<UpgradeOperationHistoricalStatusInfo> value, ETag? etag, string nextLink, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            Etag = etag;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="VirtualMachineScaleSetListOSUpgradeHistory"/> for deserialization. </summary>
        internal VirtualMachineScaleSetListOSUpgradeHistory()
        {
        }

        /// <summary>
        /// The list of OS upgrades performed on the virtual machine scale set.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.value
        /// </summary>
        public IReadOnlyList<UpgradeOperationHistoricalStatusInfo> Value { get; }
        /// <summary>
        /// Modified whenever there is a change.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.etag
        /// </summary>
        public ETag? Etag { get; }
        /// <summary>
        /// The uri to fetch the next page of OS Upgrade History. Call ListNext() with this to fetch the next page of history of upgrades.
        /// Serialized Name: VirtualMachineScaleSetListOSUpgradeHistory.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
