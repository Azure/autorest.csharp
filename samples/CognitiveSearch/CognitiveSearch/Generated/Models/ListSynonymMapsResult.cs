// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List SynonymMaps request. If successful, it includes the full definitions of all synonym maps. </summary>
    public partial class ListSynonymMapsResult
    {
        /// <summary> The synonym maps in the Search service. </summary>
        public ICollection<SynonymMap>? SynonymMaps { get; internal set; }
    }
}
