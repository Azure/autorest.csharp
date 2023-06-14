// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace azure_parameter_grouping.Models
{
    /// <summary> Parameter group. </summary>
    public partial class ParameterGroupingPostRequiredParameters
    {
        /// <summary> Initializes a new instance of ParameterGroupingPostRequiredParameters. </summary>
        /// <param name="path"> Path parameter. </param>
        /// <param name="body"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="path"/> is null. </exception>
        public ParameterGroupingPostRequiredParameters(string path, int body)
        {
            Argument.AssertNotNull(path, nameof(path));

            Path = path;
            Body = body;
        }

        /// <summary> Gets or sets the custom header. </summary>
        public string CustomHeader { get; set; }
        /// <summary> Query parameter with default. </summary>
        public int? Query { get; set; }
        /// <summary> Path parameter. </summary>
        public string Path { get; }
        /// <summary> Gets the body. </summary>
        public int Body { get; }
    }
}
