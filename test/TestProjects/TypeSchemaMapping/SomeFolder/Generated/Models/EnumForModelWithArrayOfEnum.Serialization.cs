// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    internal static partial class EnumForModelWithArrayOfEnumExtensions
    {
        public static string ToSerialString(this EnumForModelWithArrayOfEnum value) => value switch
        {
            EnumForModelWithArrayOfEnum.A => "A",
            EnumForModelWithArrayOfEnum.B => "B",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumForModelWithArrayOfEnum value.")
        };

        public static EnumForModelWithArrayOfEnum ToEnumForModelWithArrayOfEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "A")) return EnumForModelWithArrayOfEnum.A;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "B")) return EnumForModelWithArrayOfEnum.B;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumForModelWithArrayOfEnum value.");
        }
    }
}
