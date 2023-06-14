// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace body_complex.Models
{
    /// <summary>
    /// The Fish.
    /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
    /// </summary>
    public abstract partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="length"></param>
        protected Fish(float length)
        {
            Length = length;
            Siblings = new ChangeTrackingList<Fish>();
        }

        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        internal Fish(string fishtype, string species, float length, IList<Fish> siblings)
        {
            Fishtype = fishtype;
            Species = species;
            Length = length;
            Siblings = siblings;
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
