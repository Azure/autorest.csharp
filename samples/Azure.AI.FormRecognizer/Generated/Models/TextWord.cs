// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> An object representing a word. </summary>
    public partial class TextWord
    {
        /// <summary> Initializes a new instance of TextWord. </summary>
        /// <param name="text"> The text content of the word. </param>
        /// <param name="boundingBox"> Bounding box of an extracted word. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="boundingBox"/> is null. </exception>
        internal TextWord(string text, IEnumerable<float> boundingBox)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(boundingBox, nameof(boundingBox));

            Text = text;
            BoundingBox = boundingBox.ToList();
        }

        /// <summary> Initializes a new instance of TextWord. </summary>
        /// <param name="text"> The text content of the word. </param>
        /// <param name="boundingBox"> Bounding box of an extracted word. </param>
        /// <param name="confidence"> Confidence value. </param>
        internal TextWord(string text, IReadOnlyList<float> boundingBox, float? confidence)
        {
            Text = text;
            BoundingBox = boundingBox;
            Confidence = confidence;
        }

        /// <summary> The text content of the word. </summary>
        public string Text { get; }
        /// <summary> Bounding box of an extracted word. </summary>
        public IReadOnlyList<float> BoundingBox { get; }
        /// <summary> Confidence value. </summary>
        public float? Confidence { get; }
    }
}
