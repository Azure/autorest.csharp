// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> This is a derived model with unions. </summary>
    internal partial class DerivedModelWithUnion : BaseModel
    {
        /// <summary> Initializes a new instance of <see cref="DerivedModelWithUnion"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="unionProperty"> The union property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="unionProperty"/> is null. </exception>
        public DerivedModelWithUnion(string name, object unionProperty) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(unionProperty, nameof(unionProperty));

            UnionProperty = unionProperty;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModelWithUnion"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="size"> The size. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="unionProperty"> The union property. </param>
        internal DerivedModelWithUnion(string name, double? size, IDictionary<string, BinaryData> serializedAdditionalRawData, object unionProperty) : base(name, size, serializedAdditionalRawData)
        {
            UnionProperty = unionProperty;
        }

        /// <summary> Initializes a new instance of <see cref="DerivedModelWithUnion"/> for deserialization. </summary>
        internal DerivedModelWithUnion()
        {
        }

        /// <summary> The union property. </summary>
        public object UnionProperty { get; }
    }
}
