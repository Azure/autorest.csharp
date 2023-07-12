// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace azure_parameter_grouping.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class AzureParameterGroupingModelFactory
    {
        /// <summary> Initializes a new instance of ParameterGroupingPostRequiredParameters. </summary>
        /// <param name="customHeader"></param>
        /// <param name="query"> Query parameter with default. </param>
        /// <param name="path"> Path parameter. </param>
        /// <param name="body"></param>
        /// <returns> A new <see cref="Models.ParameterGroupingPostRequiredParameters"/> instance for mocking. </returns>
        public static ParameterGroupingPostRequiredParameters ParameterGroupingPostRequiredParameters(string customHeader = null, int? query = null, string path = null, int body = default)
        {
            return new ParameterGroupingPostRequiredParameters(customHeader, query, path, body);
        }
    }
}
