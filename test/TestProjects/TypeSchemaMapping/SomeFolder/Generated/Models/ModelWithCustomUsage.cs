// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithCustomUsage. </summary>
    public partial class ModelWithCustomUsage
    {
        /// <summary> Initializes a new instance of ModelWithCustomUsage. </summary>
        public ModelWithCustomUsage()
        {
        }

        /// <summary> Initializes a new instance of ModelWithCustomUsage. </summary>
        /// <param name="modelProperty"> . </param>
        internal ModelWithCustomUsage(string modelProperty)
        {
            ModelProperty = modelProperty;
        }

        /// <summary> . </summary>
        public string ModelProperty { get; set; }
    }
}
