// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Datasources request. If successful, it includes the full definitions of all datasources. </summary>
    public partial class ListDataSourcesResult
    {
        /// <summary> Initializes a new instance of <see cref="ListDataSourcesResult"/>. </summary>
        /// <param name="dataSources"> The datasources in the Search service. </param>
        internal ListDataSourcesResult(IEnumerable<DataSource> dataSources)
        {
            DataSources = dataSources.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="ListDataSourcesResult"/>. </summary>
        /// <param name="dataSources"> The datasources in the Search service. </param>
        internal ListDataSourcesResult(IReadOnlyList<DataSource> dataSources)
        {
            DataSources = dataSources;
        }

        /// <summary> The datasources in the Search service. </summary>
        public IReadOnlyList<DataSource> DataSources { get; }
    }
}
