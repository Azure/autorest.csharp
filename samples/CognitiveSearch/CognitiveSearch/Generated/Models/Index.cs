// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a search index definition, which describes the fields and search behavior of an index. </summary>
    public partial class Index
    {
        /// <summary> Initializes a new instance of Index. </summary>
        public Index()
        {
        }

        /// <summary> Initializes a new instance of Index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="scoringProfiles"> The scoring profiles for the index. </param>
        /// <param name="defaultScoringProfile"> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the index. </param>
        /// <param name="suggesters"> The suggesters for the index. </param>
        /// <param name="analyzers"> The analyzers for the index. </param>
        /// <param name="tokenizers"> The tokenizers for the index. </param>
        /// <param name="tokenFilters"> The token filters for the index. </param>
        /// <param name="charFilters"> The character filters for the index. </param>
        /// <param name="eTag"> The ETag of the index. </param>
        internal Index(string name, IList<Field> fields, IList<ScoringProfile> scoringProfiles, string defaultScoringProfile, CorsOptions corsOptions, IList<Suggester> suggesters, IList<Analyzer> analyzers, IList<Tokenizer> tokenizers, IList<TokenFilter> tokenFilters, IList<CharFilter> charFilters, string eTag)
        {
            Name = name;
            Fields = fields;
            ScoringProfiles = scoringProfiles;
            DefaultScoringProfile = defaultScoringProfile;
            CorsOptions = corsOptions;
            Suggesters = suggesters;
            Analyzers = analyzers;
            Tokenizers = tokenizers;
            TokenFilters = tokenFilters;
            CharFilters = charFilters;
            ETag = eTag;
        }

        /// <summary> The name of the index. </summary>
        public string Name { get; set; }
        /// <summary> The fields of the index. </summary>
        public IList<Field> Fields { get; set; } = new List<Field>();
        /// <summary> The scoring profiles for the index. </summary>
        public IList<ScoringProfile> ScoringProfiles { get; set; }
        /// <summary> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </summary>
        public string DefaultScoringProfile { get; set; }
        /// <summary> Options to control Cross-Origin Resource Sharing (CORS) for the index. </summary>
        public CorsOptions CorsOptions { get; set; }
        /// <summary> The suggesters for the index. </summary>
        public IList<Suggester> Suggesters { get; set; }
        /// <summary> The analyzers for the index. </summary>
        public IList<Analyzer> Analyzers { get; set; }
        /// <summary> The tokenizers for the index. </summary>
        public IList<Tokenizer> Tokenizers { get; set; }
        /// <summary> The token filters for the index. </summary>
        public IList<TokenFilter> TokenFilters { get; set; }
        /// <summary> The character filters for the index. </summary>
        public IList<CharFilter> CharFilters { get; set; }
        /// <summary> The ETag of the index. </summary>
        public string ETag { get; set; }
    }
}
