// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithNullableObjectProperty. </summary>
    internal partial class ModelWithNullableObjectProperty
    {
        /// <summary> Initializes a new instance of ModelWithNullableObjectProperty. </summary>
        public ModelWithNullableObjectProperty()
        {
        }

        /// <summary> Initializes a new instance of ModelWithNullableObjectProperty. </summary>
        /// <param name="modelProperty"> . </param>
        internal ModelWithNullableObjectProperty(JsonElement modelProperty)
        {
            ModelProperty = modelProperty;
        }
    }
}
