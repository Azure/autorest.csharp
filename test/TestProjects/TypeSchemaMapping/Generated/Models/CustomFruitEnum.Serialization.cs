// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace AnotherCustomNamespace
{
    internal static class CustomFruitEnumExtensions
    {
        public static string ToSerialString(this CustomFruitEnum value) => value switch
        {
            CustomFruitEnum.Apple => "apple",
            CustomFruitEnum.Pear => "pear",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CustomFruitEnum value.")
        };

        public static CustomFruitEnum ToCustomFruitEnum(this string value) => value switch
        {
            "apple" => CustomFruitEnum.Apple,
            "pear" => CustomFruitEnum.Pear,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CustomFruitEnum value.")
        };
    }
}
