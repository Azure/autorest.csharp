// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ModelWithConverterUsage.Models
{
    internal static partial class EnumPropertyExtensions
    {
        public static string ToSerialString(this EnumProperty value) => value switch
        {
            EnumProperty.A => "A",
            EnumProperty.B => "B",
            EnumProperty.C => "C",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumProperty value.")
        };

        public static EnumProperty ToEnumProperty(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "A")) return EnumProperty.A;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "B")) return EnumProperty.B;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "C")) return EnumProperty.C;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumProperty value.");
        }
    }
}
