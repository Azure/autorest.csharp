// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A skill to split a string into chunks of text. </summary>
    public partial class SplitSkill : Skill
    {
        /// <summary> Initializes a new instance of SplitSkill. </summary>
        public SplitSkill()
        {
            OdataType = "#Microsoft.Skills.Text.SplitSkill";
        }
        /// <summary> The language codes supported for input text by SplitSkill. </summary>
        public SplitSkillLanguage? DefaultLanguageCode { get; set; }
        /// <summary> A value indicating which split mode to perform. </summary>
        public TextSplitMode? TextSplitMode { get; set; }
        /// <summary> The desired maximum page length. Default is 10000. </summary>
        public int? MaximumPageLength { get; set; }
    }
}
