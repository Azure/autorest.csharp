// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace ModelsTypeSpec.Models
{
    internal static partial class FixedIntEnumExtensions
    {
        public static FixedIntEnum ToFixedIntEnum(this int value)
        {
            if (value == 1) return FixedIntEnum.One;
            if (value == 2) return FixedIntEnum.Two;
            if (value == 4) return FixedIntEnum.Four;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FixedIntEnum value.");
        }
    }
}
