// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.Sample.Models
{
    internal static partial class CachingTypesExtensions
    {
        public static string ToSerialString(this CachingTypes value) => value switch
        {
            CachingTypes.ReadWrite => "ReadWrite",
            CachingTypes.ReadOnly => "ReadOnly",
            CachingTypes.None => "None",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CachingTypes value.")
        };

        public static CachingTypes ToCachingTypes(this string value)
        {
            if (string.Equals(value, "ReadWrite", StringComparison.InvariantCultureIgnoreCase)) return CachingTypes.ReadWrite;
            if (string.Equals(value, "ReadOnly", StringComparison.InvariantCultureIgnoreCase)) return CachingTypes.ReadOnly;
            if (string.Equals(value, "None", StringComparison.InvariantCultureIgnoreCase)) return CachingTypes.None;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CachingTypes value.");
        }
    }
}
