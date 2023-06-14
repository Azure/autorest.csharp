// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models
{
    /// <summary> The SentenceSentiment. </summary>
    public partial class SentenceSentiment
    {
        /// <summary> Initializes a new instance of SentenceSentiment. </summary>
        /// <param name="text"> The sentence text. </param>
        /// <param name="sentiment"> The predicted Sentiment for the sentence. </param>
        /// <param name="confidenceScores"> The sentiment confidence score between 0 and 1 for the sentence for all classes. </param>
        /// <param name="offset"> The sentence offset from the start of the document. </param>
        /// <param name="length"> The length of the sentence by Unicode standard. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="confidenceScores"/> is null. </exception>
        internal SentenceSentiment(string text, SentenceSentimentValue sentiment, SentimentConfidenceScorePerLabel confidenceScores, int offset, int length)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(confidenceScores, nameof(confidenceScores));

            Text = text;
            Sentiment = sentiment;
            ConfidenceScores = confidenceScores;
            Offset = offset;
            Length = length;
        }

        /// <summary> The sentence text. </summary>
        public string Text { get; }
        /// <summary> The predicted Sentiment for the sentence. </summary>
        public SentenceSentimentValue Sentiment { get; }
        /// <summary> The sentiment confidence score between 0 and 1 for the sentence for all classes. </summary>
        public SentimentConfidenceScorePerLabel ConfidenceScores { get; }
        /// <summary> The sentence offset from the start of the document. </summary>
        public int Offset { get; }
        /// <summary> The length of the sentence by Unicode standard. </summary>
        public int Length { get; }
    }
}
