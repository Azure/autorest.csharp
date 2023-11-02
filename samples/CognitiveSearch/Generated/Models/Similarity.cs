// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for similarity algorithms. Similarity algorithms are used to calculate scores that tie queries to documents. The higher the score, the more relevant the document is to that specific query. Those scores are used to rank the search results.
    /// Please note <see cref="Similarity"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="BM25Similarity"/> and <see cref="ClassicSimilarity"/>.
    /// </summary>
    public partial class Similarity
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Similarity"/>. </summary>
        public Similarity()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Similarity"/>. </summary>
        /// <param name="odataType"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Similarity(string odataType, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OdataType = odataType;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the odata type. </summary>
        internal string OdataType { get; set; }
    }
}
