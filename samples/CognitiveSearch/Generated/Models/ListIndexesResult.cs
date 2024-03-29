// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Indexes request. If successful, it includes the full definitions of all indexes. </summary>
    public partial class ListIndexesResult
    {
        /// <summary> Initializes a new instance of <see cref="ListIndexesResult"/>. </summary>
        /// <param name="indexes"> The indexes in the Search service. </param>
        internal ListIndexesResult(IEnumerable<Index> indexes)
        {
            Indexes = indexes.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListIndexesResult"/>. </summary>
        /// <param name="indexes"> The indexes in the Search service. </param>
        internal ListIndexesResult(IReadOnlyList<Index> indexes)
        {
            Indexes = indexes;
        }

        /// <summary> The indexes in the Search service. </summary>
        public IReadOnlyList<Index> Indexes { get; }
    }
}
