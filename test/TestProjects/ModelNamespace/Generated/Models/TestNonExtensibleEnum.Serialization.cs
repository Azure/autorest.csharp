// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ModelNamespace
{
    internal static partial class TestNonExtensibleEnumExtensions
    {
        public static string ToSerialString(this TestNonExtensibleEnum value) => value switch
        {
            TestNonExtensibleEnum.A => "A",
            TestNonExtensibleEnum.B => "B",
            TestNonExtensibleEnum.C => "C",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TestNonExtensibleEnum value.")
        };

        public static TestNonExtensibleEnum ToTestNonExtensibleEnum(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "A")) return TestNonExtensibleEnum.A;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "B")) return TestNonExtensibleEnum.B;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "C")) return TestNonExtensibleEnum.C;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TestNonExtensibleEnum value.");
        }
    }
}
