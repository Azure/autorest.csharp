// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace url.Models
{
    internal static class UriColorExtensions
    {
        public static string ToSerialString(this UriColor value) => value switch
        {
            UriColor.RedColor => "red color",
            UriColor.GreenColor => "green color",
            UriColor.BlueColor => "blue color",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UriColor value.")
        };

        public static UriColor ToUriColor(this string value) => value switch
        {
            "red color" => UriColor.RedColor,
            "green color" => UriColor.GreenColor,
            "blue color" => UriColor.BlueColor,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UriColor value.")
        };
    }
}
