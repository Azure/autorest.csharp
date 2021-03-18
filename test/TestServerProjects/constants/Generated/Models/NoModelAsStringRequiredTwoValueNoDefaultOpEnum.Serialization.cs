// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
            if (string.Equals(value, "value1", StringComparison.InvariantCultureIgnoreCase)) return NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value1;
            if (string.Equals(value, "value2", StringComparison.InvariantCultureIgnoreCase)) return NoModelAsStringRequiredTwoValueNoDefaultOpEnum.Value2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown NoModelAsStringRequiredTwoValueNoDefaultOpEnum value.");
        }
    }
}
