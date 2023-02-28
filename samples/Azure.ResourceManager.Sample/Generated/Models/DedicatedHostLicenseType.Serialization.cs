// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class DedicatedHostLicenseTypeExtensions
    {
        public static string ToSerialString(this DedicatedHostLicenseType value) => value switch
        {
            DedicatedHostLicenseType.None => "None",
            DedicatedHostLicenseType.WindowsServerHybrid => "Windows_Server_Hybrid",
            DedicatedHostLicenseType.WindowsServerPerpetual => "Windows_Server_Perpetual",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DedicatedHostLicenseType value.")
        };

        public static DedicatedHostLicenseType ToDedicatedHostLicenseType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return DedicatedHostLicenseType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Windows_Server_Hybrid")) return DedicatedHostLicenseType.WindowsServerHybrid;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Windows_Server_Perpetual")) return DedicatedHostLicenseType.WindowsServerPerpetual;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DedicatedHostLicenseType value.");
        }
    }
}
