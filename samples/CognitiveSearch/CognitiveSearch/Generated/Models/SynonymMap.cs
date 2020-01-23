// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Represents a synonym map definition. </summary>
    public partial class SynonymMap
    {
        /// <summary> The name of the synonym map. </summary>
        public string Name { get; set; }
        /// <summary> The format of the synonym map. Only the &apos;solr&apos; format is currently supported. </summary>
        public string Format { get; set; } = "solr";
        /// <summary> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </summary>
        public string Synonyms { get; set; }
        /// <summary> The ETag of the synonym map. </summary>
        public string? ETag { get; set; }
    }
}
