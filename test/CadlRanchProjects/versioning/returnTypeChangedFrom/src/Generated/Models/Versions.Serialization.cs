// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Versioning.ReturnTypeChangedFrom.Models
{
    internal static partial class VersionsExtensions
    {
        public static string ToSerialString(this Versions value) => value switch
        {
            Versions.V1 => "v1",
            Versions.V2 => "v2",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Versions value.")
        };

        public static Versions ToVersions(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "v1")) return Versions.V1;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "v2")) return Versions.V2;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Versions value.");
        }
    }
}
