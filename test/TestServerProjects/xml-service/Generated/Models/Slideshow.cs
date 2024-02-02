// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> Data about a slideshow. </summary>
    public partial class Slideshow
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Slideshow"/>. </summary>
        public Slideshow()
        {
            Slides = new ChangeTrackingList<Slide>();
        }

        /// <summary> Initializes a new instance of <see cref="Slideshow"/>. </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="author"></param>
        /// <param name="slides"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Slideshow(string title, string date, string author, IList<Slide> slides, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Title = title;
            Date = date;
            Author = author;
            Slides = slides;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the title. </summary>
        public string Title { get; set; }
        /// <summary> Gets or sets the date. </summary>
        public string Date { get; set; }
        /// <summary> Gets or sets the author. </summary>
        public string Author { get; set; }
        /// <summary> Gets the slides. </summary>
        public IList<Slide> Slides { get; }
    }
}
