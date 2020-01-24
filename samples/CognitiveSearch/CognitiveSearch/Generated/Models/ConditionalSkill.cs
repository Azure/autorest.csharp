// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A skill that enables scenarios that require a Boolean operation to determine the data to assign to an output. </summary>
    public partial class ConditionalSkill : Skill
    {
        /// <summary> Initializes a new instance of ConditionalSkill. </summary>
        public ConditionalSkill()
        {
            OdataType = "#Microsoft.Skills.Util.ConditionalSkill";
        }
    }
}
