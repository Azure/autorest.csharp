// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class OperatingSystemStateTypeExtensions
    {
        public static string ToSerialString(this OperatingSystemStateType value) => value switch
        {
            OperatingSystemStateType.Generalized => "Generalized",
            OperatingSystemStateType.Specialized => "Specialized",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemStateType value.")
        };

        public static OperatingSystemStateType ToOperatingSystemStateType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Generalized")) return OperatingSystemStateType.Generalized;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Specialized")) return OperatingSystemStateType.Specialized;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemStateType value.");
        }
    }
}
