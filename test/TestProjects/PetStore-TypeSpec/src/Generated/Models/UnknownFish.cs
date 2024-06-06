// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace PetStore.Models
{
    /// <summary> Unknown version of Fish. </summary>
    internal partial class UnknownFish : Fish
    {
        /// <summary> Initializes a new instance of <see cref="UnknownFish"/>. </summary>
        /// <param name="kind"> Discriminator property for Fish. </param>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal UnknownFish(string kind, int size, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, size, serializedAdditionalRawData)
        {
        }

        /// <summary> Initializes a new instance of <see cref="UnknownFish"/> for deserialization. </summary>
        internal UnknownFish()
        {
        }
    }
}
