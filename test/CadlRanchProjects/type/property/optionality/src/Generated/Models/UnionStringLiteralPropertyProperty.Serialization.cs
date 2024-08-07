// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Property.Optionality.Models
{
    internal static partial class UnionStringLiteralPropertyPropertyExtensions
    {
        public static string ToSerialString(this UnionStringLiteralPropertyProperty value) => value switch
        {
            UnionStringLiteralPropertyProperty.Hello => "hello",
            UnionStringLiteralPropertyProperty.World => "world",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UnionStringLiteralPropertyProperty value.")
        };

        public static UnionStringLiteralPropertyProperty ToUnionStringLiteralPropertyProperty(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hello")) return UnionStringLiteralPropertyProperty.Hello;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "world")) return UnionStringLiteralPropertyProperty.World;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UnionStringLiteralPropertyProperty value.");
        }
    }
}
