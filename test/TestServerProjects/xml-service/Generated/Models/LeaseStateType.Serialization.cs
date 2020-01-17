// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models
{
    internal static class LeaseStateTypeExtensions
    {
        public static string ToSerialString(this LeaseStateType value) => value switch
        {
            LeaseStateType.Available => "available",
            LeaseStateType.Leased => "leased",
            LeaseStateType.Expired => "expired",
            LeaseStateType.Breaking => "breaking",
            LeaseStateType.Broken => "broken",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStateType value.")
        };

        public static LeaseStateType ToLeaseStateType(this string value) => value switch
        {
            "available" => LeaseStateType.Available,
            "leased" => LeaseStateType.Leased,
            "expired" => LeaseStateType.Expired,
            "breaking" => LeaseStateType.Breaking,
            "broken" => LeaseStateType.Broken,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown LeaseStateType value.")
        };
    }
}
