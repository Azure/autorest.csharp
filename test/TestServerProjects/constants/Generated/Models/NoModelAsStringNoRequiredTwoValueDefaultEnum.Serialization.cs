// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringNoRequiredTwoValueDefaultEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringNoRequiredTwoValueDefaultEnum value) => value switch
        {
            NoModelAsStringNoRequiredTwoValueDefaultEnum.Value1 => "value1",
            NoModelAsStringNoRequiredTwoValueDefaultEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueDefaultEnum value.")
        };

        public static NoModelAsStringNoRequiredTwoValueDefaultEnum ToNoModelAsStringNoRequiredTwoValueDefaultEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringNoRequiredTwoValueDefaultEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringNoRequiredTwoValueDefaultEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueDefaultEnum value.");
        }
    }
}
