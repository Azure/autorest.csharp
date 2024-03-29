// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace body_array.Models
{
    internal static partial class FooEnumExtensions
    {
        public static string ToSerialString(this FooEnum value) => value switch
        {
            FooEnum.Foo1 => "foo1",
            FooEnum.Foo2 => "foo2",
            FooEnum.Foo3 => "foo3",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FooEnum value.")
        };

        public static FooEnum ToFooEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "foo1")) return FooEnum.Foo1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "foo2")) return FooEnum.Foo2;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "foo3")) return FooEnum.Foo3;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FooEnum value.");
        }
    }
}
