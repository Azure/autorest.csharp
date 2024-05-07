// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Union.Models
{
    internal static partial class EnumsOnlyCasesLrExtensions
    {
        public static string ToSerialString(this EnumsOnlyCasesLr value) => value switch
        {
            EnumsOnlyCasesLr.Left => "left",
            EnumsOnlyCasesLr.Right => "right",
            EnumsOnlyCasesLr.Up => "up",
            EnumsOnlyCasesLr.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumsOnlyCasesLr value.")
        };

        public static EnumsOnlyCasesLr ToEnumsOnlyCasesLr(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "left")) return EnumsOnlyCasesLr.Left;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "right")) return EnumsOnlyCasesLr.Right;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "up")) return EnumsOnlyCasesLr.Up;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "down")) return EnumsOnlyCasesLr.Down;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumsOnlyCasesLr value.");
        }
    }
}
