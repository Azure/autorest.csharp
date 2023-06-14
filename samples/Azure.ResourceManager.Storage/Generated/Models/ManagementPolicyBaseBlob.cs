// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Management policy action for base blob. </summary>
    public partial class ManagementPolicyBaseBlob
    {
        /// <summary> Initializes a new instance of ManagementPolicyBaseBlob. </summary>
        public ManagementPolicyBaseBlob()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyBaseBlob. </summary>
        /// <param name="tierToCool"> The function to tier blobs to cool storage. Support blobs currently at Hot tier. </param>
        /// <param name="tierToArchive"> The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier. </param>
        /// <param name="delete"> The function to delete the blob. </param>
        /// <param name="enableAutoTierToHotFromCool"> This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan. </param>
        internal ManagementPolicyBaseBlob(DateAfterModification tierToCool, DateAfterModification tierToArchive, DateAfterModification delete, bool? enableAutoTierToHotFromCool)
        {
            TierToCool = tierToCool;
            TierToArchive = tierToArchive;
            Delete = delete;
            EnableAutoTierToHotFromCool = enableAutoTierToHotFromCool;
        }

        /// <summary> The function to tier blobs to cool storage. Support blobs currently at Hot tier. </summary>
        public DateAfterModification TierToCool { get; set; }
        /// <summary> The function to tier blobs to archive storage. Support blobs currently at Hot or Cool tier. </summary>
        public DateAfterModification TierToArchive { get; set; }
        /// <summary> The function to delete the blob. </summary>
        public DateAfterModification Delete { get; set; }
        /// <summary> This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan. </summary>
        public bool? EnableAutoTierToHotFromCool { get; set; }
    }
}
