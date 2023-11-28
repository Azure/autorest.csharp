// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Allows you to take control over the process of converting text into indexable/searchable tokens. It's a user-defined configuration consisting of a single predefined tokenizer and one or more filters. The tokenizer is responsible for breaking text into tokens, and the filters for modifying tokens emitted by the tokenizer. </summary>
    public partial class CustomAnalyzer : Analyzer
    {
        /// <summary> Initializes a new instance of <see cref="CustomAnalyzer"/>. </summary>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="tokenizer"> The name of the tokenizer to use to divide continuous text into a sequence of tokens, such as breaking a sentence into words. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public CustomAnalyzer(string name, TokenizerName tokenizer) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Tokenizer = tokenizer;
            TokenFilters = new ChangeTrackingList<TokenFilterName>();
            CharFilters = new ChangeTrackingList<CharFilterName>();
            OdataType = "#Microsoft.Azure.Search.CustomAnalyzer";
        }

        /// <summary> Initializes a new instance of <see cref="CustomAnalyzer"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="tokenizer"> The name of the tokenizer to use to divide continuous text into a sequence of tokens, such as breaking a sentence into words. </param>
        /// <param name="tokenFilters"> A list of token filters used to filter out or modify the tokens generated by a tokenizer. For example, you can specify a lowercase filter that converts all characters to lowercase. The filters are run in the order in which they are listed. </param>
        /// <param name="charFilters"> A list of character filters used to prepare input text before it is processed by the tokenizer. For instance, they can replace certain characters or symbols. The filters are run in the order in which they are listed. </param>
        internal CustomAnalyzer(string odataType, string name, TokenizerName tokenizer, IList<TokenFilterName> tokenFilters, IList<CharFilterName> charFilters) : base(odataType, name)
        {
            Tokenizer = tokenizer;
            TokenFilters = tokenFilters;
            CharFilters = charFilters;
            OdataType = odataType ?? "#Microsoft.Azure.Search.CustomAnalyzer";
        }

        /// <summary> The name of the tokenizer to use to divide continuous text into a sequence of tokens, such as breaking a sentence into words. </summary>
        public TokenizerName Tokenizer { get; set; }
        /// <summary> A list of token filters used to filter out or modify the tokens generated by a tokenizer. For example, you can specify a lowercase filter that converts all characters to lowercase. The filters are run in the order in which they are listed. </summary>
        public IList<TokenFilterName> TokenFilters { get; }
        /// <summary> A list of character filters used to prepare input text before it is processed by the tokenizer. For instance, they can replace certain characters or symbols. The filters are run in the order in which they are listed. </summary>
        public IList<CharFilterName> CharFilters { get; }
    }
}
