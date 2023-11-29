// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List SynonymMaps request. If successful, it includes the full definitions of all synonym maps. </summary>
    public partial class ListSynonymMapsResult
    {
        /// <summary> Initializes a new instance of <see cref="ListSynonymMapsResult"/>. </summary>
        /// <param name="synonymMaps"> The synonym maps in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="synonymMaps"/> is null. </exception>
        internal ListSynonymMapsResult(IEnumerable<SynonymMap> synonymMaps)
        {
            Argument.AssertNotNull(synonymMaps, nameof(synonymMaps));

            SynonymMaps = synonymMaps.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListSynonymMapsResult"/>. </summary>
        /// <param name="synonymMaps"> The synonym maps in the Search service. </param>
        internal ListSynonymMapsResult(IReadOnlyList<SynonymMap> synonymMaps)
        {
            SynonymMaps = synonymMaps;
        }

        /// <summary> The synonym maps in the Search service. </summary>
        public IReadOnlyList<SynonymMap> SynonymMaps { get; }
    }
}
