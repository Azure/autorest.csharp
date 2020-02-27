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
        /// <summary> The language code to translate documents into for documents that don&apos;t specify the to language explicitly. </summary>
        public TextTranslationSkillLanguage DefaultToLanguageCode { get; set; }
        /// <summary> The language code to translate documents from for documents that don&apos;t specify the from language explicitly. </summary>
        public TextTranslationSkillLanguage? DefaultFromLanguageCode { get; set; }
        /// <summary> The language code to translate documents from when neither the fromLanguageCode input nor the defaultFromLanguageCode parameter are provided, and the automatic language detection is unsuccessful. Default is en. </summary>
        public TextTranslationSkillLanguage? SuggestedFrom { get; set; }
    }
}
