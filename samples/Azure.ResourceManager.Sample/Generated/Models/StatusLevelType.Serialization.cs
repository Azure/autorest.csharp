// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class StatusLevelTypeExtensions
    {
        public static string ToSerialString(this StatusLevelType value) => value switch
        {
            StatusLevelType.Info => "Info",
            StatusLevelType.Warning => "Warning",
            StatusLevelType.Error => "Error",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StatusLevelType value.")
        };

        public static StatusLevelType ToStatusLevelType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Info")) return StatusLevelType.Info;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Warning")) return StatusLevelType.Warning;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Error")) return StatusLevelType.Error;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StatusLevelType value.");
        }
    }
}
