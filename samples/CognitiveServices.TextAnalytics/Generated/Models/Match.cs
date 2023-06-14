// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The Match. </summary>
    public partial class Match
    {
        /// <summary> Initializes a new instance of Match. </summary>
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
