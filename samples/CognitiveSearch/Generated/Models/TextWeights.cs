// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines weights on index fields for which matches should boost scoring in search queries. </summary>
    public partial class TextWeights
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TextWeights"/>. </summary>
        /// <param name="weights"> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="weights"/> is null. </exception>
        public TextWeights(IDictionary<string, double> weights)
        {
            Argument.AssertNotNull(weights, nameof(weights));

            Weights = weights;
        }

        /// <summary> Initializes a new instance of <see cref="TextWeights"/>. </summary>
        /// <param name="weights"> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TextWeights(IDictionary<string, double> weights, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Weights = weights;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="TextWeights"/> for deserialization. </summary>
        internal TextWeights()
        {
        }

        /// <summary> The dictionary of per-field weights to boost document scoring. The keys are field names and the values are the weights for each field. </summary>
        public IDictionary<string, double> Weights { get; }
    }
}
