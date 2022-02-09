// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class UpgradeStateExtensions
    {
        public static string ToSerialString(this UpgradeState value) => value switch
        {
            UpgradeState.Faulted => "Faulted",
            UpgradeState.Completed => "Completed",
            UpgradeState.Cancelled => "Cancelled",
            UpgradeState.RollingForward => "RollingForward",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeState value.")
        };

        public static UpgradeState ToUpgradeState(this string value)
        {
            if (string.Equals(value, "Faulted", StringComparison.InvariantCultureIgnoreCase)) return UpgradeState.Faulted;
            if (string.Equals(value, "Completed", StringComparison.InvariantCultureIgnoreCase)) return UpgradeState.Completed;
            if (string.Equals(value, "Cancelled", StringComparison.InvariantCultureIgnoreCase)) return UpgradeState.Cancelled;
            if (string.Equals(value, "RollingForward", StringComparison.InvariantCultureIgnoreCase)) return UpgradeState.RollingForward;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeState value.");
        }
    }
}
