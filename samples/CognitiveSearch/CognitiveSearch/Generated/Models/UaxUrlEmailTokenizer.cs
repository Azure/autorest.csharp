// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    /// <summary> Tokenizes urls and emails as one token. This tokenizer is implemented using Apache Lucene. </summary>
    public partial class UaxUrlEmailTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of UaxUrlEmailTokenizer. </summary>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public UaxUrlEmailTokenizer(string name) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            OdataType = "#Microsoft.Azure.Search.UaxUrlEmailTokenizer";
        }

        /// <summary> Initializes a new instance of UaxUrlEmailTokenizer. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="maxTokenLength"> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </param>
        internal UaxUrlEmailTokenizer(string odataType, string name, int? maxTokenLength) : base(odataType, name)
        {
            MaxTokenLength = maxTokenLength;
            OdataType = odataType ?? "#Microsoft.Azure.Search.UaxUrlEmailTokenizer";
        }

        /// <summary> The maximum token length. Default is 255. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </summary>
        public int? MaxTokenLength { get; set; }
    }
}
