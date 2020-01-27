// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    internal static class BlobTypeExtensions
    {
        public static string ToSerialString(this BlobType value) => value switch
        {
            BlobType.BlockBlob => "BlockBlob",
            BlobType.PageBlob => "PageBlob",
            BlobType.AppendBlob => "AppendBlob",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BlobType value.")
        };

        public static BlobType ToBlobType(this string value) => value switch
        {
            "BlockBlob" => BlobType.BlockBlob,
            "PageBlob" => BlobType.PageBlob,
            "AppendBlob" => BlobType.AppendBlob,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown BlobType value.")
        };
    }
}
