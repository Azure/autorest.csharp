// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class PublicAccessExtensions
    {
        public static string ToSerialString(this PublicAccess value) => value switch
        {
            PublicAccess.None => "None",
            PublicAccess.Container => "Container",
            PublicAccess.Blob => "Blob",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PublicAccess value.")
        };

        public static PublicAccess ToPublicAccess(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "None")) return PublicAccess.None;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Container")) return PublicAccess.Container;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Blob")) return PublicAccess.Blob;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PublicAccess value.");
        }
    }
}
