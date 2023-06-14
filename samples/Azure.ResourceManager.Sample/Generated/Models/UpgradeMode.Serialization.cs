// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class UpgradeModeExtensions
    {
        public static string ToSerialString(this UpgradeMode value) => value switch
        {
            UpgradeMode.Automatic => "Automatic",
            UpgradeMode.Manual => "Manual",
            UpgradeMode.Rolling => "Rolling",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeMode value.")
        };

        public static UpgradeMode ToUpgradeMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Automatic")) return UpgradeMode.Automatic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Manual")) return UpgradeMode.Manual;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Rolling")) return UpgradeMode.Rolling;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeMode value.");
        }
    }
}
