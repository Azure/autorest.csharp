// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace url.Models
{
    internal static partial class UriColorExtensions
    {
        public static string ToSerialString(this UriColor value) => value switch
        {
            UriColor.RedColor => "red color",
            UriColor.GreenColor => "green color",
            UriColor.BlueColor => "blue color",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UriColor value.")
        };

        public static UriColor ToUriColor(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "red color")) return UriColor.RedColor;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "green color")) return UriColor.GreenColor;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "blue color")) return UriColor.BlueColor;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UriColor value.");
        }
    }
}
