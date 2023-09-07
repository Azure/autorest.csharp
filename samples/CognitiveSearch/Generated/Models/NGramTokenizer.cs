// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes the input into n-grams of the given size(s). This tokenizer is implemented using Apache Lucene. </summary>
    public partial class NGramTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of <see cref="NGramTokenizer"/>. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public NGramTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            TokenChars = new ChangeTrackingList<TokenCharacterKind>();
            OdataType = "#Microsoft.Azure.Search.NGramTokenizer";
        }

        /// <summary> Initializes a new instance of <see cref="NGramTokenizer"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="minGram"> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </param>
        /// <param name="maxGram"> The maximum n-gram length. Default is 2. Maximum is 300. </param>
        /// <param name="tokenChars"> Character classes to keep in the tokens. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NGramTokenizer(string odataType, string name, int? minGram, int? maxGram, IList<TokenCharacterKind> tokenChars, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(odataType, name, serializedAdditionalRawData)
        {
            MinGram = minGram;
            MaxGram = maxGram;
            TokenChars = tokenChars;
            OdataType = odataType ?? "#Microsoft.Azure.Search.NGramTokenizer";
        }

        /// <summary> Initializes a new instance of <see cref="NGramTokenizer"/> for deserialization. </summary>
        internal NGramTokenizer()
        {
        }

        /// <summary> The minimum n-gram length. Default is 1. Maximum is 300. Must be less than the value of maxGram. </summary>
        public int? MinGram { get; set; }
        /// <summary> The maximum n-gram length. Default is 2. Maximum is 300. </summary>
        public int? MaxGram { get; set; }
        /// <summary> Character classes to keep in the tokens. </summary>
        public IList<TokenCharacterKind> TokenChars { get; }
    }
}
