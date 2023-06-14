// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> The StorageType. </summary>
    public enum StorageType
    {
        /// <summary> Locally redundant storage. </summary>
        StandardLRS = 1,
        /// <summary> Zone-redundant storage. </summary>
        StandardZRS = 2,
        /// <summary> Geo-redundant storage. </summary>
        StandardGRS = 3
    }
}
