// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace ModelWithConverterUsage.Models
{
    /// <summary> The ModelStruct. </summary>
    public readonly partial struct ModelStruct
    {
        /// <summary> Initializes a new instance of ModelStruct. </summary>
        /// <param name="modelProperty"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelProperty"/> is null. </exception>
        public ModelStruct(string modelProperty)
        {
            Argument.AssertNotNull(modelProperty, nameof(modelProperty));

            ModelProperty = modelProperty;
        }

        /// <summary> . </summary>
        public string ModelProperty { get; }
    }
}
