// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace body_formdata_urlencoded.Models
{
    internal static partial class PetTypeExtensions
    {
        public static string ToSerialString(this PetType value) => value switch
        {
            PetType.Dog => "dog",
            PetType.Cat => "cat",
            PetType.Fish => "fish",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PetType value.")
        };

        public static PetType ToPetType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "dog")) return PetType.Dog;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "cat")) return PetType.Cat;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "fish")) return PetType.Fish;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PetType value.");
        }
    }
}
