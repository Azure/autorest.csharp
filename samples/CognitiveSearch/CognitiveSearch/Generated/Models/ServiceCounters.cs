// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Represents service-level resource counters and quotas. </summary>
    public partial class ServiceCounters
    {
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? DocumentCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? IndexCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? IndexerCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? DataSourceCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? StorageSizeCounter { get; set; }
        /// <summary> Represents a resource&apos;s usage and quota. </summary>
        public ResourceCounter? SynonymMapCounter { get; set; }
    }
}
