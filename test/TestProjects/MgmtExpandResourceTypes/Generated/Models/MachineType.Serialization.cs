// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class MachineTypeExtensions
    {
        public static MachineType ToMachineType(this int value)
        {
            if (value == 1) return MachineType.One;
            if (value == 2) return MachineType.Two;
            if (value == 4) return MachineType.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MachineType value.");
        }
    }
}
