// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents service-level resource counters and quotas. </summary>
    public partial class ServiceCounters
    {
        /// <summary> Total number of documents across all indexes in the service. </summary>
        public ResourceCounter DocumentCounter { get; set; }
        /// <summary> Total number of indexes. </summary>
        public ResourceCounter IndexCounter { get; set; }
        /// <summary> Total number of indexers. </summary>
        public ResourceCounter IndexerCounter { get; set; }
        /// <summary> Total number of data sources. </summary>
        public ResourceCounter DataSourceCounter { get; set; }
        /// <summary> Total size of used storage in bytes. </summary>
        public ResourceCounter StorageSizeCounter { get; set; }
        /// <summary> Total number of synonym maps. </summary>
        public ResourceCounter SynonymMapCounter { get; set; }
    }
}
