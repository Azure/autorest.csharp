// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> The second level legacy model in polymorphic single level inheritance. </summary>
    public partial class TRex : Dinosaur
    {
        /// <summary> Initializes a new instance of <see cref="TRex"/>. </summary>
        /// <param name="size"></param>
        internal TRex(int size) : base(size)
        {
            Kind = "t-rex";
        }

        /// <summary> Initializes a new instance of <see cref="TRex"/>. </summary>
        /// <param name="kind"> Discriminator property for Dinosaur. </param>
        /// <param name="size"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TRex(string kind, int size, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, size, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="TRex"/> for deserialization. </summary>
        internal TRex()
        {
        }
    }
}
