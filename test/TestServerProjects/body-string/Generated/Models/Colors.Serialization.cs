// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_string.Models
{
    internal static partial class ColorsExtensions
    {
        public static string ToSerialString(this Colors value) => value switch
        {
            Colors.RedColor => "red color",
            Colors.GreenColor => "green-color",
            Colors.BlueColor => "blue_color",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Colors value.")
        };

        public static Colors ToColors(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "red color")) return Colors.RedColor;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "green-color")) return Colors.GreenColor;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "blue_color")) return Colors.BlueColor;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Colors value.");
        }
    }
}
