// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownSimilarity. </summary>
    internal partial class UnknownSimilarity : Similarity
    {
        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.UnknownSimilarity
        ///
        /// </summary>
        /// <param name="odataType"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownSimilarity(string odataType, Dictionary<string, BinaryData> rawData) : base(odataType, rawData)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
