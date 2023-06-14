// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtRenameRules.Models
{
    internal static partial class ProtocolTypeExtensions
    {
        public static string ToSerialString(this ProtocolType value) => value switch
        {
            ProtocolType.Http => "Http",
            ProtocolType.Https => "Https",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProtocolType value.")
        };

        public static ProtocolType ToProtocolType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Http")) return ProtocolType.Http;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Https")) return ProtocolType.Https;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ProtocolType value.");
        }
    }
}
