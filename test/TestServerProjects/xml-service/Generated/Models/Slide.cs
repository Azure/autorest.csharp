// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace xml_service.Models
{
    /// <summary> A slide in a slideshow. </summary>
    public partial class Slide
    {
        public string Type { get; set; }
        public string Title { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<string> Items { get; set; }
    }
}
