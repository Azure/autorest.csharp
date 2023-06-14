// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class AccessTierExtensions
    {
        public static string ToSerialString(this AccessTier value) => value switch
        {
            AccessTier.Hot => "Hot",
            AccessTier.Cool => "Cool",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccessTier value.")
        };

        public static AccessTier ToAccessTier(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Hot")) return AccessTier.Hot;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Cool")) return AccessTier.Cool;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccessTier value.");
        }
    }
}
