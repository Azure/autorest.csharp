// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Abstract base class for tokenizers. </summary>
    public partial class Tokenizer
    {
        /// <summary> Initializes a new instance of Tokenizer. </summary>
        public Tokenizer()
        {
            OdataType = null;
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string OdataType { get; internal set; }
        /// <summary> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </summary>
        public string Name { get; set; }
    }
}
