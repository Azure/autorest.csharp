// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace _Type.Model.Inheritance.Models
{
    internal static partial class SnakeKindExtensions
    {
        public static string ToSerialString(this SnakeKind value) => value switch
        {
            SnakeKind.Cobra => "cobra",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SnakeKind value.")
        };

        public static SnakeKind ToSnakeKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "cobra")) return SnakeKind.Cobra;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SnakeKind value.");
        }
    }
}
