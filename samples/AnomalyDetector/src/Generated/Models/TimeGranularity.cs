// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace AnomalyDetector.Models
{
    public enum TimeGranularity
    {
        /// <summary> yearly. </summary>
        Yearly,
        /// <summary> monthly. </summary>
        Monthly,
        /// <summary> weekly. </summary>
        Weekly,
        /// <summary> daily. </summary>
        Daily,
        /// <summary> hourly. </summary>
        Hourly,
        /// <summary> minutely. </summary>
        PerMinute,
        /// <summary> secondly. </summary>
        PerSecond,
        /// <summary> microsecond. </summary>
        Microsecond,
        /// <summary> none. </summary>
        None
    }
}
