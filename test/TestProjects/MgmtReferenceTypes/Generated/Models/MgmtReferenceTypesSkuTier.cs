// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT. </summary>
    public enum MgmtReferenceTypesSkuTier
    {
        /// <summary> Free. </summary>
        Free,
        /// <summary> Basic. </summary>
        Basic,
        /// <summary> Standard. </summary>
        Standard,
        /// <summary> Premium. </summary>
        Premium
    }
}
