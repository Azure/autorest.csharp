// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class OperatingSystemTypeExtensions
    {
        public static string ToSerialString(this OperatingSystemType value) => value switch
        {
            OperatingSystemType.Windows => "Windows",
            OperatingSystemType.Linux => "Linux",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemType value.")
        };

        public static OperatingSystemType ToOperatingSystemType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Windows")) return OperatingSystemType.Windows;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Linux")) return OperatingSystemType.Linux;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemType value.");
        }
    }
}
