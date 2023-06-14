// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtScopeResource.Models
{
    internal static partial class ChangeTypeExtensions
    {
        public static string ToSerialString(this ChangeType value) => value switch
        {
            ChangeType.Create => "Create",
            ChangeType.Delete => "Delete",
            ChangeType.Ignore => "Ignore",
            ChangeType.Deploy => "Deploy",
            ChangeType.NoChange => "NoChange",
            ChangeType.Modify => "Modify",
            ChangeType.Unsupported => "Unsupported",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChangeType value.")
        };

        public static ChangeType ToChangeType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Create")) return ChangeType.Create;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Delete")) return ChangeType.Delete;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Ignore")) return ChangeType.Ignore;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Deploy")) return ChangeType.Deploy;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "NoChange")) return ChangeType.NoChange;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Modify")) return ChangeType.Modify;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Unsupported")) return ChangeType.Unsupported;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown ChangeType value.");
        }
    }
}
