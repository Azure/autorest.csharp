// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Text analytics entity recognition. </summary>
    public partial class EntityRecognitionSkill : Skill
    {
        /// <summary> Initializes a new instance of EntityRecognitionSkill. </summary>
        public EntityRecognitionSkill()
        {
            OdataType = "#Microsoft.Skills.Text.EntityRecognitionSkill";
        }
        /// <summary> A list of entity categories that should be extracted. </summary>
        public ICollection<EntityCategory>? Categories { get; set; }
        /// <summary> The language codes supported for input text by EntityRecognitionSkill. </summary>
        public EntityRecognitionSkillLanguage? DefaultLanguageCode { get; set; }
        /// <summary> Determines whether or not to include entities which are well known but don&apos;t conform to a pre-defined type. If this configuration is not set (default), set to null or set to false, entities which don&apos;t conform to one of the pre-defined types will not be surfaced. </summary>
        public bool? IncludeTypelessEntities { get; set; }
        /// <summary> A value between 0 and 1 that be used to only include entities whose confidence score is greater than the value specified. If not set (default), or if explicitly set to null, all entities will be included. </summary>
        public double? MinimumPrecision { get; set; }
    }
}
