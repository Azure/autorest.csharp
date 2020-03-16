// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents a synonym map definition. </summary>
    public partial class SynonymMap
    {
        /// <summary> Initializes a new instance of SynonymMap. </summary>
        internal SynonymMap()
        {
        }

        /// <summary> Initializes a new instance of SynonymMap. </summary>
        /// <param name="name"> The name of the synonym map. </param>
        /// <param name="format"> The format of the synonym map. Only the &apos;solr&apos; format is currently supported. </param>
        /// <param name="synonyms"> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </param>
        /// <param name="eTag"> The ETag of the synonym map. </param>
        internal SynonymMap(string name, string format, string synonyms, string eTag)
        {
            Name = name;
            Format = format;
            Synonyms = synonyms;
            ETag = eTag;
        }

        /// <summary> The name of the synonym map. </summary>
        public string Name { get; set; }
        /// <summary> The format of the synonym map. Only the &apos;solr&apos; format is currently supported. </summary>
        public string Format { get; set; } = "solr";
        /// <summary> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </summary>
        public string Synonyms { get; set; }
        /// <summary> The ETag of the synonym map. </summary>
        public string ETag { get; set; }
    }
}
