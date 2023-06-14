// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Defines a mapping between a field in a data source and a target field in an index. </summary>
    public partial class FieldMapping
    {
        /// <summary> Initializes a new instance of FieldMapping. </summary>
        /// <param name="sourceFieldName"> The name of the field in the data source. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sourceFieldName"/> is null. </exception>
        public FieldMapping(string sourceFieldName)
        {
            Argument.AssertNotNull(sourceFieldName, nameof(sourceFieldName));

            SourceFieldName = sourceFieldName;
        }

        /// <summary> Initializes a new instance of FieldMapping. </summary>
        /// <param name="sourceFieldName"> The name of the field in the data source. </param>
        /// <param name="targetFieldName"> The name of the target field in the index. Same as the source field name by default. </param>
        /// <param name="mappingFunction"> A function to apply to each source field value before indexing. </param>
        internal FieldMapping(string sourceFieldName, string targetFieldName, FieldMappingFunction mappingFunction)
        {
            SourceFieldName = sourceFieldName;
            TargetFieldName = targetFieldName;
            MappingFunction = mappingFunction;
        }

        /// <summary> The name of the field in the data source. </summary>
        public string SourceFieldName { get; set; }
        /// <summary> The name of the target field in the index. Same as the source field name by default. </summary>
        public string TargetFieldName { get; set; }
        /// <summary> A function to apply to each source field value before indexing. </summary>
        public FieldMappingFunction MappingFunction { get; set; }
    }
}
