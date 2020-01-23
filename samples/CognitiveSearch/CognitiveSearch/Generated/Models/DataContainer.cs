// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Represents information about the entity (such as Azure SQL table or CosmosDB collection) that will be indexed. </summary>
    public partial class DataContainer
    {
        /// <summary> The name of the table or view (for Azure SQL data source) or collection (for CosmosDB data source) that will be indexed. </summary>
        public string Name { get; set; }
        /// <summary> A query that is applied to this data container. The syntax and meaning of this parameter is datasource-specific. Not supported by Azure SQL datasources. </summary>
        public string? Query { get; set; }
    }
}
