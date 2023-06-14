// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class AccountStatusExtensions
    {
        public static string ToSerialString(this AccountStatus value) => value switch
        {
            AccountStatus.Available => "available",
            AccountStatus.Unavailable => "unavailable",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccountStatus value.")
        };

        public static AccountStatus ToAccountStatus(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "available")) return AccountStatus.Available;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "unavailable")) return AccountStatus.Unavailable;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown AccountStatus value.");
        }
    }
}
