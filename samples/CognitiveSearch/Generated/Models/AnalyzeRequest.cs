// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Specifies some text and analysis components used to break that text into tokens. </summary>
    public partial class AnalyzeRequest
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AnalyzeRequest"/>. </summary>
        /// <param name="text"> The text to break into tokens. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        public AnalyzeRequest(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
            TokenFilters = new ChangeTrackingList<TokenFilterName>();
            CharFilters = new ChangeTrackingList<CharFilterName>();
        }

        /// <summary> Initializes a new instance of <see cref="AnalyzeRequest"/>. </summary>
        /// <param name="text"> The text to break into tokens. </param>
        /// <param name="analyzer"> The name of the analyzer to use to break the given text. If this parameter is not specified, you must specify a tokenizer instead. The tokenizer and analyzer parameters are mutually exclusive. </param>
        /// <param name="tokenizer"> The name of the tokenizer to use to break the given text. If this parameter is not specified, you must specify an analyzer instead. The tokenizer and analyzer parameters are mutually exclusive. </param>
        /// <param name="tokenFilters"> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </param>
        /// <param name="charFilters"> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AnalyzeRequest(string text, AnalyzerName? analyzer, TokenizerName? tokenizer, IList<TokenFilterName> tokenFilters, IList<CharFilterName> charFilters, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Text = text;
            Analyzer = analyzer;
            Tokenizer = tokenizer;
            TokenFilters = tokenFilters;
            CharFilters = charFilters;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AnalyzeRequest"/> for deserialization. </summary>
        internal AnalyzeRequest()
        {
        }

        /// <summary> The text to break into tokens. </summary>
        public string Text { get; }
        /// <summary> The name of the analyzer to use to break the given text. If this parameter is not specified, you must specify a tokenizer instead. The tokenizer and analyzer parameters are mutually exclusive. </summary>
        public AnalyzerName? Analyzer { get; set; }
        /// <summary> The name of the tokenizer to use to break the given text. If this parameter is not specified, you must specify an analyzer instead. The tokenizer and analyzer parameters are mutually exclusive. </summary>
        public TokenizerName? Tokenizer { get; set; }
        /// <summary> An optional list of token filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public IList<TokenFilterName> TokenFilters { get; }
        /// <summary> An optional list of character filters to use when breaking the given text. This parameter can only be set when using the tokenizer parameter. </summary>
        public IList<CharFilterName> CharFilters { get; }
    }
}
