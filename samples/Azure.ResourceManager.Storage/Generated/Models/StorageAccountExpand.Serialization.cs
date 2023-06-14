// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class StorageAccountExpandExtensions
    {
        public static string ToSerialString(this StorageAccountExpand value) => value switch
        {
            StorageAccountExpand.GeoReplicationStats => "geoReplicationStats",
            StorageAccountExpand.BlobRestoreStatus => "blobRestoreStatus",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageAccountExpand value.")
        };

        public static StorageAccountExpand ToStorageAccountExpand(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "geoReplicationStats")) return StorageAccountExpand.GeoReplicationStats;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "blobRestoreStatus")) return StorageAccountExpand.BlobRestoreStatus;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown StorageAccountExpand value.");
        }
    }
}
