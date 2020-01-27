// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A skill that analyzes image files. It extracts a rich set of visual features based on the image content. </summary>
    public partial class ImageAnalysisSkill : Skill
    {
        /// <summary> Initializes a new instance of ImageAnalysisSkill. </summary>
        public ImageAnalysisSkill()
        {
            OdataType = "#Microsoft.Skills.Vision.ImageAnalysisSkill";
        }
        /// <summary> The language codes supported for input by ImageAnalysisSkill. </summary>
        public ImageAnalysisSkillLanguage? DefaultLanguageCode { get; set; }
        /// <summary> A list of visual features. </summary>
        public ICollection<VisualFeature> VisualFeatures { get; set; }
        /// <summary> A string indicating which domain-specific details to return. </summary>
        public ICollection<ImageDetail> Details { get; set; }
    }
}
