// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The blob service properties for change feed events. </summary>
    public partial class ChangeFeed
    {
        /// <summary> Initializes a new instance of ChangeFeed. </summary>
        public ChangeFeed()
        {
        }

        /// <summary> Initializes a new instance of ChangeFeed. </summary>
        /// <param name="enabled"> Indicates whether change feed event logging is enabled for the Blob service. </param>
        /// <param name="retentionInDays"> Indicates the duration of changeFeed retention in days. Minimum value is 1 day and maximum value is 146000 days (400 years). A null value indicates an infinite retention of the change feed. </param>
        internal ChangeFeed(bool? enabled, int? retentionInDays)
        {
            Enabled = enabled;
            RetentionInDays = retentionInDays;
        }

        /// <summary> Indicates whether change feed event logging is enabled for the Blob service. </summary>
        public bool? Enabled { get; set; }
        /// <summary> Indicates the duration of changeFeed retention in days. Minimum value is 1 day and maximum value is 146000 days (400 years). A null value indicates an infinite retention of the change feed. </summary>
        public int? RetentionInDays { get; set; }
    }
}
