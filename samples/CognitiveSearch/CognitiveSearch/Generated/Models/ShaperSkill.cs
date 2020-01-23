// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> A skill for reshaping the outputs. It creates a complex type to support composite fields (also known as multipart fields). </summary>
    public partial class ShaperSkill : Skill
    {
        /// <summary> Initializes a new instance of ShaperSkill. </summary>
        public ShaperSkill()
        {
            OdataType = "#Microsoft.Skills.Util.ShaperSkill";
        }
    }
}
