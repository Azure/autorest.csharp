// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace _Type.Model.Inheritance.EnumDiscriminator.Models
{
    /// <summary>
    /// Test extensible enum type for discriminator
    /// Please note <see cref="Dog"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Golden"/>.
    /// </summary>
    [DeserializationProxy(typeof(UnknownDog))]
    public abstract partial class Dog
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="weight"> Weight of the dog. </param>
        protected Dog(int weight)
        {
            Weight = weight;
        }

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="kind"> discriminator property. </param>
        /// <param name="weight"> Weight of the dog. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Dog(DogKind kind, int weight, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Weight = weight;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Dog"/> for deserialization. </summary>
        internal Dog()
        {
        }

        /// <summary> discriminator property. </summary>
        internal DogKind Kind { get; set; }
        /// <summary> Weight of the dog. </summary>
        public int Weight { get; set; }
    }
}
