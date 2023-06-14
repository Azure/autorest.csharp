// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Virtual Machine Scale Set OS Upgrade History operation response.
    /// Serialized Name: UpgradeOperationHistoricalStatusInfo
    /// </summary>
    public partial class UpgradeOperationHistoricalStatusInfo
    {
        /// <summary> Initializes a new instance of UpgradeOperationHistoricalStatusInfo. </summary>
        internal UpgradeOperationHistoricalStatusInfo()
        {
        }

        /// <summary> Initializes a new instance of UpgradeOperationHistoricalStatusInfo. </summary>
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
        internal UpgradeOperationHistoricalStatusInfo(UpgradeOperationHistoricalStatusInfoProperties properties, string upgradeOperationHistoricalStatusInfoType, AzureLocation? location)
        {
            Properties = properties;
            UpgradeOperationHistoricalStatusInfoType = upgradeOperationHistoricalStatusInfoType;
            Location = location;
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
        public string UpgradeOperationHistoricalStatusInfoType { get; }
        /// <summary>
        /// Resource location
        /// Serialized Name: UpgradeOperationHistoricalStatusInfo.location
        /// </summary>
        public AzureLocation? Location { get; }
    }
}
