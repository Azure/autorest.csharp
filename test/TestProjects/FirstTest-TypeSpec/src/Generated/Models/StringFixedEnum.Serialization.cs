// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace FirstTestTypeSpec.Models
{
    internal static partial class StringFixedEnumExtensions
    {
        public static string ToSerialString(this StringFixedEnum value) => value switch
        {
            StringFixedEnum.One => "1",
            StringFixedEnum.Two => "2",
            StringFixedEnum.Four => "4",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StringFixedEnum value.")
        };

        public static StringFixedEnum ToStringFixedEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "1")) return StringFixedEnum.One;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "2")) return StringFixedEnum.Two;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "4")) return StringFixedEnum.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StringFixedEnum value.");
        }
    }
}
