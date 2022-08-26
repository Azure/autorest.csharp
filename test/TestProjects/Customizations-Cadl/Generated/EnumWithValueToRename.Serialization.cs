// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CustomizationsInCadl
{
    internal static partial class EnumWithValueToRenameExtensions
    {
        public static string ToSerialString(this EnumWithValueToRename value) => value switch
        {
            EnumWithValueToRename.One => "1",
            EnumWithValueToRename.Two => "2",
            EnumWithValueToRename.ValueToRename => "3",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumWithValueToRename value.")
        };

        public static EnumWithValueToRename ToEnumWithValueToRename(this string value)
        {
            if (string.Equals(value, "1", StringComparison.InvariantCultureIgnoreCase)) return EnumWithValueToRename.One;
            if (string.Equals(value, "2", StringComparison.InvariantCultureIgnoreCase)) return EnumWithValueToRename.Two;
            if (string.Equals(value, "3", StringComparison.InvariantCultureIgnoreCase)) return EnumWithValueToRename.ValueToRename;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EnumWithValueToRename value.");
        }
    }
}
