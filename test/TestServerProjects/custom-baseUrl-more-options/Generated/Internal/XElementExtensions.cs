// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Xml.Linq;

namespace custom_baseUrl_more_options
{
    internal static class XElementExtensions
    {
        public static byte[] GetBytesFromBase64Value(this XElement element, string format) => format switch
        {
            "U" => TypeFormatters.FromBase64UrlString(element.Value),
            "D" => Convert.FromBase64String(element.Value),
            _ => throw new ArgumentException($"Format is not supported: '{format}'", nameof(format))
        };

        public static DateTimeOffset GetDateTimeOffsetValue(this XElement element, string format) => format switch
        {
            "U" => DateTimeOffset.FromUnixTimeSeconds((long)element),
            _ => TypeFormatters.ParseDateTimeOffset(element.Value, format)
        };

        public static TimeSpan GetTimeSpanValue(this XElement element, string format) => TypeFormatters.ParseTimeSpan(element.Value, format);
    }
}
