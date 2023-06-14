// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace NamespaceForEnums
{
    internal static partial class CustomFruitEnumExtensions
    {
        public static string ToSerialString(this CustomFruitEnum value) => value switch
        {
            CustomFruitEnum.Apple2 => "apple",
            CustomFruitEnum.Pear => "pear",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CustomFruitEnum value.")
        };

        public static CustomFruitEnum ToCustomFruitEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "apple")) return CustomFruitEnum.Apple2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "pear")) return CustomFruitEnum.Pear;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CustomFruitEnum value.");
        }
    }
}
