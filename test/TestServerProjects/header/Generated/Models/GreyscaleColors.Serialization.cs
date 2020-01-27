// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace header.Models
{
    internal static class GreyscaleColorsExtensions
    {
        public static string ToSerialString(this GreyscaleColors value) => value switch
        {
            GreyscaleColors.White => "White",
            GreyscaleColors.Black => "black",
            GreyscaleColors.GREY => "GREY",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GreyscaleColors value.")
        };

        public static GreyscaleColors ToGreyscaleColors(this string value) => value switch
        {
            "White" => GreyscaleColors.White,
            "black" => GreyscaleColors.Black,
            "GREY" => GreyscaleColors.GREY,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GreyscaleColors value.")
        };
    }
}
