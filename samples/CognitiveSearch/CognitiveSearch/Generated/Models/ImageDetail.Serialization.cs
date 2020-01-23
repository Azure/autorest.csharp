// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    internal static class ImageDetailExtensions
    {
        public static string ToSerialString(this ImageDetail value) => value switch
        {
            ImageDetail.Celebrities => "celebrities",
            ImageDetail.Landmarks => "landmarks",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ImageDetail value.")
        };

        public static ImageDetail ToImageDetail(this string value) => value switch
        {
            "celebrities" => ImageDetail.Celebrities,
            "landmarks" => ImageDetail.Landmarks,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ImageDetail value.")
        };
    }
}
