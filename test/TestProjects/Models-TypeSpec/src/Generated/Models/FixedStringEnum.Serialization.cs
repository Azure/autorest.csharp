// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ModelsTypeSpec.Models
{
    internal static partial class FixedStringEnumExtensions
    {
        public static string ToSerialString(this FixedStringEnum value) => value switch
        {
            FixedStringEnum.One => "1",
            FixedStringEnum.Two => "2",
            FixedStringEnum.Four => "4",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedStringEnum value.")
        };

        public static FixedStringEnum ToFixedStringEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "1")) return FixedStringEnum.One;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "2")) return FixedStringEnum.Two;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "4")) return FixedStringEnum.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedStringEnum value.");
        }
    }
}
