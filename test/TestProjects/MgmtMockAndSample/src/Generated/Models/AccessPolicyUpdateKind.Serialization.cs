// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtMockAndSample.Models
{
    internal static partial class AccessPolicyUpdateKindExtensions
    {
        public static string ToSerialString(this AccessPolicyUpdateKind value) => value switch
        {
            AccessPolicyUpdateKind.Add => "add",
            AccessPolicyUpdateKind.Replace => "replace",
            AccessPolicyUpdateKind.Remove => "remove",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccessPolicyUpdateKind value.")
        };

        public static AccessPolicyUpdateKind ToAccessPolicyUpdateKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "add")) return AccessPolicyUpdateKind.Add;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "replace")) return AccessPolicyUpdateKind.Replace;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "remove")) return AccessPolicyUpdateKind.Remove;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccessPolicyUpdateKind value.");
        }
    }
}
