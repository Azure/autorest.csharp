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
    /// <summary> Response from a List Indexers request. If successful, it includes the full definitions of all indexers. </summary>
    public partial class ListIndexersResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ListIndexersResult"/>. </summary>
        /// <param name="indexers"> The indexers in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexers"/> is null. </exception>
        internal ListIndexersResult(IEnumerable<Indexer> indexers)
        {
            Argument.AssertNotNull(indexers, nameof(indexers));

            Indexers = indexers.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListIndexersResult"/>. </summary>
        /// <param name="indexers"> The indexers in the Search service. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ListIndexersResult(IReadOnlyList<Indexer> indexers, Dictionary<string, BinaryData> rawData)
        {
            Indexers = indexers;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListIndexersResult"/> for deserialization. </summary>
        internal ListIndexersResult()
        {
        }

        /// <summary> The indexers in the Search service. </summary>
        public IReadOnlyList<Indexer> Indexers { get; }
    }
}
