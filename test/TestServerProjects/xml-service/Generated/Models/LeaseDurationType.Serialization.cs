// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    internal static partial class LeaseDurationTypeExtensions
    {
        public static string ToSerialString(this LeaseDurationType value) => value switch
        {
            LeaseDurationType.Infinite => "infinite",
            LeaseDurationType.Fixed => "fixed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseDurationType value.")
        };

        public static LeaseDurationType ToLeaseDurationType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "infinite")) return LeaseDurationType.Infinite;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "fixed")) return LeaseDurationType.Fixed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseDurationType value.");
        }
    }
}
