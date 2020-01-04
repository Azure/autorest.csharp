// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    /// <summary> Data about a slideshow. </summary>
    public partial class Slideshow
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Title { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Date { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Author { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<Slide>? Slides { get; set; }
    }
}
