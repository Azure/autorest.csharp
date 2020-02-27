// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace additionalProperties.Models
{
    /// <summary> The PetAPInProperties. </summary>
    public partial class PetAPInProperties
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; internal set; }
        /// <summary> Dictionary of &lt;number&gt;. </summary>
        public IDictionary<string, float> AdditionalProperties { get; set; }
    }
}
