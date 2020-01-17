// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace body_string.Models
{
    internal static class ColorsExtensions
    {
        public static string ToSerialString(this Colors value) => value switch
        {
            Colors.RedColor => "red color",
            Colors.GreenColor => "green-color",
            Colors.BlueColor => "blue_color",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Colors value.")
        };

        public static Colors ToColors(this string value) => value switch
        {
            "red color" => Colors.RedColor,
            "green-color" => Colors.GreenColor,
            "blue_color" => Colors.BlueColor,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Colors value.")
        };
    }
}
