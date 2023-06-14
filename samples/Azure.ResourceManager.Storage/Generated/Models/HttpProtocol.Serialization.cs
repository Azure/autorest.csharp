// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class HttpProtocolExtensions
    {
        public static string ToSerialString(this HttpProtocol value) => value switch
        {
            HttpProtocol.HttpsHttp => "https,http",
            HttpProtocol.Https => "https",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown HttpProtocol value.")
        };

        public static HttpProtocol ToHttpProtocol(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "https,http")) return HttpProtocol.HttpsHttp;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "https")) return HttpProtocol.Https;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown HttpProtocol value.");
        }
    }
}
