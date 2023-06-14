// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Fake.Models
{
    internal static partial class MgmtReferenceTypesSkuTierExtensions
    {
        public static string ToSerialString(this MgmtReferenceTypesSkuTier value) => value switch
        {
            MgmtReferenceTypesSkuTier.Free => "Free",
            MgmtReferenceTypesSkuTier.Basic => "Basic",
            MgmtReferenceTypesSkuTier.Standard => "Standard",
            MgmtReferenceTypesSkuTier.Premium => "Premium",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MgmtReferenceTypesSkuTier value.")
        };

        public static MgmtReferenceTypesSkuTier ToMgmtReferenceTypesSkuTier(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Free")) return MgmtReferenceTypesSkuTier.Free;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Basic")) return MgmtReferenceTypesSkuTier.Basic;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Standard")) return MgmtReferenceTypesSkuTier.Standard;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "Premium")) return MgmtReferenceTypesSkuTier.Premium;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown MgmtReferenceTypesSkuTier value.");
        }
    }
}
