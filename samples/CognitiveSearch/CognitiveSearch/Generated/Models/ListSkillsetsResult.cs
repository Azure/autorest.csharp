// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a list Skillset request. If successful, it includes the full definitions of all skillsets. </summary>
    public partial class ListSkillsetsResult
    {
        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        internal ListSkillsetsResult()
        {
        }
        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        internal ListSkillsetsResult(IList<Skillset> skillsets)
        {
            Skillsets = skillsets;
        }
        /// <summary> The skillsets defined in the Search service. </summary>
        public IList<Skillset> Skillsets { get; internal set; }
    }
}
