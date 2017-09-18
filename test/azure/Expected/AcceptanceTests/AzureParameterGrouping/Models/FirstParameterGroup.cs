// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureParameterGrouping.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Additional parameters for a set of operations, such as:
    /// ParameterGrouping_PostMultiParamGroups,
    /// ParameterGrouping_PostSharedParameterGroupObject.
    /// </summary>
    public partial class FirstParameterGroup
    {
        /// <summary>
        /// Initializes a new instance of the FirstParameterGroup class.
        /// </summary>
        public FirstParameterGroup()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FirstParameterGroup class.
        /// </summary>
        /// <param name="queryOne">Query parameter with default</param>
        public FirstParameterGroup(string headerOne = default(string), int? queryOne = default(int?))
        {
            HeaderOne = headerOne;
            QueryOne = queryOne;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public string HeaderOne { get; set; }

        /// <summary>
        /// Gets or sets query parameter with default
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public int? QueryOne { get; set; }

    }
}
