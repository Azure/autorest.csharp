// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Provides parameter values to a tag scoring function. </summary>
    public partial class TagScoringParameters
    {
        /// <summary> The name of the parameter passed in search queries to specify the list of tags to compare against the target field. </summary>
        public string TagsParameter { get; set; }
    }
}
