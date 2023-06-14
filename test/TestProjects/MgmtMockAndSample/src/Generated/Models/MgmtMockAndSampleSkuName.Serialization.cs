// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtMockAndSample.Models
{
    internal static partial class MgmtMockAndSampleSkuNameExtensions
    {
        public static string ToSerialString(this MgmtMockAndSampleSkuName value) => value switch
        {
            MgmtMockAndSampleSkuName.Standard => "standard",
            MgmtMockAndSampleSkuName.Premium => "premium",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MgmtMockAndSampleSkuName value.")
        };

        public static MgmtMockAndSampleSkuName ToMgmtMockAndSampleSkuName(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "standard")) return MgmtMockAndSampleSkuName.Standard;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "premium")) return MgmtMockAndSampleSkuName.Premium;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MgmtMockAndSampleSkuName value.");
        }
    }
}
