// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithGuidProperty. </summary>
    public partial class ModelWithGuidProperty
    {
        /// <summary> Initializes a new instance of ModelWithGuidProperty. </summary>
        public ModelWithGuidProperty()
        {
        }

        /// <summary> Initializes a new instance of ModelWithGuidProperty. </summary>
        /// <param name="modelProperty"> . </param>
        internal ModelWithGuidProperty(Guid? modelProperty)
        {
            ModelProperty = modelProperty;
        }

        /// <summary> . </summary>
        public Guid? ModelProperty { get; }
    }
}
