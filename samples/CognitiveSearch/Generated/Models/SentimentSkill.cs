// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Text analytics positive-negative sentiment analysis, scored as a floating point value in a range of zero to 1. </summary>
    public partial class SentimentSkill : Skill
    {
        /// <summary> Initializes a new instance of <see cref="SentimentSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        public SentimentSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            OdataType = "#Microsoft.Skills.Text.SentimentSkill";
        }

        /// <summary> Initializes a new instance of <see cref="SentimentSkill"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="defaultLanguageCode"> A value indicating which language code to use. Default is en. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SentimentSkill(string odataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, SentimentSkillLanguage? defaultLanguageCode, Dictionary<string, BinaryData> rawData) : base(odataType, name, description, context, inputs, outputs, rawData)
        {
            DefaultLanguageCode = defaultLanguageCode;
            OdataType = odataType ?? "#Microsoft.Skills.Text.SentimentSkill";
        }

        /// <summary> Initializes a new instance of <see cref="SentimentSkill"/> for deserialization. </summary>
        internal SentimentSkill()
        {
        }

        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public SentimentSkillLanguage? DefaultLanguageCode { get; set; }
    }
}
