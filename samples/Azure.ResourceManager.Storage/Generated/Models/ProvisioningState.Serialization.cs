// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class ProvisioningStateExtensions
    {
        public static string ToSerialString(this ProvisioningState value) => value switch
        {
            ProvisioningState.Creating => "Creating",
            ProvisioningState.ResolvingDNS => "ResolvingDNS",
            ProvisioningState.Succeeded => "Succeeded",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProvisioningState value.")
        };

        public static ProvisioningState ToProvisioningState(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Creating")) return ProvisioningState.Creating;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ResolvingDNS")) return ProvisioningState.ResolvingDNS;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Succeeded")) return ProvisioningState.Succeeded;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProvisioningState value.");
        }
    }
}
