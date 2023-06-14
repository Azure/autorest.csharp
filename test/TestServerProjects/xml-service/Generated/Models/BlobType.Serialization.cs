// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    internal static partial class BlobTypeExtensions
    {
        public static string ToSerialString(this BlobType value) => value switch
        {
            BlobType.BlockBlob => "BlockBlob",
            BlobType.PageBlob => "PageBlob",
            BlobType.AppendBlob => "AppendBlob",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BlobType value.")
        };

        public static BlobType ToBlobType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "BlockBlob")) return BlobType.BlockBlob;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "PageBlob")) return BlobType.PageBlob;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AppendBlob")) return BlobType.AppendBlob;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BlobType value.");
        }
    }
}
