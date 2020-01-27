// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace xml_service.Models
{
    internal static class LeaseStatusTypeExtensions
    {
        public static string ToSerialString(this LeaseStatusType value) => value switch
        {
            LeaseStatusType.Locked => "locked",
            LeaseStatusType.Unlocked => "unlocked",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStatusType value.")
        };

        public static LeaseStatusType ToLeaseStatusType(this string value) => value switch
        {
            "locked" => LeaseStatusType.Locked,
            "unlocked" => LeaseStatusType.Unlocked,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStatusType value.")
        };
    }
}
