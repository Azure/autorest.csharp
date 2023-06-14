// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a search index definition, which describes the fields and search behavior of an index. </summary>
    public partial class Index
    {
        /// <summary> Initializes a new instance of Index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="fields"/> is null. </exception>
        public Index(string name, IEnumerable<Field> fields)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(fields, nameof(fields));

            Name = name;
            Fields = fields.ToList();
            ScoringProfiles = new ChangeTrackingList<ScoringProfile>();
            Suggesters = new ChangeTrackingList<Suggester>();
            Analyzers = new ChangeTrackingList<Analyzer>();
            Tokenizers = new ChangeTrackingList<Tokenizer>();
            TokenFilters = new ChangeTrackingList<TokenFilter>();
            CharFilters = new ChangeTrackingList<CharFilter>();
        }

        /// <summary> Initializes a new instance of Index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="scoringProfiles"> The scoring profiles for the index. </param>
        /// <param name="defaultScoringProfile"> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the index. </param>
        /// <param name="suggesters"> The suggesters for the index. </param>
        /// <param name="analyzers">
        /// The analyzers for the index.
        /// Please note <see cref="Analyzer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CustomAnalyzer"/>, <see cref="PatternAnalyzer"/>, <see cref="StandardAnalyzer"/> and <see cref="StopAnalyzer"/>.
        /// </param>
        /// <param name="tokenizers">
        /// The tokenizers for the index.
        /// Please note <see cref="Tokenizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ClassicTokenizer"/>, <see cref="EdgeNGramTokenizer"/>, <see cref="KeywordTokenizer"/>, <see cref="KeywordTokenizerV2"/>, <see cref="MicrosoftLanguageStemmingTokenizer"/>, <see cref="MicrosoftLanguageTokenizer"/>, <see cref="NGramTokenizer"/>, <see cref="PathHierarchyTokenizerV2"/>, <see cref="PatternTokenizer"/>, <see cref="StandardTokenizer"/>, <see cref="StandardTokenizerV2"/> and <see cref="UaxUrlEmailTokenizer"/>.
        /// </param>
        /// <param name="tokenFilters">
        /// The token filters for the index.
        /// Please note <see cref="TokenFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AsciiFoldingTokenFilter"/>, <see cref="CjkBigramTokenFilter"/>, <see cref="CommonGramTokenFilter"/>, <see cref="DictionaryDecompounderTokenFilter"/>, <see cref="EdgeNGramTokenFilter"/>, <see cref="EdgeNGramTokenFilterV2"/>, <see cref="ElisionTokenFilter"/>, <see cref="KeepTokenFilter"/>, <see cref="KeywordMarkerTokenFilter"/>, <see cref="LengthTokenFilter"/>, <see cref="LimitTokenFilter"/>, <see cref="NGramTokenFilter"/>, <see cref="NGramTokenFilterV2"/>, <see cref="PatternCaptureTokenFilter"/>, <see cref="PatternReplaceTokenFilter"/>, <see cref="PhoneticTokenFilter"/>, <see cref="ShingleTokenFilter"/>, <see cref="SnowballTokenFilter"/>, <see cref="StemmerOverrideTokenFilter"/>, <see cref="StemmerTokenFilter"/>, <see cref="StopwordsTokenFilter"/>, <see cref="SynonymTokenFilter"/>, <see cref="TruncateTokenFilter"/>, <see cref="UniqueTokenFilter"/> and <see cref="WordDelimiterTokenFilter"/>.
        /// </param>
        /// <param name="charFilters">
        /// The character filters for the index.
        /// Please note <see cref="CharFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MappingCharFilter"/> and <see cref="PatternReplaceCharFilter"/>.
        /// </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data in Azure Cognitive Search. Once you have encrypted your data, it will always remain encrypted. Azure Cognitive Search will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="similarity">
        /// The type of similarity algorithm to be used when scoring and ranking the documents matching a search query. The similarity algorithm can only be defined at index creation time and cannot be modified on existing indexes. If null, the ClassicSimilarity algorithm is used.
        /// Please note <see cref="Similarity"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BM25Similarity"/> and <see cref="ClassicSimilarity"/>.
        /// </param>
        /// <param name="eTag"> The ETag of the index. </param>
        internal Index(string name, IList<Field> fields, IList<ScoringProfile> scoringProfiles, string defaultScoringProfile, CorsOptions corsOptions, IList<Suggester> suggesters, IList<Analyzer> analyzers, IList<Tokenizer> tokenizers, IList<TokenFilter> tokenFilters, IList<CharFilter> charFilters, EncryptionKey encryptionKey, Similarity similarity, string eTag)
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
            EncryptionKey = encryptionKey;
            Similarity = similarity;
            ETag = eTag;
        }

        /// <summary> The name of the index. </summary>
        public string Name { get; set; }
        /// <summary> The fields of the index. </summary>
        public IList<Field> Fields { get; }
        /// <summary> The scoring profiles for the index. </summary>
        public IList<ScoringProfile> ScoringProfiles { get; }
        /// <summary> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </summary>
        public string DefaultScoringProfile { get; set; }
        /// <summary> Options to control Cross-Origin Resource Sharing (CORS) for the index. </summary>
        public CorsOptions CorsOptions { get; set; }
        /// <summary> The suggesters for the index. </summary>
        public IList<Suggester> Suggesters { get; }
        /// <summary>
        /// The analyzers for the index.
        /// Please note <see cref="Analyzer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CustomAnalyzer"/>, <see cref="PatternAnalyzer"/>, <see cref="StandardAnalyzer"/> and <see cref="StopAnalyzer"/>.
        /// </summary>
        public IList<Analyzer> Analyzers { get; }
        /// <summary>
        /// The tokenizers for the index.
        /// Please note <see cref="Tokenizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ClassicTokenizer"/>, <see cref="EdgeNGramTokenizer"/>, <see cref="KeywordTokenizer"/>, <see cref="KeywordTokenizerV2"/>, <see cref="MicrosoftLanguageStemmingTokenizer"/>, <see cref="MicrosoftLanguageTokenizer"/>, <see cref="NGramTokenizer"/>, <see cref="PathHierarchyTokenizerV2"/>, <see cref="PatternTokenizer"/>, <see cref="StandardTokenizer"/>, <see cref="StandardTokenizerV2"/> and <see cref="UaxUrlEmailTokenizer"/>.
        /// </summary>
        public IList<Tokenizer> Tokenizers { get; }
        /// <summary>
        /// The token filters for the index.
        /// Please note <see cref="TokenFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AsciiFoldingTokenFilter"/>, <see cref="CjkBigramTokenFilter"/>, <see cref="CommonGramTokenFilter"/>, <see cref="DictionaryDecompounderTokenFilter"/>, <see cref="EdgeNGramTokenFilter"/>, <see cref="EdgeNGramTokenFilterV2"/>, <see cref="ElisionTokenFilter"/>, <see cref="KeepTokenFilter"/>, <see cref="KeywordMarkerTokenFilter"/>, <see cref="LengthTokenFilter"/>, <see cref="LimitTokenFilter"/>, <see cref="NGramTokenFilter"/>, <see cref="NGramTokenFilterV2"/>, <see cref="PatternCaptureTokenFilter"/>, <see cref="PatternReplaceTokenFilter"/>, <see cref="PhoneticTokenFilter"/>, <see cref="ShingleTokenFilter"/>, <see cref="SnowballTokenFilter"/>, <see cref="StemmerOverrideTokenFilter"/>, <see cref="StemmerTokenFilter"/>, <see cref="StopwordsTokenFilter"/>, <see cref="SynonymTokenFilter"/>, <see cref="TruncateTokenFilter"/>, <see cref="UniqueTokenFilter"/> and <see cref="WordDelimiterTokenFilter"/>.
        /// </summary>
        public IList<TokenFilter> TokenFilters { get; }
        /// <summary>
        /// The character filters for the index.
        /// Please note <see cref="CharFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MappingCharFilter"/> and <see cref="PatternReplaceCharFilter"/>.
        /// </summary>
        public IList<CharFilter> CharFilters { get; }
        /// <summary> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data in Azure Cognitive Search. Once you have encrypted your data, it will always remain encrypted. Azure Cognitive Search will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </summary>
        public EncryptionKey EncryptionKey { get; set; }
        /// <summary>
        /// The type of similarity algorithm to be used when scoring and ranking the documents matching a search query. The similarity algorithm can only be defined at index creation time and cannot be modified on existing indexes. If null, the ClassicSimilarity algorithm is used.
        /// Please note <see cref="Similarity"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BM25Similarity"/> and <see cref="ClassicSimilarity"/>.
        /// </summary>
        public Similarity Similarity { get; set; }
        /// <summary> The ETag of the index. </summary>
        public string ETag { get; set; }
    }
}
