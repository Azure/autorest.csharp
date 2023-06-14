// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace media_types.Models
{
    internal static partial class ContentType2Extensions
    {
        public static string ToSerialString(this ContentType2 value) => value switch
        {
            ContentType2.ApplicationJson => "application/json",
            ContentType2.ApplicationOctetStream => "application/octet-stream",
            ContentType2.TextPlain => "text/plain",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType2 value.")
        };

        public static ContentType2 ToContentType2(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/json")) return ContentType2.ApplicationJson;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/octet-stream")) return ContentType2.ApplicationOctetStream;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "text/plain")) return ContentType2.TextPlain;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType2 value.");
        }
    }
}
