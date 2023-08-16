// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithGuidProperty. </summary>
    public partial class ModelWithGuidProperty
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::TypeSchemaMapping.Models.ModelWithGuidProperty
        ///
        /// </summary>
        public ModelWithGuidProperty()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::TypeSchemaMapping.Models.ModelWithGuidProperty
        ///
        /// </summary>
        /// <param name="modelProperty"> . </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithGuidProperty(Guid? modelProperty, Dictionary<string, BinaryData> rawData)
        {
            ModelProperty = modelProperty;
            _rawData = rawData;
        }

        /// <summary> . </summary>
        public Guid? ModelProperty { get; }
    }
}
