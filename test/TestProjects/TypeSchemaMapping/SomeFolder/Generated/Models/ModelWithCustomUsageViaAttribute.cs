// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithCustomUsageViaAttribute. </summary>
    public partial class ModelWithCustomUsageViaAttribute
    {
        /// <summary> Initializes a new instance of ModelWithCustomUsageViaAttribute. </summary>
        public ModelWithCustomUsageViaAttribute()
        {
        }

        /// <summary> Initializes a new instance of ModelWithCustomUsageViaAttribute. </summary>
        /// <param name="modelProperty"> . </param>
        internal ModelWithCustomUsageViaAttribute(string modelProperty)
        {
            ModelProperty = modelProperty;
        }

        /// <summary> . </summary>
        public string ModelProperty { get; set; }
    }
}
