// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents parameters for indexer execution. </summary>
    public partial class IndexingParameters
    {
        /// <summary> The number of items that are read from the data source and indexed as a single batch in order to improve performance. The default depends on the data source type. </summary>
        public int? BatchSize { get; set; }
        /// <summary> The maximum number of items that can fail indexing for indexer execution to still be considered successful. -1 means no limit. Default is 0. </summary>
        public int? MaxFailedItems { get; set; }
        /// <summary> The maximum number of items in a single batch that can fail indexing for the batch to still be considered successful. -1 means no limit. Default is 0. </summary>
        public int? MaxFailedItemsPerBatch { get; set; }
        /// <summary> Whether indexer will base64-encode all values that are inserted into key field of the target index. This is needed if keys can contain characters that are invalid in keys (such as dot &apos;.&apos;). Default is false. </summary>
        public bool? Base64EncodeKeys { get; set; }
        /// <summary> A dictionary of indexer-specific configuration properties. Each name is the name of a specific property. Each value must be of a primitive type. </summary>
        public IDictionary<string, object>? Configuration { get; set; }
    }
}
