// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace CognitiveSearch.Models
{
    /// <summary> Defines the names of all tokenizers supported by Azure Cognitive Search. </summary>
    public readonly partial struct TokenizerName : IEquatable<TokenizerName>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="TokenizerName"/> values are the same. </summary>
        public TokenizerName(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ClassicValue = "classic";
        private const string EdgeNGramValue = "edgeNGram";
        private const string KeywordValue = "keyword_v2";
        private const string LetterValue = "letter";
        private const string LowercaseValue = "lowercase";
        private const string MicrosoftLanguageTokenizerValue = "microsoft_language_tokenizer";
        private const string MicrosoftLanguageStemmingTokenizerValue = "microsoft_language_stemming_tokenizer";
        private const string NGramValue = "nGram";
        private const string PathHierarchyValue = "path_hierarchy_v2";
        private const string PatternValue = "pattern";
        private const string StandardValue = "standard_v2";
        private const string UaxUrlEmailValue = "uax_url_email";
        private const string WhitespaceValue = "whitespace";

        /// <summary> Grammar-based tokenizer that is suitable for processing most European-language documents. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/ClassicTokenizer.html. </summary>
        public static TokenizerName Classic { get; } = new TokenizerName(ClassicValue);
        /// <summary> Tokenizes the input from an edge into n-grams of the given size(s). See https://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/EdgeNGramTokenizer.html. </summary>
        public static TokenizerName EdgeNGram { get; } = new TokenizerName(EdgeNGramValue);
        /// <summary> Emits the entire input as a single token. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordTokenizer.html. </summary>
        public static TokenizerName Keyword { get; } = new TokenizerName(KeywordValue);
        /// <summary> Divides text at non-letters. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/LetterTokenizer.html. </summary>
        public static TokenizerName Letter { get; } = new TokenizerName(LetterValue);
        /// <summary> Divides text at non-letters and converts them to lower case. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/LowerCaseTokenizer.html. </summary>
        public static TokenizerName Lowercase { get; } = new TokenizerName(LowercaseValue);
        /// <summary> Divides text using language-specific rules. </summary>
        public static TokenizerName MicrosoftLanguageTokenizer { get; } = new TokenizerName(MicrosoftLanguageTokenizerValue);
        /// <summary> Divides text using language-specific rules and reduces words to their base forms. </summary>
        public static TokenizerName MicrosoftLanguageStemmingTokenizer { get; } = new TokenizerName(MicrosoftLanguageStemmingTokenizerValue);
        /// <summary> Tokenizes the input into n-grams of the given size(s). See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/ngram/NGramTokenizer.html. </summary>
        public static TokenizerName NGram { get; } = new TokenizerName(NGramValue);
        /// <summary> Tokenizer for path-like hierarchies. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/path/PathHierarchyTokenizer.html. </summary>
        public static TokenizerName PathHierarchy { get; } = new TokenizerName(PathHierarchyValue);
        /// <summary> Tokenizer that uses regex pattern matching to construct distinct tokens. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/pattern/PatternTokenizer.html. </summary>
        public static TokenizerName Pattern { get; } = new TokenizerName(PatternValue);
        /// <summary> Standard Lucene analyzer; Composed of the standard tokenizer, lowercase filter and stop filter. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/StandardTokenizer.html. </summary>
        public static TokenizerName Standard { get; } = new TokenizerName(StandardValue);
        /// <summary> Tokenizes urls and emails as one token. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/standard/UAX29URLEmailTokenizer.html. </summary>
        public static TokenizerName UaxUrlEmail { get; } = new TokenizerName(UaxUrlEmailValue);
        /// <summary> Divides text at whitespace. See http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceTokenizer.html. </summary>
        public static TokenizerName Whitespace { get; } = new TokenizerName(WhitespaceValue);
        /// <summary> Determines if two <see cref="TokenizerName"/> values are the same. </summary>
        public static bool operator ==(TokenizerName left, TokenizerName right) => left.Equals(right);
        /// <summary> Determines if two <see cref="TokenizerName"/> values are not the same. </summary>
        public static bool operator !=(TokenizerName left, TokenizerName right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="TokenizerName"/>. </summary>
        public static implicit operator TokenizerName(string value) => new TokenizerName(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TokenizerName other && Equals(other);
        /// <inheritdoc />
        public bool Equals(TokenizerName other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
