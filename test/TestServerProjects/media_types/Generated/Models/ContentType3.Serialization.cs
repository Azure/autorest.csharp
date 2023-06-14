// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace media_types.Models
{
    internal static partial class ContentType3Extensions
    {
        public static string ToSerialString(this ContentType3 value) => value switch
        {
            ContentType3.ApplicationJson => "application/json",
            ContentType3.TextPlain => "text/plain",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType3 value.")
        };

        public static ContentType3 ToContentType3(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/json")) return ContentType3.ApplicationJson;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "text/plain")) return ContentType3.TextPlain;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType3 value.");
        }
    }
}
