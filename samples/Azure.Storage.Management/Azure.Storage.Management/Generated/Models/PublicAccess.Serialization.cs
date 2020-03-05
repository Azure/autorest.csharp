// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.Storage.Management.Models
{
    internal static class PublicAccessExtensions
    {
        public static string ToSerialString(this PublicAccess value) => value switch
        {
            PublicAccess.Container => "Container",
            PublicAccess.Blob => "Blob",
            PublicAccess.None => "None",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PublicAccess value.")
        };

        public static PublicAccess ToPublicAccess(this string value) => value switch
        {
            "Container" => PublicAccess.Container,
            "Blob" => PublicAccess.Blob,
            "None" => PublicAccess.None,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown PublicAccess value.")
        };
    }
}
