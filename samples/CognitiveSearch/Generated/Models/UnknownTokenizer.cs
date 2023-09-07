// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownTokenizer. </summary>
    internal partial class UnknownTokenizer : Tokenizer
    {
        /// <summary> Initializes a new instance of <see cref="UnknownTokenizer"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownTokenizer(string odataType, string name, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(odataType, name, serializedAdditionalRawData)
        {
            OdataType = odataType ?? "Unknown";
        }

        /// <summary> Initializes a new instance of <see cref="UnknownTokenizer"/> for deserialization. </summary>
        internal UnknownTokenizer()
        {
        }
    }
}
