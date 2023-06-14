// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace media_types.Models
{
    internal static partial class ContentType1Extensions
    {
        public static string ToSerialString(this ContentType1 value) => value switch
        {
            ContentType1.ApplicationJson => "application/json",
            ContentType1.ApplicationOctetStream => "application/octet-stream",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType1 value.")
        };

        public static ContentType1 ToContentType1(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/json")) return ContentType1.ApplicationJson;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "application/octet-stream")) return ContentType1.ApplicationOctetStream;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ContentType1 value.");
        }
    }
}
