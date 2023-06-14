// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Breaks text following the Unicode Text Segmentation rules. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class StandardTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of StandardTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public StandardTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            OdataType = "#Microsoft.Azure.Search.StandardTokenizer";
        }

        /// <summary> Initializes a new instance of StandardTokenizer. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. </param>
        internal StandardTokenizer(string odataType, string name, int? maxTokenLength) : base(odataType, name)
        {
            MaxTokenLength = maxTokenLength;
            OdataType = odataType ?? "#Microsoft.Azure.Search.StandardTokenizer";
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
