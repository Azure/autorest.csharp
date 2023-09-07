// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class ParameterGroupingPostMultiParamGroupsSecondParamGroup
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ParameterGroupingPostMultiParamGroupsSecondParamGroup"/>. </summary>
        public ParameterGroupingPostMultiParamGroupsSecondParamGroup()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ParameterGroupingPostMultiParamGroupsSecondParamGroup"/>. </summary>
        /// <param name="headerTwo"></param>
        /// <param name="queryTwo"> Query parameter with default. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ParameterGroupingPostMultiParamGroupsSecondParamGroup(string headerTwo, int? queryTwo, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            HeaderTwo = headerTwo;
            QueryTwo = queryTwo;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the header two. </summary>
        public string HeaderTwo { get; set; }
        /// <summary> Query parameter with default. </summary>
        public int? QueryTwo { get; set; }
    }
}
