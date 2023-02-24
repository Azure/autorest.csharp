// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace constants.Models
{
    internal static partial class NoModelAsStringNoRequiredTwoValueNoDefaultOpEnumExtensions
    {
        public static string ToSerialString(this NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum value) => value switch
        {
            NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum.Value1 => "value1",
            NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum.Value2 => "value2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum value.")
        };

        public static NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum ToNoModelAsStringNoRequiredTwoValueNoDefaultOpEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value1")) return NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum.Value1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "value2")) return NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringNoRequiredTwoValueNoDefaultOpEnum value.");
        }
    }
}
