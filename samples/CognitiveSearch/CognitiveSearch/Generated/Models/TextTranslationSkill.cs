// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

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

        /// <summary> Initializes a new instance of TextTranslationSkill. </summary>
        /// <param name="defaultToLanguageCode"> The language code to translate documents into for documents that don&apos;t specify the to language explicitly. </param>
        /// <param name="defaultFromLanguageCode"> The language code to translate documents from for documents that don&apos;t specify the from language explicitly. </param>
        /// <param name="suggestedFrom"> The language code to translate documents from when neither the fromLanguageCode input nor the defaultFromLanguageCode parameter are provided, and the automatic language detection is unsuccessful. Default is en. </param>
        /// <param name="odataType"> . </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character &apos;#&apos;. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        internal TextTranslationSkill(TextTranslationSkillLanguage defaultToLanguageCode, TextTranslationSkillLanguage? defaultFromLanguageCode, TextTranslationSkillLanguage? suggestedFrom, string odataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs) : base(odataType, name, description, context, inputs, outputs)
        {
            DefaultToLanguageCode = defaultToLanguageCode;
            DefaultFromLanguageCode = defaultFromLanguageCode;
            SuggestedFrom = suggestedFrom;
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
