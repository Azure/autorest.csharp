// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A list of skills. </summary>
    public partial class Skillset
    {
        /// <summary> The name of the skillset. </summary>
        public string Name { get; set; }
        /// <summary> The description of the skillset. </summary>
        public string Description { get; set; }
        /// <summary> A list of skills in the skillset. </summary>
        public ICollection<Skill> Skills { get; set; } = new System.Collections.Generic.List<CognitiveSearch.Models.Skill>();
        /// <summary> Details about cognitive services to be used when running skills. </summary>
        public CognitiveServicesAccount CognitiveServicesAccount { get; set; }
        /// <summary> The ETag of the skillset. </summary>
        public string ETag { get; set; }
    }
}
