// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class UpgradeStateExtensions
    {
        public static string ToSerialString(this UpgradeState value) => value switch
        {
            UpgradeState.RollingForward => "RollingForward",
            UpgradeState.Cancelled => "Cancelled",
            UpgradeState.Completed => "Completed",
            UpgradeState.Faulted => "Faulted",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeState value.")
        };

        public static UpgradeState ToUpgradeState(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RollingForward")) return UpgradeState.RollingForward;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cancelled")) return UpgradeState.Cancelled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Completed")) return UpgradeState.Completed;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Faulted")) return UpgradeState.Faulted;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeState value.");
        }
    }
}
