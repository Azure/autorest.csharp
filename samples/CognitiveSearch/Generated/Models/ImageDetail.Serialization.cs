// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class ImageDetailExtensions
    {
        public static string ToSerialString(this ImageDetail value) => value switch
        {
            ImageDetail.Celebrities => "celebrities",
            ImageDetail.Landmarks => "landmarks",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ImageDetail value.")
        };

        public static ImageDetail ToImageDetail(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "celebrities")) return ImageDetail.Celebrities;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "landmarks")) return ImageDetail.Landmarks;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ImageDetail value.");
        }
    }
}
