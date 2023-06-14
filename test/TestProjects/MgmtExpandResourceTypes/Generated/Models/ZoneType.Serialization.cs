// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class ZoneTypeExtensions
    {
        public static string ToSerialString(this ZoneType value) => value switch
        {
            ZoneType.Public => "Public",
            ZoneType.Private => "Private",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ZoneType value.")
        };

        public static ZoneType ToZoneType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Public")) return ZoneType.Public;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Private")) return ZoneType.Private;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ZoneType value.");
        }
    }
}
