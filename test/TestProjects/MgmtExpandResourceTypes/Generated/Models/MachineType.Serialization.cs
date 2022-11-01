// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class MachineTypeExtensions
    {
        public static int ToSerialInt32(this MachineType value) => value switch
        {
            MachineType.One => 1,
            MachineType.Two => 2,
            MachineType.Four => 4,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MachineType value.")
        };

        public static MachineType ToMachineType(this int value)
        {
            if (Equals(value, 1)) return MachineType.One;
            if (Equals(value, 2)) return MachineType.Two;
            if (Equals(value, 4)) return MachineType.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MachineType value.");
        }
    }
}
