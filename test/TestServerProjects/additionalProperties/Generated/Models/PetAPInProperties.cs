// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace additionalProperties.Models.V100
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class PetAPInProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int Id { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Name { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Status { get; internal set; }
        /// <summary> Dictionary of &lt;components·schemas·petapinproperties·properties·additionalproperties·additionalproperties&gt;. </summary>
        public IDictionary<string, float>? AdditionalProperties { get; set; }
    }
}
