// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for tokenizers.
    /// Please note <see cref="Tokenizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ClassicTokenizer"/>, <see cref="EdgeNGramTokenizer"/>, <see cref="KeywordTokenizer"/>, <see cref="KeywordTokenizerV2"/>, <see cref="MicrosoftLanguageStemmingTokenizer"/>, <see cref="MicrosoftLanguageTokenizer"/>, <see cref="NGramTokenizer"/>, <see cref="PathHierarchyTokenizerV2"/>, <see cref="PatternTokenizer"/>, <see cref="StandardTokenizer"/>, <see cref="StandardTokenizerV2"/> and <see cref="UaxUrlEmailTokenizer"/>.
    /// </summary>
    public partial class Tokenizer
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Tokenizer"/>. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Tokenizer(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="Tokenizer"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Tokenizer(string odataType, string name, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OdataType = odataType;
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Tokenizer"/> for deserialization. </summary>
        internal Tokenizer()
        {
        }

        /// <summary> Identifies the concrete type of the tokenizer. </summary>
        internal string OdataType { get; set; }
        /// <summary> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
