// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Indexers request. If successful, it includes the full definitions of all indexers. </summary>
    public partial class ListIndexersResult
    {
        /// <summary> The indexers in the Search service. </summary>
        public ICollection<Indexer>? Indexers { get; internal set; }
    }
}
