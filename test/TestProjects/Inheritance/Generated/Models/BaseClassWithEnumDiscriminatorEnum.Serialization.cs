// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Inheritance.Models
{
    internal static partial class BaseClassWithEnumDiscriminatorEnumExtensions
    {
        public static string ToSerialString(this BaseClassWithEnumDiscriminatorEnum value) => value switch
        {
            BaseClassWithEnumDiscriminatorEnum.Derived => "derived",
            BaseClassWithEnumDiscriminatorEnum.Other => "other",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BaseClassWithEnumDiscriminatorEnum value.")
        };

        public static BaseClassWithEnumDiscriminatorEnum ToBaseClassWithEnumDiscriminatorEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "derived")) return BaseClassWithEnumDiscriminatorEnum.Derived;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "other")) return BaseClassWithEnumDiscriminatorEnum.Other;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BaseClassWithEnumDiscriminatorEnum value.");
        }
    }
}
