// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace body_complex.Models.V20160229
{
    public static class GoblinSharkColorExtensions
    {
        public static string ToSerialString(this GoblinSharkColor value) => value switch
        {
            GoblinSharkColor.Pink => "pink",
            GoblinSharkColor.Gray => "gray",
            GoblinSharkColor.Brown => "brown",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GoblinSharkColor value.")
        };

        public static GoblinSharkColor ToGoblinSharkColor(this string value) => value switch
        {
            "pink" => GoblinSharkColor.Pink,
            "gray" => GoblinSharkColor.Gray,
            "brown" => GoblinSharkColor.Brown,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown GoblinSharkColor value.")
        };
    }
}
