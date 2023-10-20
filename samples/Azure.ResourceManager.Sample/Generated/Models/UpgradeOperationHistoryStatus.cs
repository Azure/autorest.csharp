// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Information about the current running state of the overall upgrade.
    /// Serialized Name: UpgradeOperationHistoryStatus
    /// </summary>
    public partial class UpgradeOperationHistoryStatus
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="UpgradeOperationHistoryStatus"/>. </summary>
        internal UpgradeOperationHistoryStatus()
        {
        }

        /// <summary> Initializes a new instance of <see cref="UpgradeOperationHistoryStatus"/>. </summary>
        /// <param name="code">
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.code
        /// </param>
        /// <param name="startOn">
        /// Start time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.startTime
        /// </param>
        /// <param name="endOn">
        /// End time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.endTime
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UpgradeOperationHistoryStatus(UpgradeState? code, DateTimeOffset? startOn, DateTimeOffset? endOn, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Code = code;
            StartOn = startOn;
            EndOn = endOn;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary>
        /// Code indicating the current status of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.code
        /// </summary>
        public UpgradeState? Code { get; }
        /// <summary>
        /// Start time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.startTime
        /// </summary>
        public DateTimeOffset? StartOn { get; }
        /// <summary>
        /// End time of the upgrade.
        /// Serialized Name: UpgradeOperationHistoryStatus.endTime
        /// </summary>
        public DateTimeOffset? EndOn { get; }
    }
}
