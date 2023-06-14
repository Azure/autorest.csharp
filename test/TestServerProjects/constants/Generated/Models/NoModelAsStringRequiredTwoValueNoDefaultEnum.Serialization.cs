// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringRequiredTwoValueNoDefaultEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringRequiredTwoValueNoDefaultEnum value) => value switch
        {
            NoModelAsStringRequiredTwoValueNoDefaultEnum.Value1 => "value1",
            NoModelAsStringRequiredTwoValueNoDefaultEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueNoDefaultEnum value.")
        };

        public static NoModelAsStringRequiredTwoValueNoDefaultEnum ToNoModelAsStringRequiredTwoValueNoDefaultEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringRequiredTwoValueNoDefaultEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringRequiredTwoValueNoDefaultEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueNoDefaultEnum value.");
        }
    }
}
