// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        public Fish()
        {
            Fishtype = null;
        }
        public string Fishtype { get; internal set; }
        public string Species { get; set; }
        public float Length { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<Fish> Siblings { get; set; }
    }
}
