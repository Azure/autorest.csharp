// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class IntervalInMinExtensions
    {
        public static string ToSerialString(this IntervalInMin value) => value switch
        {
            IntervalInMin.ThreeMins => "ThreeMins",
            IntervalInMin.FiveMins => "FiveMins",
            IntervalInMin.ThirtyMins => "ThirtyMins",
            IntervalInMin.SixtyMins => "SixtyMins",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IntervalInMin value.")
        };

        public static IntervalInMin ToIntervalInMin(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ThreeMins")) return IntervalInMin.ThreeMins;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "FiveMins")) return IntervalInMin.FiveMins;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ThirtyMins")) return IntervalInMin.ThirtyMins;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SixtyMins")) return IntervalInMin.SixtyMins;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IntervalInMin value.");
        }
    }
}
