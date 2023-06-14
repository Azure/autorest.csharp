// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace header.Models
{
    internal static partial class GreyscaleColorsExtensions
    {
        public static string ToSerialString(this GreyscaleColors value) => value switch
        {
            GreyscaleColors.White => "White",
            GreyscaleColors.Black => "black",
            GreyscaleColors.Grey => "GREY",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GreyscaleColors value.")
        };

        public static GreyscaleColors ToGreyscaleColors(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "White")) return GreyscaleColors.White;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "black")) return GreyscaleColors.Black;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "GREY")) return GreyscaleColors.Grey;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GreyscaleColors value.");
        }
    }
}
