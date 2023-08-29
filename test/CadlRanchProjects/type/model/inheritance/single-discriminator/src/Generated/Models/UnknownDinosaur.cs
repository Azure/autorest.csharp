// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary> Unknown version of Dinosaur. </summary>
    internal partial class UnknownDinosaur : Dinosaur
    {
        /// <summary> Initializes a new instance of UnknownDinosaur. </summary>
        /// <param name="size"></param>
        internal UnknownDinosaur(int size) : base(size)
        {
        }

        /// <summary> Initializes a new instance of UnknownDinosaur. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDinosaur(string kind, int size, Dictionary<string, BinaryData> rawData) : base(kind, size, rawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDinosaur"/> for deserialization. </summary>
        internal UnknownDinosaur()
        {
        }
    }
}
