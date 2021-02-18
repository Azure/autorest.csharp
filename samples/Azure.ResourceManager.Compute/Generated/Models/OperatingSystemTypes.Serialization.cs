// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Compute
{
    internal static partial class OperatingSystemTypesExtensions
    {
        public static string ToSerialString(this OperatingSystemTypes value) => value switch
        {
            OperatingSystemTypes.Windows => "Windows",
            OperatingSystemTypes.Linux => "Linux",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemTypes value.")
        };

        public static OperatingSystemTypes ToOperatingSystemTypes(this string value)
        {
            if (string.Equals(value, "Windows", StringComparison.InvariantCultureIgnoreCase)) return OperatingSystemTypes.Windows;
            if (string.Equals(value, "Linux", StringComparison.InvariantCultureIgnoreCase)) return OperatingSystemTypes.Linux;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemTypes value.");
        }
    }
}
