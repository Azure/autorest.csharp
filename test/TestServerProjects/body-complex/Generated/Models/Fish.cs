// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace body_complex.Models.V20160229
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        public Fish()
        {
            Fishtype = null;
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string Fishtype { get; internal set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Species { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-NUMBER. </summary>
        public float Length { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<Fish>? Siblings { get; set; }
    }
}
