// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class RollingUpgradeActionTypeExtensions
    {
        public static string ToSerialString(this RollingUpgradeActionType value) => value switch
        {
            RollingUpgradeActionType.Start => "Start",
            RollingUpgradeActionType.Cancel => "Cancel",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeActionType value.")
        };

        public static RollingUpgradeActionType ToRollingUpgradeActionType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Start")) return RollingUpgradeActionType.Start;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cancel")) return RollingUpgradeActionType.Cancel;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown RollingUpgradeActionType value.");
        }
    }
}
