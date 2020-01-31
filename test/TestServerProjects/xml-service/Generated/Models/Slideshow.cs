// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> Data about a slideshow. </summary>
    public partial class Slideshow
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Author { get; set; }
        public ICollection<Slide> Slides { get; set; }
    }
}
