// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A skill to translate text from one language to another. </summary>
    public partial class TextTranslationSkill : Skill
    {
        /// <summary> Initializes a new instance of TextTranslationSkill. </summary>
        public TextTranslationSkill()
        {
            OdataType = "#Microsoft.Skills.Text.TranslationSkill";
        }
        /// <summary> The language codes supported for input text by TextTranslationSkill. </summary>
        public TextTranslationSkillLanguage DefaultToLanguageCode { get; set; }
        /// <summary> The language codes supported for input text by TextTranslationSkill. </summary>
        public TextTranslationSkillLanguage? DefaultFromLanguageCode { get; set; }
        /// <summary> The language codes supported for input text by TextTranslationSkill. </summary>
        public TextTranslationSkillLanguage? SuggestedFrom { get; set; }
    }
}
