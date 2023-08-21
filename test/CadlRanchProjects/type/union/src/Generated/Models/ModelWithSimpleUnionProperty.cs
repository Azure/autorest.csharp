// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace _Type.Union.Models
{
    /// <summary> The ModelWithSimpleUnionProperty. </summary>
    internal partial class ModelWithSimpleUnionProperty
    {
        /// <summary> Initializes a new instance of ModelWithSimpleUnionProperty. </summary>
        /// <param name="simpleUnion"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="simpleUnion"/> is null. </exception>
        public ModelWithSimpleUnionProperty(object simpleUnion)
        {
            Argument.AssertNotNull(simpleUnion, nameof(simpleUnion));

            SimpleUnion = simpleUnion;
        }

        /// <summary> Gets the simple union. </summary>
        public object SimpleUnion { get; }
    }
}
