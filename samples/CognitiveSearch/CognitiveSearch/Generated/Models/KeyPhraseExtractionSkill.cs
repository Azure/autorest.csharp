// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A skill that uses text analytics for key phrase extraction. </summary>
    public partial class KeyPhraseExtractionSkill : Skill
    {
        /// <summary> Initializes a new instance of KeyPhraseExtractionSkill. </summary>
        public KeyPhraseExtractionSkill()
        {
            OdataType = "#Microsoft.Skills.Text.KeyPhraseExtractionSkill";
        }
        /// <summary> The language codes supported for input text by KeyPhraseExtractionSkill. </summary>
        public KeyPhraseExtractionSkillLanguage? DefaultLanguageCode { get; set; }
        /// <summary> A number indicating how many key phrases to return. If absent, all identified key phrases will be returned. </summary>
        public int? MaxKeyPhraseCount { get; set; }
    }
}
