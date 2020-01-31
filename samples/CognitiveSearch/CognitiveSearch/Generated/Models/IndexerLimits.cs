// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> The IndexerLimits. </summary>
    public partial class IndexerLimits
    {
        /// <summary> The maximum duration that the indexer is permitted to run for one execution. </summary>
        public TimeSpan? MaxRunTime { get; internal set; }
        /// <summary> The maximum size of a document, in bytes, which will be considered valid for indexing. </summary>
        public long? MaxDocumentExtractionSize { get; internal set; }
        /// <summary> The maximum number of characters that will be extracted from a document picked up for indexing. </summary>
        public long? MaxDocumentContentCharactersToExtract { get; internal set; }
    }
}
