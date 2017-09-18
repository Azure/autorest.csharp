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
    /// Additional parameters for PostOptional operation.
    /// </summary>
    public partial class ParameterGroupingPostOptionalParameters
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ParameterGroupingPostOptionalParameters class.
        /// </summary>
        public ParameterGroupingPostOptionalParameters()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ParameterGroupingPostOptionalParameters class.
        /// </summary>
        /// <param name="query">Query parameter with default</param>
        public ParameterGroupingPostOptionalParameters(string customHeader = default(string), int? query = default(int?))
        {
            CustomHeader = customHeader;
            Query = query;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public string CustomHeader { get; set; }

        /// <summary>
        /// Gets or sets query parameter with default
        /// </summary>
        [JsonProperty(PropertyName = "")]
        public int? Query { get; set; }

    }
}
