// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class FirstParameterGroup
    {
        /// <summary> Initializes a new instance of FirstParameterGroup. </summary>
        public FirstParameterGroup()
        {
        }

        /// <summary> Gets or sets the header one. </summary>
        public string HeaderOne { get; set; }
        /// <summary> Query parameter with default. </summary>
        public int? QueryOne { get; set; }
    }
}
