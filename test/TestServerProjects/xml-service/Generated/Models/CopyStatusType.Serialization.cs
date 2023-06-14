// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    internal static partial class CopyStatusTypeExtensions
    {
        public static string ToSerialString(this CopyStatusType value) => value switch
        {
            CopyStatusType.Pending => "pending",
            CopyStatusType.Success => "success",
            CopyStatusType.Aborted => "aborted",
            CopyStatusType.Failed => "failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopyStatusType value.")
        };

        public static CopyStatusType ToCopyStatusType(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "pending")) return CopyStatusType.Pending;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "success")) return CopyStatusType.Success;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "aborted")) return CopyStatusType.Aborted;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "failed")) return CopyStatusType.Failed;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopyStatusType value.");
        }
    }
}
