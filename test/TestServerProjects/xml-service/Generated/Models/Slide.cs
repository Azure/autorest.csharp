// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> A slide in a slideshow. </summary>
    public partial class Slide
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.Slide
        ///
        /// </summary>
        public Slide()
        {
            Items = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// Initializes a new instance of global::xml_service.Models.Slide
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="items"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Slide(string type, string title, IList<string> items, Dictionary<string, BinaryData> rawData)
        {
            Type = type;
            Title = title;
            Items = items;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the type. </summary>
        public string Type { get; set; }
        /// <summary> Gets or sets the title. </summary>
        public string Title { get; set; }
        /// <summary> Gets the items. </summary>
        public IList<string> Items { get; }
    }
}
