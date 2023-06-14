// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class DefaultActionExtensions
    {
        public static string ToSerialString(this DefaultAction value) => value switch
        {
            DefaultAction.Allow => "Allow",
            DefaultAction.Deny => "Deny",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DefaultAction value.")
        };

        public static DefaultAction ToDefaultAction(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Allow")) return DefaultAction.Allow;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Deny")) return DefaultAction.Deny;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown DefaultAction value.");
        }
    }
}
