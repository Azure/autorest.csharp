// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a list Skillset request. If successful, it includes the full definitions of all skillsets. </summary>
    public partial class ListSkillsetsResult
    {
        /// <summary> The skillsets defined in the Search service. </summary>
        public ICollection<Skillset> Skillsets { get; internal set; }
    }
}
