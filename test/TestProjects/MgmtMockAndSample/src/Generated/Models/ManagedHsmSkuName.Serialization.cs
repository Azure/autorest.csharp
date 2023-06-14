// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtMockAndSample.Models
{
    internal static partial class ManagedHsmSkuNameExtensions
    {
        public static string ToSerialString(this ManagedHsmSkuName value) => value switch
        {
            ManagedHsmSkuName.StandardB1 => "Standard_B1",
            ManagedHsmSkuName.CustomB32 => "Custom_B32",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ManagedHsmSkuName value.")
        };

        public static ManagedHsmSkuName ToManagedHsmSkuName(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Standard_B1")) return ManagedHsmSkuName.StandardB1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Custom_B32")) return ManagedHsmSkuName.CustomB32;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ManagedHsmSkuName value.");
        }
    }
}
