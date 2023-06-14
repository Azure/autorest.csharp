// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtPropertyChooser.Models
{
    internal static partial class ResourceIdentityTypeExtensions
    {
        public static string ToSerialString(this ResourceIdentityType value) => value switch
        {
            ResourceIdentityType.None => "None",
            ResourceIdentityType.SystemAssigned => "SystemAssigned",
            ResourceIdentityType.UserAssigned => "UserAssigned",
            ResourceIdentityType.SystemAssignedUserAssigned => "SystemAssigned, UserAssigned",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ResourceIdentityType value.")
        };

        public static ResourceIdentityType ToResourceIdentityType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return ResourceIdentityType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SystemAssigned")) return ResourceIdentityType.SystemAssigned;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "UserAssigned")) return ResourceIdentityType.UserAssigned;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "SystemAssigned, UserAssigned")) return ResourceIdentityType.SystemAssignedUserAssigned;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ResourceIdentityType value.");
        }
    }
}
