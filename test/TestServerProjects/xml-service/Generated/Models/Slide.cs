// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace xml_service.Models.V100
{
    /// <summary> A slide in a slideshow. </summary>
    public partial class Slide
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Type { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Title { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<string>? Items { get; set; }
    }
}
