// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringNoRequiredTwoValueNoDefaultEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringNoRequiredTwoValueNoDefaultEnum value) => value switch
        {
            NoModelAsStringNoRequiredTwoValueNoDefaultEnum.Value1 => "value1",
            NoModelAsStringNoRequiredTwoValueNoDefaultEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueNoDefaultEnum value.")
        };

        public static NoModelAsStringNoRequiredTwoValueNoDefaultEnum ToNoModelAsStringNoRequiredTwoValueNoDefaultEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringNoRequiredTwoValueNoDefaultEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringNoRequiredTwoValueNoDefaultEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueNoDefaultEnum value.");
        }
    }
}
