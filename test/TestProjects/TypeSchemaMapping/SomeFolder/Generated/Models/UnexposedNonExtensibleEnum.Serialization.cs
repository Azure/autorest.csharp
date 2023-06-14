// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    internal static partial class UnexposedNonExtensibleEnumExtensions
    {
        public static string ToSerialString(this UnexposedNonExtensibleEnum value) => value switch
        {
            UnexposedNonExtensibleEnum.A => "A",
            UnexposedNonExtensibleEnum.B => "B",
            UnexposedNonExtensibleEnum.C => "C",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UnexposedNonExtensibleEnum value.")
        };

        public static UnexposedNonExtensibleEnum ToUnexposedNonExtensibleEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "A")) return UnexposedNonExtensibleEnum.A;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "B")) return UnexposedNonExtensibleEnum.B;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "C")) return UnexposedNonExtensibleEnum.C;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UnexposedNonExtensibleEnum value.");
        }
    }
}
