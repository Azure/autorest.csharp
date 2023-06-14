// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace FirstTestTypeSpec.Models
{
    internal static partial class IntFixedEnumExtensions
    {
        public static IntFixedEnum ToIntFixedEnum(this int value)
        {
            if (value == 1) return IntFixedEnum.One;
            if (value == 2) return IntFixedEnum.Two;
            if (value == 4) return IntFixedEnum.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown IntFixedEnum value.");
        }
    }
}
