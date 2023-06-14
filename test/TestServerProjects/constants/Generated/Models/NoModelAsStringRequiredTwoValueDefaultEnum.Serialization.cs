// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringRequiredTwoValueDefaultEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringRequiredTwoValueDefaultEnum value) => value switch
        {
            NoModelAsStringRequiredTwoValueDefaultEnum.Value1 => "value1",
            NoModelAsStringRequiredTwoValueDefaultEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueDefaultEnum value.")
        };

        public static NoModelAsStringRequiredTwoValueDefaultEnum ToNoModelAsStringRequiredTwoValueDefaultEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringRequiredTwoValueDefaultEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringRequiredTwoValueDefaultEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueDefaultEnum value.");
        }
    }
}
