// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace BodyComplex.Models.V20160229
{
    internal static class CMYKColorsExtensions
    {
        public static string ToSerialString(this CMYKColors value) => value switch
        {
            CMYKColors.Cyan => "cyan",
            CMYKColors.Magenta => "Magenta",
            CMYKColors.YELLOW => "YELLOW",
            CMYKColors.BlacK => "blacK",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CMYKColors value.")
        };

        public static CMYKColors ToCMYKColors(this string value) => value switch
        {
            "cyan" => CMYKColors.Cyan,
            "Magenta" => CMYKColors.Magenta,
            "YELLOW" => CMYKColors.YELLOW,
            "blacK" => CMYKColors.BlacK,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CMYKColors value.")
        };
    }
}
