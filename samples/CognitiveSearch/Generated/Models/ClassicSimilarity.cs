// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Legacy similarity algorithm which uses the Lucene TFIDFSimilarity implementation of TF-IDF. This variation of TF-IDF introduces static document length normalization as well as coordinating factors that penalize documents that only partially match the searched queries. </summary>
    public partial class ClassicSimilarity : Similarity
    {
        /// <summary> Initializes a new instance of <see cref="ClassicSimilarity"/>. </summary>
        public ClassicSimilarity()
        {
            OdataType = "#Microsoft.Azure.Search.ClassicSimilarity";
        }

        /// <summary> Initializes a new instance of <see cref="ClassicSimilarity"/>. </summary>
        /// <param name="odataType"></param>
        internal ClassicSimilarity(string odataType) : base(odataType)
        {
            OdataType = odataType ?? "#Microsoft.Azure.Search.ClassicSimilarity";
        }
    }
}
