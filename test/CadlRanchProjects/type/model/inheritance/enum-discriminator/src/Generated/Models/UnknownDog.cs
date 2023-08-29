// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Model.Inheritance.EnumDiscriminator.Models
{
    /// <summary> Unknown version of Dog. </summary>
    internal partial class UnknownDog : Dog
    {
        /// <summary> Initializes a new instance of UnknownDog. </summary>
        /// <param name="weight"> Weight of the dog. </param>
        internal UnknownDog(int weight) : base(weight)
        {
        }

        /// <summary> Initializes a new instance of UnknownDog. </summary>
        /// <param name="kind"> discriminator property. </param>
        /// <param name="weight"> Weight of the dog. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownDog(DogKind kind, int weight, Dictionary<string, BinaryData> rawData) : base(kind, weight, rawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownDog"/> for deserialization. </summary>
        internal UnknownDog()
        {
        }
    }
}
