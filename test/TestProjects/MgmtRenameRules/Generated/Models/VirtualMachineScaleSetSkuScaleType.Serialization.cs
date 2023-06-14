// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    internal static partial class VirtualMachineScaleSetSkuScaleTypeExtensions
    {
        public static string ToSerialString(this VirtualMachineScaleSetSkuScaleType value) => value switch
        {
            VirtualMachineScaleSetSkuScaleType.None => "None",
            VirtualMachineScaleSetSkuScaleType.Automatic => "Automatic",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VirtualMachineScaleSetSkuScaleType value.")
        };

        public static VirtualMachineScaleSetSkuScaleType ToVirtualMachineScaleSetSkuScaleType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return VirtualMachineScaleSetSkuScaleType.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Automatic")) return VirtualMachineScaleSetSkuScaleType.Automatic;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VirtualMachineScaleSetSkuScaleType value.");
        }
    }
}
