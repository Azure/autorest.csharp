// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> A skill for merging two or more strings into a single unified string, with an optional user-defined delimiter separating each component part. </summary>
    public partial class MergeSkill : Skill
    {
        /// <summary> Initializes a new instance of MergeSkill. </summary>
        public MergeSkill()
        {
            OdataType = "#Microsoft.Skills.Text.MergeSkill";
        }
        /// <summary> The tag indicates the start of the merged text. By default, the tag is an empty space. </summary>
        public string? InsertPreTag { get; set; }
        /// <summary> The tag indicates the end of the merged text. By default, the tag is an empty space. </summary>
        public string? InsertPostTag { get; set; }
    }
}
