// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace additionalProperties.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class PetAPInProperties
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-BOOLEAN. </summary>
        public bool? Status { get; internal set; }
        /// <summary> Dictionary of &lt;components·schemas·petapinproperties·properties·additionalproperties·additionalproperties&gt;. </summary>
        public IDictionary<string, float> AdditionalProperties { get; set; }
    }
}
