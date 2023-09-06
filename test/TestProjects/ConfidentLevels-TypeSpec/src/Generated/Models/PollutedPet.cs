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
    /// The base Pet model polluted by union in derived type
    /// Please note <see cref="PollutedPet"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="PollutedDog"/> and <see cref="UnpollutedCat"/>.
    /// </summary>
    [DeserializationProxy(typeof(UnknownPollutedPet))]
    internal abstract partial class PollutedPet
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of PollutedPet. </summary>
        /// <param name="name"> The name of the pet. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        protected PollutedPet(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of PollutedPet. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="name"> The name of the pet. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal PollutedPet(string kind, string name, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="PollutedPet"/> for deserialization. </summary>
        internal PollutedPet()
        {
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> The name of the pet. </summary>
        public string Name { get; set; }
    }
}
