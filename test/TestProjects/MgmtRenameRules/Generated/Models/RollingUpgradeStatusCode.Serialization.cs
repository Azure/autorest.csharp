// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    internal static partial class RollingUpgradeStatusCodeExtensions
    {
        public static string ToSerialString(this RollingUpgradeStatusCode value) => value switch
        {
            RollingUpgradeStatusCode.RollingForward => "RollingForward",
            RollingUpgradeStatusCode.Cancelled => "Cancelled",
            RollingUpgradeStatusCode.Completed => "Completed",
            RollingUpgradeStatusCode.Faulted => "Faulted",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeStatusCode value.")
        };

        public static RollingUpgradeStatusCode ToRollingUpgradeStatusCode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "RollingForward")) return RollingUpgradeStatusCode.RollingForward;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cancelled")) return RollingUpgradeStatusCode.Cancelled;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Completed")) return RollingUpgradeStatusCode.Completed;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Faulted")) return RollingUpgradeStatusCode.Faulted;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeStatusCode value.");
        }
    }
}
