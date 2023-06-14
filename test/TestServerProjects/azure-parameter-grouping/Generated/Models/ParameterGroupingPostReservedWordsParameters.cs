// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class ParameterGroupingPostReservedWordsParameters
    {
        /// <summary> Initializes a new instance of ParameterGroupingPostReservedWordsParameters. </summary>
        public ParameterGroupingPostReservedWordsParameters()
        {
        }

        /// <summary> 'from' is a reserved word. Pass in 'bob' to pass. </summary>
        public string From { get; set; }
        /// <summary> 'accept' is a reserved word. Pass in 'yes' to pass. </summary>
        public string Accept { get; set; }
    }
}
