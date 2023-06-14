// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace TypeSchemaMapping.Models
{
    /// <summary> The ModelWithUriProperty. </summary>
    public partial class ModelWithUriProperty
    {
        /// <summary> Initializes a new instance of ModelWithUriProperty. </summary>
        public ModelWithUriProperty()
        {
        }

        /// <summary> Initializes a new instance of ModelWithUriProperty. </summary>
        /// <param name="uri"> . </param>
        internal ModelWithUriProperty(Uri uri)
        {
            Uri = uri;
        }
    }
}
