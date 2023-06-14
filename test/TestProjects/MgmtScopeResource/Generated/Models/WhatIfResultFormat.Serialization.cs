// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtScopeResource.Models
{
    internal static partial class WhatIfResultFormatExtensions
    {
        public static string ToSerialString(this WhatIfResultFormat value) => value switch
        {
            WhatIfResultFormat.ResourceIdOnly => "ResourceIdOnly",
            WhatIfResultFormat.FullResourcePayloads => "FullResourcePayloads",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown WhatIfResultFormat value.")
        };

        public static WhatIfResultFormat ToWhatIfResultFormat(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "ResourceIdOnly")) return WhatIfResultFormat.ResourceIdOnly;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "FullResourcePayloads")) return WhatIfResultFormat.FullResourcePayloads;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown WhatIfResultFormat value.");
        }
    }
}
