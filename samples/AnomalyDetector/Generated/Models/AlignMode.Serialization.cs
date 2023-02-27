// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace AnomalyDetector.Models
{
    internal static partial class AlignModeExtensions
    {
        public static string ToSerialString(this AlignMode value) => value switch
        {
            AlignMode.Inner => "Inner",
            AlignMode.Outer => "Outer",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AlignMode value.")
        };

        public static AlignMode ToAlignMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Inner")) return AlignMode.Inner;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Outer")) return AlignMode.Outer;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AlignMode value.");
        }
    }
}
