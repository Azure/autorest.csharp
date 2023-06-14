// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Specifies the syntax of the search query. The default is 'simple'. Use 'full' if your query uses the Lucene query syntax. </summary>
    public enum QueryType
    {
        /// <summary> simple. </summary>
        Simple,
        /// <summary> full. </summary>
        Full
    }
}
