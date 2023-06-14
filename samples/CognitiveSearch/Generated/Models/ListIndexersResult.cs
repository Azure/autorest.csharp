// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Indexers request. If successful, it includes the full definitions of all indexers. </summary>
    public partial class ListIndexersResult
    {
        /// <summary> Initializes a new instance of ListIndexersResult. </summary>
        /// <param name="indexers"> The indexers in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexers"/> is null. </exception>
        internal ListIndexersResult(IEnumerable<Indexer> indexers)
        {
            Argument.AssertNotNull(indexers, nameof(indexers));

            Indexers = indexers.ToList();
        }

        /// <summary> Initializes a new instance of ListIndexersResult. </summary>
        /// <param name="indexers"> The indexers in the Search service. </param>
        internal ListIndexersResult(IReadOnlyList<Indexer> indexers)
        {
            Indexers = indexers;
        }

        /// <summary> The indexers in the Search service. </summary>
        public IReadOnlyList<Indexer> Indexers { get; }
    }
}
