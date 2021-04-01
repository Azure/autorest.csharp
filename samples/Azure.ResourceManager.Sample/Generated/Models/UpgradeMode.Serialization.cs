// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample
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
            if (string.Equals(value, "Automatic", StringComparison.InvariantCultureIgnoreCase)) return UpgradeMode.Automatic;
            if (string.Equals(value, "Manual", StringComparison.InvariantCultureIgnoreCase)) return UpgradeMode.Manual;
            if (string.Equals(value, "Rolling", StringComparison.InvariantCultureIgnoreCase)) return UpgradeMode.Rolling;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeMode value.");
        }
    }
}
