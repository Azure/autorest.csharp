// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A skill to split a string into chunks of text. </summary>
    public partial class SplitSkill : Skill
    {
        /// <summary> Initializes a new instance of <see cref="SplitSkill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        public SplitSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            OdataType = "#Microsoft.Skills.Text.SplitSkill";
        }

        /// <summary> Initializes a new instance of <see cref="SplitSkill"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="defaultLanguageCode"> A value indicating which language code to use. Default is en. </param>
        /// <param name="textSplitMode"> A value indicating which split mode to perform. </param>
        /// <param name="maximumPageLength"> The desired maximum page length. Default is 10000. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SplitSkill(string odataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, SplitSkillLanguage? defaultLanguageCode, TextSplitMode? textSplitMode, int? maximumPageLength, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(odataType, name, description, context, inputs, outputs, serializedAdditionalRawData)
        {
            DefaultLanguageCode = defaultLanguageCode;
            TextSplitMode = textSplitMode;
            MaximumPageLength = maximumPageLength;
            OdataType = odataType ?? "#Microsoft.Skills.Text.SplitSkill";
        }

        /// <summary> Initializes a new instance of <see cref="SplitSkill"/> for deserialization. </summary>
        internal SplitSkill()
        {
        }

        /// <summary> A value indicating which language code to use. Default is en. </summary>
        public SplitSkillLanguage? DefaultLanguageCode { get; set; }
        /// <summary> A value indicating which split mode to perform. </summary>
        public TextSplitMode? TextSplitMode { get; set; }
        /// <summary> The desired maximum page length. Default is 10000. </summary>
        public int? MaximumPageLength { get; set; }
    }
}
