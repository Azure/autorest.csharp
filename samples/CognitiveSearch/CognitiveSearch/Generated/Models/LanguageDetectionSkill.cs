// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> A skill that detects the language of input text and reports a single language code for every document submitted on the request. The language code is paired with a score indicating the confidence of the analysis. </summary>
    public partial class LanguageDetectionSkill : Skill
    {
        /// <summary> Initializes a new instance of LanguageDetectionSkill. </summary>
        public LanguageDetectionSkill()
        {
            OdataType = "#Microsoft.Skills.Text.LanguageDetectionSkill";
        }
    }
}
