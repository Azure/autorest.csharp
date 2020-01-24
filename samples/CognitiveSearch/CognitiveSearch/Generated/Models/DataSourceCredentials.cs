// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents credentials that can be used to connect to a datasource. </summary>
    public partial class DataSourceCredentials
    {
        /// <summary> The connection string for the datasource. </summary>
        public string ConnectionString { get; set; }
    }
}
