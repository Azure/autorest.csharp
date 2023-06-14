// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringRequiredTwoValueNoDefaultOpEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringRequiredTwoValueNoDefaultOpEnum value) => value switch
        {
            NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value1 => "value1",
            NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueNoDefaultOpEnum value.")
        };

        public static NoModelAsStringRequiredTwoValueNoDefaultOpEnum ToNoModelAsStringRequiredTwoValueNoDefaultOpEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueNoDefaultOpEnum value.");
        }
    }
}
