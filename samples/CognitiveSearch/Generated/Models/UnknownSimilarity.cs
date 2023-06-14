// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> The UnknownSimilarity. </summary>
    internal partial class UnknownSimilarity : Similarity
    {
        /// <summary> Initializes a new instance of UnknownSimilarity. </summary>
        /// <param name="odataType"></param>
        internal UnknownSimilarity(string odataType) : base(odataType)
        {
            OdataType = odataType ?? "Unknown";
        }
    }
}
