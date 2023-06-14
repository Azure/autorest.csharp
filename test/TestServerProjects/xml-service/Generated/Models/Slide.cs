// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> A slide in a slideshow. </summary>
    public partial class Slide
    {
        /// <summary> Initializes a new instance of Slide. </summary>
        public Slide()
        {
            Items = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of Slide. </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="items"></param>
        internal Slide(string type, string title, IList<string> items)
        {
            Type = type;
            Title = title;
            Items = items;
        }

        /// <summary> Gets or sets the type. </summary>
        public string Type { get; set; }
        /// <summary> Gets or sets the title. </summary>
        public string Title { get; set; }
        /// <summary> Gets the items. </summary>
        public IList<string> Items { get; }
    }
}
