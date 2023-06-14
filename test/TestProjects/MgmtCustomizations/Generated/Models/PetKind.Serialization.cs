// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtCustomizations.Models
{
    internal static partial class PetKindExtensions
    {
        public static string ToSerialString(this PetKind value) => value switch
        {
            PetKind.Cat => "Cat",
            PetKind.Dog => "Dog",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PetKind value.")
        };

        public static PetKind ToPetKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cat")) return PetKind.Cat;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Dog")) return PetKind.Dog;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PetKind value.");
        }
    }
}
