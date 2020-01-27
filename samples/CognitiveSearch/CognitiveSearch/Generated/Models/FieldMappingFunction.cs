// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a function that transforms a value from a data source before indexing. </summary>
    public partial class FieldMappingFunction
    {
        /// <summary> The name of the field mapping function. </summary>
        public string Name { get; set; }
        /// <summary> A dictionary of parameter name/value pairs to pass to the function. Each value must be of a primitive type. </summary>
        public IDictionary<string, object> Parameters { get; set; }
    }
}
