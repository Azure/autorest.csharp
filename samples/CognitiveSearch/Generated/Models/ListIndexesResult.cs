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
    /// <summary> Response from a List Indexes request. If successful, it includes the full definitions of all indexes. </summary>
    public partial class ListIndexesResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ListIndexesResult"/>. </summary>
        /// <param name="indexes"> The indexes in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexes"/> is null. </exception>
        internal ListIndexesResult(IEnumerable<Index> indexes)
        {
            Argument.AssertNotNull(indexes, nameof(indexes));

            Indexes = indexes.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListIndexesResult"/>. </summary>
        /// <param name="indexes"> The indexes in the Search service. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ListIndexesResult(IReadOnlyList<Index> indexes, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Indexes = indexes;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ListIndexesResult"/> for deserialization. </summary>
        internal ListIndexesResult()
        {
        }

        /// <summary> The indexes in the Search service. </summary>
        public IReadOnlyList<Index> Indexes { get; }
    }
}
