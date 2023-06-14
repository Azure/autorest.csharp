// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A list of skills. </summary>
    public partial class Skillset
    {
        /// <summary> Initializes a new instance of Skillset. </summary>
        /// <param name="name"> The name of the skillset. </param>
        /// <param name="description"> The description of the skillset. </param>
        /// <param name="skills">
        /// A list of skills in the skillset.
        /// Please note <see cref="Skill"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="WebApiSkill"/>, <see cref="EntityRecognitionSkill"/>, <see cref="KeyPhraseExtractionSkill"/>, <see cref="LanguageDetectionSkill"/>, <see cref="MergeSkill"/>, <see cref="SentimentSkill"/>, <see cref="SplitSkill"/>, <see cref="TextTranslationSkill"/>, <see cref="ConditionalSkill"/>, <see cref="ShaperSkill"/>, <see cref="ImageAnalysisSkill"/> and <see cref="OcrSkill"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="description"/> or <paramref name="skills"/> is null. </exception>
        public Skillset(string name, string description, IEnumerable<Skill> skills)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(description, nameof(description));
            Argument.AssertNotNull(skills, nameof(skills));

            Name = name;
            Description = description;
            Skills = skills.ToList();
        }

        /// <summary> Initializes a new instance of Skillset. </summary>
        /// <param name="name"> The name of the skillset. </param>
        /// <param name="description"> The description of the skillset. </param>
        /// <param name="skills">
        /// A list of skills in the skillset.
        /// Please note <see cref="Skill"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="WebApiSkill"/>, <see cref="EntityRecognitionSkill"/>, <see cref="KeyPhraseExtractionSkill"/>, <see cref="LanguageDetectionSkill"/>, <see cref="MergeSkill"/>, <see cref="SentimentSkill"/>, <see cref="SplitSkill"/>, <see cref="TextTranslationSkill"/>, <see cref="ConditionalSkill"/>, <see cref="ShaperSkill"/>, <see cref="ImageAnalysisSkill"/> and <see cref="OcrSkill"/>.
        /// </param>
        /// <param name="cognitiveServicesAccount">
        /// Details about cognitive services to be used when running skills.
        /// Please note <see cref="CognitiveServicesAccount"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CognitiveServicesAccountKey"/> and <see cref="DefaultCognitiveServicesAccount"/>.
        /// </param>
        /// <param name="eTag"> The ETag of the skillset. </param>
        internal Skillset(string name, string description, IList<Skill> skills, CognitiveServicesAccount cognitiveServicesAccount, string eTag)
        {
            Name = name;
            Description = description;
            Skills = skills;
            CognitiveServicesAccount = cognitiveServicesAccount;
            ETag = eTag;
        }

        /// <summary> The name of the skillset. </summary>
        public string Name { get; set; }
        /// <summary> The description of the skillset. </summary>
        public string Description { get; set; }
        /// <summary>
        /// A list of skills in the skillset.
        /// Please note <see cref="Skill"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="WebApiSkill"/>, <see cref="EntityRecognitionSkill"/>, <see cref="KeyPhraseExtractionSkill"/>, <see cref="LanguageDetectionSkill"/>, <see cref="MergeSkill"/>, <see cref="SentimentSkill"/>, <see cref="SplitSkill"/>, <see cref="TextTranslationSkill"/>, <see cref="ConditionalSkill"/>, <see cref="ShaperSkill"/>, <see cref="ImageAnalysisSkill"/> and <see cref="OcrSkill"/>.
        /// </summary>
        public IList<Skill> Skills { get; }
        /// <summary>
        /// Details about cognitive services to be used when running skills.
        /// Please note <see cref="CognitiveServicesAccount"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CognitiveServicesAccountKey"/> and <see cref="DefaultCognitiveServicesAccount"/>.
        /// </summary>
        public CognitiveServicesAccount CognitiveServicesAccount { get; set; }
        /// <summary> The ETag of the skillset. </summary>
        public string ETag { get; set; }
    }
}
