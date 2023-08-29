// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace PetStore.Models
{
    /// <summary>
    /// Fish is the base model
    /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Shark"/> and <see cref="Tuna"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownFish))]
    public abstract partial class Fish
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="size"> The size of the fish. </param>
        protected Fish(int size)
        {
            Size = size;
        }

        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Fish(string kind, int size, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Size = size;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Fish"/> for deserialization. </summary>
        internal Fish()
        {
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> The size of the fish. </summary>
        public int Size { get; }
    }
}
