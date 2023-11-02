// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary>
    /// Base type for skills.
    /// Please note <see cref="Skill"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="WebApiSkill"/>, <see cref="EntityRecognitionSkill"/>, <see cref="KeyPhraseExtractionSkill"/>, <see cref="LanguageDetectionSkill"/>, <see cref="MergeSkill"/>, <see cref="SentimentSkill"/>, <see cref="SplitSkill"/>, <see cref="TextTranslationSkill"/>, <see cref="ConditionalSkill"/>, <see cref="ShaperSkill"/>, <see cref="ImageAnalysisSkill"/> and <see cref="OcrSkill"/>.
    /// </summary>
    public partial class Skill
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Skill"/>. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> or <paramref name="outputs"/> is null. </exception>
        public Skill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));

            Inputs = inputs.ToList();
            Outputs = outputs.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="Skill"/>. </summary>
        /// <param name="odataType"> Identifies the concrete type of the skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Skill(string odataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            OdataType = odataType;
            Name = name;
            Description = description;
            Context = context;
            Inputs = inputs;
            Outputs = outputs;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Skill"/> for deserialization. </summary>
        internal Skill()
        {
        }

        /// <summary> Identifies the concrete type of the skill. </summary>
        internal string OdataType { get; set; }
        /// <summary> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </summary>
        public string Name { get; set; }
        /// <summary> The description of the skill which describes the inputs, outputs, and usage of the skill. </summary>
        public string Description { get; set; }
        /// <summary> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </summary>
        public string Context { get; set; }
        /// <summary> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </summary>
        public IList<InputFieldMappingEntry> Inputs { get; }
        /// <summary> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </summary>
        public IList<OutputFieldMappingEntry> Outputs { get; }
    }
}
