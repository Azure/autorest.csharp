// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace _Type.Property.ValueTypes.Models
{
    internal static partial class FixedInnerEnumExtensions
    {
        public static string ToSerialString(this FixedInnerEnum value) => value switch
        {
            FixedInnerEnum.ValueOne => "ValueOne",
            FixedInnerEnum.ValueTwo => "ValueTwo",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedInnerEnum value.")
        };

        public static FixedInnerEnum ToFixedInnerEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ValueOne")) return FixedInnerEnum.ValueOne;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ValueTwo")) return FixedInnerEnum.ValueTwo;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedInnerEnum value.");
        }
    }
}
