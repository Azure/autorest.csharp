// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    internal static partial class UpgradeOperationInvokerExtensions
    {
        public static string ToSerialString(this UpgradeOperationInvoker value) => value switch
        {
            UpgradeOperationInvoker.Unknown => "Unknown",
            UpgradeOperationInvoker.User => "User",
            UpgradeOperationInvoker.Platform => "Platform",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeOperationInvoker value.")
        };

        public static UpgradeOperationInvoker ToUpgradeOperationInvoker(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Unknown")) return UpgradeOperationInvoker.Unknown;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "User")) return UpgradeOperationInvoker.User;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Platform")) return UpgradeOperationInvoker.Platform;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown UpgradeOperationInvoker value.");
        }
    }
}
