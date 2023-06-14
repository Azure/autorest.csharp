// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents an indexer. </summary>
    public partial class Indexer
    {
        /// <summary> Initializes a new instance of Indexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="dataSourceName"> The name of the datasource from which this indexer reads data. </param>
        /// <param name="targetIndexName"> The name of the index to which this indexer writes data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="dataSourceName"/> or <paramref name="targetIndexName"/> is null. </exception>
        public Indexer(string name, string dataSourceName, string targetIndexName)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(dataSourceName, nameof(dataSourceName));
            Argument.AssertNotNull(targetIndexName, nameof(targetIndexName));

            Name = name;
            DataSourceName = dataSourceName;
            TargetIndexName = targetIndexName;
            FieldMappings = new ChangeTrackingList<FieldMapping>();
            OutputFieldMappings = new ChangeTrackingList<FieldMapping>();
        }

        /// <summary> Initializes a new instance of Indexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="description"> The description of the indexer. </param>
        /// <param name="dataSourceName"> The name of the datasource from which this indexer reads data. </param>
        /// <param name="skillsetName"> The name of the skillset executing with this indexer. </param>
        /// <param name="targetIndexName"> The name of the index to which this indexer writes data. </param>
        /// <param name="schedule"> The schedule for this indexer. </param>
        /// <param name="parameters"> Parameters for indexer execution. </param>
        /// <param name="fieldMappings"> Defines mappings between fields in the data source and corresponding target fields in the index. </param>
        /// <param name="outputFieldMappings"> Output field mappings are applied after enrichment and immediately before indexing. </param>
        /// <param name="isDisabled"> A value indicating whether the indexer is disabled. Default is false. </param>
        /// <param name="eTag"> The ETag of the Indexer. </param>
        internal Indexer(string name, string description, string dataSourceName, string skillsetName, string targetIndexName, IndexingSchedule schedule, IndexingParameters parameters, IList<FieldMapping> fieldMappings, IList<FieldMapping> outputFieldMappings, bool? isDisabled, string eTag)
        {
            Name = name;
            Description = description;
            DataSourceName = dataSourceName;
            SkillsetName = skillsetName;
            TargetIndexName = targetIndexName;
            Schedule = schedule;
            Parameters = parameters;
            FieldMappings = fieldMappings;
            OutputFieldMappings = outputFieldMappings;
            IsDisabled = isDisabled;
            ETag = eTag;
        }

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
        /// <summary> The schedule for this indexer. </summary>
        public IndexingSchedule Schedule { get; set; }
        /// <summary> Parameters for indexer execution. </summary>
        public IndexingParameters Parameters { get; set; }
        /// <summary> Defines mappings between fields in the data source and corresponding target fields in the index. </summary>
        public IList<FieldMapping> FieldMappings { get; }
        /// <summary> Output field mappings are applied after enrichment and immediately before indexing. </summary>
        public IList<FieldMapping> OutputFieldMappings { get; }
        /// <summary> A value indicating whether the indexer is disabled. Default is false. </summary>
        public bool? IsDisabled { get; set; }
        /// <summary> The ETag of the Indexer. </summary>
        public string ETag { get; set; }
    }
}
