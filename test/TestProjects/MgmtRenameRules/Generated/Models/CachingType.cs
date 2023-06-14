// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies the caching requirements. &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt; **None** &lt;br&gt;&lt;br&gt; **ReadOnly** &lt;br&gt;&lt;br&gt; **ReadWrite** &lt;br&gt;&lt;br&gt; Default: **None for Standard storage. ReadOnly for Premium storage**
    /// Serialized Name: CachingTypes
    /// </summary>
    public enum CachingType
    {
        /// <summary>
        /// None
        /// Serialized Name: CachingTypes.None
        /// </summary>
        None,
        /// <summary>
        /// ReadOnly
        /// Serialized Name: CachingTypes.ReadOnly
        /// </summary>
        ReadOnly,
        /// <summary>
        /// ReadWrite
        /// Serialized Name: CachingTypes.ReadWrite
        /// </summary>
        ReadWrite
    }
}
