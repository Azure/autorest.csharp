// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a function that transforms a value from a data source before indexing. </summary>
    public partial class FieldMappingFunction
    {
        /// <summary> Initializes a new instance of FieldMappingFunction. </summary>
        /// <param name="name"> The name of the field mapping function. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public FieldMappingFunction(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Parameters = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Initializes a new instance of FieldMappingFunction. </summary>
        /// <param name="name"> The name of the field mapping function. </param>
        /// <param name="parameters"> A dictionary of parameter name/value pairs to pass to the function. Each value must be of a primitive type. </param>
        internal FieldMappingFunction(string name, IDictionary<string, object> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        /// <summary> The name of the field mapping function. </summary>
        public string Name { get; set; }
        /// <summary> A dictionary of parameter name/value pairs to pass to the function. Each value must be of a primitive type. </summary>
        public IDictionary<string, object> Parameters { get; }
    }
}
