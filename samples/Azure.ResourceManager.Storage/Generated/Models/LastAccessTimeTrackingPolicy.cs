// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The blob service properties for Last access time based tracking policy. </summary>
    public partial class LastAccessTimeTrackingPolicy
    {
        /// <summary> Initializes a new instance of LastAccessTimeTrackingPolicy. </summary>
        /// <param name="enable"> When set to true last access time based tracking is enabled. </param>
        public LastAccessTimeTrackingPolicy(bool enable)
        {
            Enable = enable;
            BlobType = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of LastAccessTimeTrackingPolicy. </summary>
        /// <param name="enable"> When set to true last access time based tracking is enabled. </param>
        /// <param name="name"> Name of the policy. The valid value is AccessTimeTracking. This field is currently read only. </param>
        /// <param name="trackingGranularityInDays"> The field specifies blob object tracking granularity in days, typically how often the blob object should be tracked.This field is currently read only with value as 1. </param>
        /// <param name="blobType"> An array of predefined supported blob types. Only blockBlob is the supported value. This field is currently read only. </param>
        internal LastAccessTimeTrackingPolicy(bool enable, Name? name, int? trackingGranularityInDays, IList<string> blobType)
        {
            Enable = enable;
            Name = name;
            TrackingGranularityInDays = trackingGranularityInDays;
            BlobType = blobType;
        }

        /// <summary> When set to true last access time based tracking is enabled. </summary>
        public bool Enable { get; set; }
        /// <summary> Name of the policy. The valid value is AccessTimeTracking. This field is currently read only. </summary>
        public Name? Name { get; set; }
        /// <summary> The field specifies blob object tracking granularity in days, typically how often the blob object should be tracked.This field is currently read only with value as 1. </summary>
        public int? TrackingGranularityInDays { get; set; }
        /// <summary> An array of predefined supported blob types. Only blockBlob is the supported value. This field is currently read only. </summary>
        public IList<string> BlobType { get; }
    }
}
