// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownTokenizer. </summary>
    internal partial class UnknownTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of UnknownTokenizer. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        internal UnknownTokenizer(string odataType, string name) : base(odataType, name)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
