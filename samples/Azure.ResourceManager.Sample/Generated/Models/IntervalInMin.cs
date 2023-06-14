// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Interval value in minutes used to create LogAnalytics call rate logs.
    /// Serialized Name: IntervalInMins
    /// </summary>
    public enum IntervalInMin
    {
        /// <summary>
        /// ThreeMins
        /// Serialized Name: IntervalInMins.ThreeMins
        /// </summary>
        ThreeMins,
        /// <summary>
        /// FiveMins
        /// Serialized Name: IntervalInMins.FiveMins
        /// </summary>
        FiveMins,
        /// <summary>
        /// ThirtyMins
        /// Serialized Name: IntervalInMins.ThirtyMins
        /// </summary>
        ThirtyMins,
        /// <summary>
        /// SixtyMins
        /// Serialized Name: IntervalInMins.SixtyMins
        /// </summary>
        SixtyMins
    }
}
