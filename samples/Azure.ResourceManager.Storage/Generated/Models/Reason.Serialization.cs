// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    internal static partial class ReasonExtensions
    {
        public static string ToSerialString(this Reason value) => value switch
        {
            Reason.AccountNameInvalid => "AccountNameInvalid",
            Reason.AlreadyExists => "AlreadyExists",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Reason value.")
        };

        public static Reason ToReason(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AccountNameInvalid")) return Reason.AccountNameInvalid;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "AlreadyExists")) return Reason.AlreadyExists;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Reason value.");
        }
    }
}
