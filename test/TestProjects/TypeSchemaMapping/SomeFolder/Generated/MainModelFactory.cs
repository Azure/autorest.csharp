// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    /// <summary> Model factory for models. </summary>
    internal static partial class MainModelFactory
    {

        /// <summary> Initializes a new instance of ModelWithGuidProperty. </summary>
        /// <param name="modelProperty"> . </param>
        /// <returns> A new <see cref="Models.ModelWithGuidProperty"/> instance for mocking. </returns>
        public static ModelWithGuidProperty ModelWithGuidProperty(Guid? modelProperty = null)
        {
            return new ModelWithGuidProperty(modelProperty);
        }
    }
}
