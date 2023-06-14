// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> An object representing an extracted text line. </summary>
    public partial class TextLine
    {
        /// <summary> Initializes a new instance of TextLine. </summary>
        /// <param name="text"> The text content of the line. </param>
        /// <param name="boundingBox"> Bounding box of an extracted line. </param>
        /// <param name="words"> List of words in the text line. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/>, <paramref name="boundingBox"/> or <paramref name="words"/> is null. </exception>
        internal TextLine(string text, IEnumerable<float> boundingBox, IEnumerable<TextWord> words)
        {
            Argument.AssertNotNull(text, nameof(text));
            Argument.AssertNotNull(boundingBox, nameof(boundingBox));
            Argument.AssertNotNull(words, nameof(words));

            Text = text;
            BoundingBox = boundingBox.ToList();
            Words = words.ToList();
        }

        /// <summary> Initializes a new instance of TextLine. </summary>
        /// <param name="text"> The text content of the line. </param>
        /// <param name="boundingBox"> Bounding box of an extracted line. </param>
        /// <param name="language"> The detected language of this line, if different from the overall page language. </param>
        /// <param name="words"> List of words in the text line. </param>
        internal TextLine(string text, IReadOnlyList<float> boundingBox, Language? language, IReadOnlyList<TextWord> words)
        {
            Text = text;
            BoundingBox = boundingBox;
            Language = language;
            Words = words;
        }

        /// <summary> The text content of the line. </summary>
        public string Text { get; }
        /// <summary> Bounding box of an extracted line. </summary>
        public IReadOnlyList<float> BoundingBox { get; }
        /// <summary> The detected language of this line, if different from the overall page language. </summary>
        public Language? Language { get; }
        /// <summary> List of words in the text line. </summary>
        public IReadOnlyList<TextWord> Words { get; }
    }
}
