// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The Match. </summary>
    public partial class Match
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.Match
        ///
        /// </summary>
        /// <param name="confidenceScore"> If a well-known item is recognized, a decimal number denoting the confidence level between 0 and 1 will be returned. </param>
        /// <param name="text"> Entity text as appears in the request. </param>
        /// <param name="offset"> Start position (in Unicode characters) for the entity match text. </param>
        /// <param name="length"> Length (in Unicode characters) for the entity match text. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> is null. </exception>
        internal Match(double confidenceScore, string text, int offset, int length)
        {
            Argument.AssertNotNull(text, nameof(text));

            ConfidenceScore = confidenceScore;
            Text = text;
            Offset = offset;
            Length = length;
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveServices.TextAnalytics.Models.Match
        ///
        /// </summary>
        /// <param name="confidenceScore"> If a well-known item is recognized, a decimal number denoting the confidence level between 0 and 1 will be returned. </param>
        /// <param name="text"> Entity text as appears in the request. </param>
        /// <param name="offset"> Start position (in Unicode characters) for the entity match text. </param>
        /// <param name="length"> Length (in Unicode characters) for the entity match text. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Match(double confidenceScore, string text, int offset, int length, Dictionary<string, BinaryData> rawData)
        {
            ConfidenceScore = confidenceScore;
            Text = text;
            Offset = offset;
            Length = length;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Match"/> for deserialization. </summary>
        internal Match()
        {
        }

        /// <summary> If a well-known item is recognized, a decimal number denoting the confidence level between 0 and 1 will be returned. </summary>
        public double ConfidenceScore { get; }
        /// <summary> Entity text as appears in the request. </summary>
        public string Text { get; }
        /// <summary> Start position (in Unicode characters) for the entity match text. </summary>
        public int Offset { get; }
        /// <summary> Length (in Unicode characters) for the entity match text. </summary>
        public int Length { get; }
    }
}
