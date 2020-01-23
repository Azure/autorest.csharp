// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Indexes request. If successful, it includes the full definitions of all indexes. </summary>
    public partial class ListIndexesResult
    {
        /// <summary> The indexes in the Search service. </summary>
        public ICollection<Index>? Indexes { get; internal set; }
    }
}
