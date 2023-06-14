// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtExpandResourceTypes.Models
{
    internal static partial class StorageTypeExtensions
    {
        public static StorageType ToStorageType(this int value)
        {
            if (value == 1) return StorageType.StandardLRS;
            if (value == 2) return StorageType.StandardZRS;
            if (value == 3) return StorageType.StandardGRS;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageType value.");
        }
    }
}
