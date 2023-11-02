// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Union.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypeUnionModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ModelWithSimpleUnionPropertyInResponse"/>. </summary>
        /// <param name="simpleUnion"></param>
        /// <returns> A new <see cref="Models.ModelWithSimpleUnionPropertyInResponse"/> instance for mocking. </returns>
        public static ModelWithSimpleUnionPropertyInResponse ModelWithSimpleUnionPropertyInResponse(BinaryData simpleUnion = null)
        {
            return new ModelWithSimpleUnionPropertyInResponse(simpleUnion, new Dictionary<string, BinaryData>());
        }

        /// <summary> Initializes a new instance of <see cref="Models.ModelWithNamedUnionPropertyInResponse"/>. </summary>
        /// <param name="namedUnion"></param>
        /// <returns> A new <see cref="Models.ModelWithNamedUnionPropertyInResponse"/> instance for mocking. </returns>
        public static ModelWithNamedUnionPropertyInResponse ModelWithNamedUnionPropertyInResponse(BinaryData namedUnion = null)
        {
            return new ModelWithNamedUnionPropertyInResponse(namedUnion, new Dictionary<string, BinaryData>());
        }
    }
}
