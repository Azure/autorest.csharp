// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CustomizationsInCadl.Models
{
    internal static partial class RenamedEnumExtensions
    {
        public static string ToSerialString(this RenamedEnum value) => value switch
        {
            RenamedEnum.One => "1",
            RenamedEnum.Two => "2",
            RenamedEnum.Three => "3",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RenamedEnum value.")
        };

        public static RenamedEnum ToRenamedEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "1")) return RenamedEnum.One;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "2")) return RenamedEnum.Two;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "3")) return RenamedEnum.Three;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RenamedEnum value.");
        }
    }
}
