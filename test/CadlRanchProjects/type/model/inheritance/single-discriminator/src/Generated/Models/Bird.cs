// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Serialization;

namespace _Type.Model.Inheritance.SingleDiscriminator.Models
{
    /// <summary>
    /// This is base model for polymorphic single level inheritance with a discriminator.
    /// Please note <see cref="Bird"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="SeaGull"/>, <see cref="Sparrow"/>, <see cref="Goose"/> and <see cref="Eagle"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownBird))]
    public abstract partial class Bird
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Bird. </summary>
        /// <param name="wingspan"></param>
        protected Bird(int wingspan)
        {
            Wingspan = wingspan;
        }

        /// <summary> Initializes a new instance of Bird. </summary>
        /// <param name="kind"></param>
        /// <param name="wingspan"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Bird(string kind, int wingspan, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Wingspan = wingspan;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Bird"/> for deserialization. </summary>
        internal Bird()
        {
        }

        /// <summary> Gets or sets the kind. </summary>
        internal string Kind { get; set; }
        /// <summary> Gets or sets the wingspan. </summary>
        public int Wingspan { get; set; }
    }
}
