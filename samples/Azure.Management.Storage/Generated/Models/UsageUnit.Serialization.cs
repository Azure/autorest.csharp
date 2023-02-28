// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Management.Storage.Models
{
    internal static partial class UsageUnitExtensions
    {
        public static string ToSerialString(this UsageUnit value) => value switch
        {
            UsageUnit.Count => "Count",
            UsageUnit.Bytes => "Bytes",
            UsageUnit.Seconds => "Seconds",
            UsageUnit.Percent => "Percent",
            UsageUnit.CountsPerSecond => "CountsPerSecond",
            UsageUnit.BytesPerSecond => "BytesPerSecond",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UsageUnit value.")
        };

        public static UsageUnit ToUsageUnit(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Count")) return UsageUnit.Count;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Bytes")) return UsageUnit.Bytes;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Seconds")) return UsageUnit.Seconds;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Percent")) return UsageUnit.Percent;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "CountsPerSecond")) return UsageUnit.CountsPerSecond;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "BytesPerSecond")) return UsageUnit.BytesPerSecond;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UsageUnit value.");
        }
    }
}
