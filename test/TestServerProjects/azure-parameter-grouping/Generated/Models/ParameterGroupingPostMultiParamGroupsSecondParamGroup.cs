// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class ParameterGroupingPostMultiParamGroupsSecondParamGroup
    {
        /// <summary> Initializes a new instance of ParameterGroupingPostMultiParamGroupsSecondParamGroup. </summary>
        public ParameterGroupingPostMultiParamGroupsSecondParamGroup()
        {
        }

        /// <summary> Gets or sets the header two. </summary>
        public string HeaderTwo { get; set; }
        /// <summary> Query parameter with default. </summary>
        public int? QueryTwo { get; set; }
    }
}
