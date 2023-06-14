// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Response from a list Skillset request. If successful, it includes the full definitions of all skillsets. </summary>
    public partial class ListSkillsetsResult
    {
        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="skillsets"/> is null. </exception>
        internal ListSkillsetsResult(IEnumerable<Skillset> skillsets)
        {
            Argument.AssertNotNull(skillsets, nameof(skillsets));

            Skillsets = skillsets.ToList();
        }

        /// <summary> Initializes a new instance of ListSkillsetsResult. </summary>
        /// <param name="skillsets"> The skillsets defined in the Search service. </param>
        internal ListSkillsetsResult(IReadOnlyList<Skillset> skillsets)
        {
            Skillsets = skillsets;
        }

        /// <summary> The skillsets defined in the Search service. </summary>
        public IReadOnlyList<Skillset> Skillsets { get; }
    }
}
