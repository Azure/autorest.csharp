// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents an indexer. </summary>
    public partial class Indexer
    {
        /// <summary> The name of the indexer. </summary>
        public string Name { get; set; }
        /// <summary> The description of the indexer. </summary>
        public string Description { get; set; }
        /// <summary> The name of the datasource from which this indexer reads data. </summary>
        public string DataSourceName { get; set; }
        /// <summary> The name of the skillset executing with this indexer. </summary>
        public string SkillsetName { get; set; }
        /// <summary> The name of the index to which this indexer writes data. </summary>
        public string TargetIndexName { get; set; }
        /// <summary> Represents a schedule for indexer execution. </summary>
        public IndexingSchedule Schedule { get; set; }
        /// <summary> Represents parameters for indexer execution. </summary>
        public IndexingParameters Parameters { get; set; }
        /// <summary> Defines mappings between fields in the data source and corresponding target fields in the index. </summary>
        public ICollection<FieldMapping> FieldMappings { get; set; }
        /// <summary> Output field mappings are applied after enrichment and immediately before indexing. </summary>
        public ICollection<FieldMapping> OutputFieldMappings { get; set; }
        /// <summary> A value indicating whether the indexer is disabled. Default is false. </summary>
        public bool? IsDisabled { get; set; }
        /// <summary> The ETag of the Indexer. </summary>
        public string ETag { get; set; }
    }
}
