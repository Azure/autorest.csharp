// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class StorageSkuTierExtensions
    {
        public static string ToSerialString(this StorageSkuTier value) => value switch
        {
            StorageSkuTier.Standard => "Standard",
            StorageSkuTier.Premium => "Premium",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageSkuTier value.")
        };

        public static StorageSkuTier ToStorageSkuTier(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Standard")) return StorageSkuTier.Standard;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Premium")) return StorageSkuTier.Premium;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageSkuTier value.");
        }
    }
}
