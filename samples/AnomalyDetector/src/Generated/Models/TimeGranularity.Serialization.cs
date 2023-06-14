// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace AnomalyDetector.Models
{
    internal static partial class TimeGranularityExtensions
    {
        public static string ToSerialString(this TimeGranularity value) => value switch
        {
            TimeGranularity.Yearly => "yearly",
            TimeGranularity.Monthly => "monthly",
            TimeGranularity.Weekly => "weekly",
            TimeGranularity.Daily => "daily",
            TimeGranularity.Hourly => "hourly",
            TimeGranularity.PerMinute => "minutely",
            TimeGranularity.PerSecond => "secondly",
            TimeGranularity.Microsecond => "microsecond",
            TimeGranularity.None => "none",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TimeGranularity value.")
        };

        public static TimeGranularity ToTimeGranularity(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "yearly")) return TimeGranularity.Yearly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "monthly")) return TimeGranularity.Monthly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "weekly")) return TimeGranularity.Weekly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "daily")) return TimeGranularity.Daily;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hourly")) return TimeGranularity.Hourly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "minutely")) return TimeGranularity.PerMinute;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "secondly")) return TimeGranularity.PerSecond;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "microsecond")) return TimeGranularity.Microsecond;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "none")) return TimeGranularity.None;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TimeGranularity value.");
        }
    }
}
