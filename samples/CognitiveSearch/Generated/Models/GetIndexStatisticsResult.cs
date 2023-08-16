// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Statistics for a given index. Statistics are collected periodically and are not guaranteed to always be up-to-date. </summary>
    public partial class GetIndexStatisticsResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.GetIndexStatisticsResult
        ///
        /// </summary>
        /// <param name="documentCount"> The number of documents in the index. </param>
        /// <param name="storageSize"> The amount of storage in bytes consumed by the index. </param>
        internal GetIndexStatisticsResult(long documentCount, long storageSize)
        {
            DocumentCount = documentCount;
            StorageSize = storageSize;
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.GetIndexStatisticsResult
        ///
        /// </summary>
        /// <param name="documentCount"> The number of documents in the index. </param>
        /// <param name="storageSize"> The amount of storage in bytes consumed by the index. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal GetIndexStatisticsResult(long documentCount, long storageSize, Dictionary<string, BinaryData> rawData)
        {
            DocumentCount = documentCount;
            StorageSize = storageSize;
            _rawData = rawData;
        }

        /// <summary> The number of documents in the index. </summary>
        public long DocumentCount { get; }
        /// <summary> The amount of storage in bytes consumed by the index. </summary>
        public long StorageSize { get; }
    }
}
