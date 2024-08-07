// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Union.Models
{
    internal static partial class EnumsOnlyCasesUdExtensions
    {
        public static string ToSerialString(this EnumsOnlyCasesUd value) => value switch
        {
            EnumsOnlyCasesUd.Up => "up",
            EnumsOnlyCasesUd.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumsOnlyCasesUd value.")
        };

        public static EnumsOnlyCasesUd ToEnumsOnlyCasesUd(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "up")) return EnumsOnlyCasesUd.Up;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "down")) return EnumsOnlyCasesUd.Down;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumsOnlyCasesUd value.");
        }
    }
}
