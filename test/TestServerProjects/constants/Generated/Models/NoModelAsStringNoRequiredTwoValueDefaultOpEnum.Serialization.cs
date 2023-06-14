// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringNoRequiredTwoValueDefaultOpEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringNoRequiredTwoValueDefaultOpEnum value) => value switch
        {
            NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1 => "value1",
            NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueDefaultOpEnum value.")
        };

        public static NoModelAsStringNoRequiredTwoValueDefaultOpEnum ToNoModelAsStringNoRequiredTwoValueDefaultOpEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringNoRequiredTwoValueDefaultOpEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueDefaultOpEnum value.");
        }
    }
}
