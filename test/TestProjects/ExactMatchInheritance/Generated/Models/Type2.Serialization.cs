// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace ExactMatchInheritance.Models
{
    internal static partial class Type2Extensions
    {
        public static string ToSerialString(this Type2 value) => value switch
        {
            Type2.Foo => "foo",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type2 value.")
        };

        public static Type2 ToType2(this string value)
        {
            if (string.Equals(value, "foo", StringComparison.InvariantCultureIgnoreCase)) return Type2.Foo;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type2 value.");
        }
    }
}
