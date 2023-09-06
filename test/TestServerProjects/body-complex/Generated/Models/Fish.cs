// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.Serialization;

namespace body_complex.Models
{
    /// <summary>
    /// The Fish.
    /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
    /// </summary>
    [AbstractTypeDeserializer(typeof(UnknownFish))]
    public abstract partial class Fish
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Fish"/>. </summary>
        /// <param name="length"></param>
        protected Fish(float length)
        {
            Length = length;
            Siblings = new ChangeTrackingList<Fish>();
        }

        /// <summary> Initializes a new instance of <see cref="Fish"/>. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Fish(string fishtype, string species, float length, IList<Fish> siblings, Dictionary<string, BinaryData> rawData)
        {
            Fishtype = fishtype;
            Species = species;
            Length = length;
            Siblings = siblings;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="Fish"/> for deserialization. </summary>
        internal Fish()
        {
        }

        /// <summary> Gets or sets the fishtype. </summary>
        internal string Fishtype { get; set; }
        /// <summary> Gets or sets the species. </summary>
        public string Species { get; set; }
        /// <summary> Gets or sets the length. </summary>
        public float Length { get; set; }
        /// <summary>
        /// Gets the siblings
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </summary>
        public IList<Fish> Siblings { get; }
    }
}
