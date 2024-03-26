// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Union.Models
{
    internal static partial class UDExtensions
    {
        public static string ToSerialString(this UD value) => value switch
        {
            UD.Up => "up",
            UD.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UD value.")
        };

        public static UD ToUD(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "up")) return UD.Up;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "down")) return UD.Down;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UD value.");
        }
    }
}
