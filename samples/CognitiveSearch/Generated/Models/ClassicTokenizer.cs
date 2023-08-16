// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Grammar-based tokenizer that is suitable for processing most European-language documents. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class ClassicTokenizer : Tokenizer
    {
        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.ClassicTokenizer
        ///
        /// </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public ClassicTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.ClassicTokenizer";
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.ClassicTokenizer
        ///
        /// </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ClassicTokenizer(string odataType, string name, int? maxTokenLength, Dictionary<string, BinaryData> rawData) : base(odataType, name, rawData)
        {
            MaxTokenLength = maxTokenLength;
            OdataType = odataType ?? "#Microsoft.Azure.Search.ClassicTokenizer";
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
