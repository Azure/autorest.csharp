// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class MemoryTypeExtensions
    {
        public static MemoryType ToMemoryType(this long value)
        {
            if (value == -1L) return MemoryType._1;
            if (value == 2L) return MemoryType.Two;
            if (value == 4L) return MemoryType.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MemoryType value.");
        }
    }
}
