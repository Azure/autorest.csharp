// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    public partial class Slideshow
    {
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? Author { get; set; }
        public ICollection<Slide>? Slides { get; set; }
    }
}
