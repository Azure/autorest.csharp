// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Salmon : Fish
    {
        /// <summary> Initializes a new instance of Salmon. </summary>
        public Salmon()
        {
            Fishtype = "salmon";
        }
        public string? Location { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Iswild { get; set; }
    }
}
