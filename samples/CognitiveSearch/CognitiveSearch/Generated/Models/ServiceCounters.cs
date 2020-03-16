// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents service-level resource counters and quotas. </summary>
    public partial class ServiceCounters
    {
        /// <summary> Initializes a new instance of ServiceCounters. </summary>
        internal ServiceCounters()
        {
        }

        /// <summary> Initializes a new instance of ServiceCounters. </summary>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        internal ServiceCounters(ResourceCounter documentCounter, ResourceCounter indexCounter, ResourceCounter indexerCounter, ResourceCounter dataSourceCounter, ResourceCounter storageSizeCounter, ResourceCounter synonymMapCounter)
        {
            DocumentCounter = documentCounter;
            IndexCounter = indexCounter;
            IndexerCounter = indexerCounter;
            DataSourceCounter = dataSourceCounter;
            StorageSizeCounter = storageSizeCounter;
            SynonymMapCounter = synonymMapCounter;
        }

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
