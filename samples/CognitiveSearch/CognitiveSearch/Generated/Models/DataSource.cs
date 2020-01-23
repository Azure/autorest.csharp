// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Represents a datasource definition, which can be used to configure an indexer. </summary>
    public partial class DataSource
    {
        /// <summary> The name of the datasource. </summary>
        public string Name { get; set; }
        /// <summary> The description of the datasource. </summary>
        public string? Description { get; set; }
        /// <summary> Defines the type of a datasource. </summary>
        public DataSourceType Type { get; set; }
        /// <summary> Represents credentials that can be used to connect to a datasource. </summary>
        public DataSourceCredentials Credentials { get; set; } = new DataSourceCredentials();
        /// <summary> Represents information about the entity (such as Azure SQL table or CosmosDB collection) that will be indexed. </summary>
        public DataContainer Container { get; set; } = new DataContainer();
        /// <summary> Abstract base class for data change detection policies. </summary>
        public DataChangeDetectionPolicy? DataChangeDetectionPolicy { get; set; }
        /// <summary> Abstract base class for data deletion detection policies. </summary>
        public DataDeletionDetectionPolicy? DataDeletionDetectionPolicy { get; set; }
        /// <summary> The ETag of the DataSource. </summary>
        public string? ETag { get; set; }
    }
}
