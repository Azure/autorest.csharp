// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class ParameterGroupingPostOptionalParameters
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ParameterGroupingPostOptionalParameters"/>. </summary>
        public ParameterGroupingPostOptionalParameters()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ParameterGroupingPostOptionalParameters"/>. </summary>
        /// <param name="customHeader"></param>
        /// <param name="query"> Query parameter with default. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ParameterGroupingPostOptionalParameters(string customHeader, int? query, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            CustomHeader = customHeader;
            Query = query;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the custom header. </summary>
        public string CustomHeader { get; set; }
        /// <summary> Query parameter with default. </summary>
        public int? Query { get; set; }
    }
}
