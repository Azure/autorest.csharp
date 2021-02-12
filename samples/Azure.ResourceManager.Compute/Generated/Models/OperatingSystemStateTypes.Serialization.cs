// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Compute
{
    internal static partial class OperatingSystemStateTypesExtensions
    {
        public static string ToSerialString(this OperatingSystemStateTypes value) => value switch
        {
            OperatingSystemStateTypes.Generalized => "Generalized",
            OperatingSystemStateTypes.Specialized => "Specialized",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemStateTypes value.")
        };

        public static OperatingSystemStateTypes ToOperatingSystemStateTypes(this string value)
        {
            if (string.Equals(value, "Generalized", StringComparison.InvariantCultureIgnoreCase)) return OperatingSystemStateTypes.Generalized;
            if (string.Equals(value, "Specialized", StringComparison.InvariantCultureIgnoreCase)) return OperatingSystemStateTypes.Specialized;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown OperatingSystemStateTypes value.");
        }
    }
}
