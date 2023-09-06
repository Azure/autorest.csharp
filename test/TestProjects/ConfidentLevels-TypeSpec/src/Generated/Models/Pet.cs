// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Serialization;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary>
    /// The base Pet model
    /// Please note <see cref="Pet"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cat"/> and <see cref="Dog"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownPet))]
    public abstract partial class Pet
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected Pet(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Pet(string kind, string name, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Pet"/> for deserialization. </summary>
        internal Pet()
        {
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> The name of the pet. </summary>
        public string Name { get; set; }
    }
}
