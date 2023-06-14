// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Gets the unit of measurement. </summary>
    public enum UsageUnit
    {
        /// <summary> Count. </summary>
        Count,
        /// <summary> Bytes. </summary>
        Bytes,
        /// <summary> Seconds. </summary>
        Seconds,
        /// <summary> Percent. </summary>
        Percent,
        /// <summary> CountsPerSecond. </summary>
        CountsPerSecond,
        /// <summary> BytesPerSecond. </summary>
        BytesPerSecond
    }
}
