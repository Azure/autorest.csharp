// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> Text extracted from a page in the input document. </summary>
    public partial class ReadResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ReadResult"/>. </summary>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height and boundingBox properties. For images, the unit is "pixel". For PDF, the unit is "inch". </param>
        internal ReadResult(int page, float angle, float width, float height, LengthUnit unit)
        {
            Page = page;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Lines = new ChangeTrackingList<TextLine>();
        }

        /// <summary> Initializes a new instance of <see cref="ReadResult"/>. </summary>
        /// <param name="page"> The 1-based page number in the input document. </param>
        /// <param name="angle"> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </param>
        /// <param name="width"> The width of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="height"> The height of the image/PDF in pixels/inches, respectively. </param>
        /// <param name="unit"> The unit used by the width, height and boundingBox properties. For images, the unit is "pixel". For PDF, the unit is "inch". </param>
        /// <param name="language"> The detected language on the page overall. </param>
        /// <param name="lines"> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ReadResult(int page, float angle, float width, float height, LengthUnit unit, Language? language, IReadOnlyList<TextLine> lines, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Page = page;
            Angle = angle;
            Width = width;
            Height = height;
            Unit = unit;
            Language = language;
            Lines = lines;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ReadResult"/> for deserialization. </summary>
        internal ReadResult()
        {
        }

        /// <summary> The 1-based page number in the input document. </summary>
        public int Page { get; }
        /// <summary> The general orientation of the text in clockwise direction, measured in degrees between (-180, 180]. </summary>
        public float Angle { get; }
        /// <summary> The width of the image/PDF in pixels/inches, respectively. </summary>
        public float Width { get; }
        /// <summary> The height of the image/PDF in pixels/inches, respectively. </summary>
        public float Height { get; }
        /// <summary> The unit used by the width, height and boundingBox properties. For images, the unit is "pixel". For PDF, the unit is "inch". </summary>
        public LengthUnit Unit { get; }
        /// <summary> The detected language on the page overall. </summary>
        public Language? Language { get; }
        /// <summary> When includeTextDetails is set to true, a list of recognized text lines. The maximum number of lines returned is 300 per page. The lines are sorted top to bottom, left to right, although in certain cases proximity is treated with higher priority. As the sorting order depends on the detected text, it may change across images and OCR version updates. Thus, business logic should be built upon the actual line location instead of order. </summary>
        public IReadOnlyList<TextLine> Lines { get; }
    }
}
