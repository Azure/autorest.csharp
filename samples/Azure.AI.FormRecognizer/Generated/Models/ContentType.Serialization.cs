// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.FormRecognizer.Models
{
    internal static partial class ContentTypeExtensions
    {
        public static string ToSerialString(this ContentType value) => value switch
        {
            ContentType.ApplicationPdf => "application/pdf",
            ContentType.ImageJpeg => "image/jpeg",
            ContentType.ImagePng => "image/png",
            ContentType.ImageTiff => "image/tiff",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType value.")
        };

        public static ContentType ToContentType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/pdf")) return ContentType.ApplicationPdf;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "image/jpeg")) return ContentType.ImageJpeg;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "image/png")) return ContentType.ImagePng;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "image/tiff")) return ContentType.ImageTiff;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType value.");
        }
    }
}
