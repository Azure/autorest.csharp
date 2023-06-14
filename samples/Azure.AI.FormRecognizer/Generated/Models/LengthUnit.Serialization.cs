// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class LengthUnitExtensions
    {
        public static string ToSerialString(this LengthUnit value) => value switch
        {
            LengthUnit.Pixel => "pixel",
            LengthUnit.Inch => "inch",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LengthUnit value.")
        };

        public static LengthUnit ToLengthUnit(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "pixel")) return LengthUnit.Pixel;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "inch")) return LengthUnit.Inch;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LengthUnit value.");
        }
    }
}
