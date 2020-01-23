// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a List Datasources request. If successful, it includes the full definitions of all datasources. </summary>
    public partial class ListDataSourcesResult
    {
        /// <summary> The datasources in the Search service. </summary>
        public ICollection<DataSource>? DataSources { get; internal set; }
    }
}
