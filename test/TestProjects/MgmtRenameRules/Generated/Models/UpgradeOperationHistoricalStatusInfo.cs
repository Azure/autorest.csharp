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
    /// Virtual Machine Scale Set OS Upgrade History operation response.
    /// Serialized Name: UpgradeOperationHistoricalStatusInfo
    /// </summary>
    public partial class UpgradeOperationHistoricalStatusInfo
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.UpgradeOperationHistoricalStatusInfo
        ///
        /// </summary>
        internal UpgradeOperationHistoricalStatusInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtRenameRules.Models.UpgradeOperationHistoricalStatusInfo
        ///
        /// </summary>
        /// <param name="properties">
        /// Information about the properties of the upgrade operation.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.properties
        /// </param>
        /// <param name="upgradeOperationHistoricalStatusInfoType">
        /// Resource type
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.type
        /// </param>
        /// <param name="location">
        /// Resource location
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.location
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UpgradeOperationHistoricalStatusInfo(UpgradeOperationHistoricalStatusInfoProperties properties, ResourceType? upgradeOperationHistoricalStatusInfoType, AzureLocation? location, Dictionary<string, BinaryData> rawData)
        {
            Properties = properties;
            UpgradeOperationHistoricalStatusInfoType = upgradeOperationHistoricalStatusInfoType;
            Location = location;
            _rawData = rawData;
        }

        /// <summary>
        /// Information about the properties of the upgrade operation.
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.properties
        /// </summary>
        public UpgradeOperationHistoricalStatusInfoProperties Properties { get; }
        /// <summary>
        /// Resource type
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.type
        /// </summary>
        public ResourceType? UpgradeOperationHistoricalStatusInfoType { get; }
        /// <summary>
        /// Resource location
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.location
        /// </summary>
        public AzureLocation? Location { get; }
    }
}
