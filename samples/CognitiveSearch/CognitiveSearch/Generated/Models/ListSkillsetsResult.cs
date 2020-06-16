// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a list Skillset request. If successful, it includes the full definitions of all skillsets. </summary>
    public partial class ListSkillsetsResult
    {
        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        internal ListSkillsetsResult(IEnumerable<Skillset> skillsets)
        {
            if (skillsets == null)
            {
                throw new ArgumentNullException(nameof(skillsets));
            }

            Skillsets = skillsets.ToArray();
        }

        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        internal ListSkillsetsResult(IReadOnlyList<Skillset> skillsets)
        {
            Skillsets = skillsets ?? new List<Skillset>();
        }

        /// <summary> The skillsets defined in the Search service. </summary>
        public IReadOnlyList<Skillset> Skillsets { get; }
    }
}
