// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> This is a model with union types. </summary>
    internal partial class ModelWithUnionProperty
    {
        /// <summary> Initializes a new instance of ModelWithUnionProperty. </summary>
        /// <param name="unionProperty"> This is a union property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="unionProperty"/> is null. </exception>
        public ModelWithUnionProperty(object unionProperty)
        {
            Argument.AssertNotNull(unionProperty, nameof(unionProperty));

            UnionProperty = unionProperty;
        }

        /// <summary> This is a union property. </summary>
        public object UnionProperty { get; }
    }
}
