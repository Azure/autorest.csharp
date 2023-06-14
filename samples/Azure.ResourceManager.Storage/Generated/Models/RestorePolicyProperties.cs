// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The blob service properties for blob restore policy. </summary>
    public partial class RestorePolicyProperties
    {
        /// <summary> Initializes a new instance of RestorePolicyProperties. </summary>
        /// <param name="enabled"> Blob restore is enabled if set to true. </param>
        public RestorePolicyProperties(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary> Initializes a new instance of RestorePolicyProperties. </summary>
        /// <param name="enabled"> Blob restore is enabled if set to true. </param>
        /// <param name="days"> how long this blob can be restored. It should be great than zero and less than DeleteRetentionPolicy.days. </param>
        /// <param name="lastEnabledOn"> Deprecated in favor of minRestoreTime property. </param>
        /// <param name="minRestoreOn"> Returns the minimum date and time that the restore can be started. </param>
        internal RestorePolicyProperties(bool enabled, int? days, DateTimeOffset? lastEnabledOn, DateTimeOffset? minRestoreOn)
        {
            Enabled = enabled;
            Days = days;
            LastEnabledOn = lastEnabledOn;
            MinRestoreOn = minRestoreOn;
        }

        /// <summary> Blob restore is enabled if set to true. </summary>
        public bool Enabled { get; set; }
        /// <summary> how long this blob can be restored. It should be great than zero and less than DeleteRetentionPolicy.days. </summary>
        public int? Days { get; set; }
        /// <summary> Deprecated in favor of minRestoreTime property. </summary>
        public DateTimeOffset? LastEnabledOn { get; }
        /// <summary> Returns the minimum date and time that the restore can be started. </summary>
        public DateTimeOffset? MinRestoreOn { get; }
    }
}
