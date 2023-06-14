// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> Data about a slideshow. </summary>
    public partial class Slideshow
    {
        /// <summary> Initializes a new instance of Slideshow. </summary>
        public Slideshow()
        {
            Slides = new ChangeTrackingList<Slide>();
        }

        /// <summary> Initializes a new instance of Slideshow. </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="author"></param>
        /// <param name="slides"></param>
        internal Slideshow(string title, string date, string author, IList<Slide> slides)
        {
            Title = title;
            Date = date;
            Author = author;
            Slides = slides;
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
