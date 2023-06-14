// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Management policy action for blob version. </summary>
    public partial class ManagementPolicyVersion
    {
        /// <summary> Initializes a new instance of ManagementPolicyVersion. </summary>
        public ManagementPolicyVersion()
        {
        }

        /// <summary> Initializes a new instance of ManagementPolicyVersion. </summary>
        /// <param name="tierToCool"> The function to tier blob version to cool storage. Support blob version currently at Hot tier. </param>
        /// <param name="tierToArchive"> The function to tier blob version to archive storage. Support blob version currently at Hot or Cool tier. </param>
        /// <param name="delete"> The function to delete the blob version. </param>
        internal ManagementPolicyVersion(DateAfterCreation tierToCool, DateAfterCreation tierToArchive, DateAfterCreation delete)
        {
            TierToCool = tierToCool;
            TierToArchive = tierToArchive;
            Delete = delete;
        }

        /// <summary> The function to tier blob version to cool storage. Support blob version currently at Hot tier. </summary>
        internal DateAfterCreation TierToCool { get; set; }
        /// <summary> Value indicating the age in days after creation. </summary>
        public float? TierToCoolDaysAfterCreationGreaterThan
        {
            get => TierToCool is null ? default(float?) : TierToCool.DaysAfterCreationGreaterThan;
            set
            {
                TierToCool = value.HasValue ? new DateAfterCreation(value.Value) : null;
            }
        }

        /// <summary> The function to tier blob version to archive storage. Support blob version currently at Hot or Cool tier. </summary>
        internal DateAfterCreation TierToArchive { get; set; }
        /// <summary> Value indicating the age in days after creation. </summary>
        public float? TierToArchiveDaysAfterCreationGreaterThan
        {
            get => TierToArchive is null ? default(float?) : TierToArchive.DaysAfterCreationGreaterThan;
            set
            {
                TierToArchive = value.HasValue ? new DateAfterCreation(value.Value) : null;
            }
        }

        /// <summary> The function to delete the blob version. </summary>
        internal DateAfterCreation Delete { get; set; }
        /// <summary> Value indicating the age in days after creation. </summary>
        public float? DeleteDaysAfterCreationGreaterThan
        {
            get => Delete is null ? default(float?) : Delete.DaysAfterCreationGreaterThan;
            set
            {
                Delete = value.HasValue ? new DateAfterCreation(value.Value) : null;
            }
        }
    }
}
