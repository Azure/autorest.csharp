// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    internal static partial class CachingTypeExtensions
    {
        public static string ToSerialString(this CachingType value) => value switch
        {
            CachingType.None => "None",
            CachingType.ReadOnly => "ReadOnly",
            CachingType.ReadWrite => "ReadWrite",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CachingType value.")
        };

        public static CachingType ToCachingType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return CachingType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ReadOnly")) return CachingType.ReadOnly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ReadWrite")) return CachingType.ReadWrite;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CachingType value.");
        }
    }
}
