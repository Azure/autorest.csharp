// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models
{
    internal static class CopyStatusTypeExtensions
    {
        public static string ToSerialString(this CopyStatusType value) => value switch
        {
            CopyStatusType.Pending => "pending",
            CopyStatusType.Success => "success",
            CopyStatusType.Aborted => "aborted",
            CopyStatusType.Failed => "failed",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopyStatusType value.")
        };

        public static CopyStatusType ToCopyStatusType(this string value) => value switch
        {
            "pending" => CopyStatusType.Pending,
            "success" => CopyStatusType.Success,
            "aborted" => CopyStatusType.Aborted,
            "failed" => CopyStatusType.Failed,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopyStatusType value.")
        };
    }
}
