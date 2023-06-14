// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Sawshark. </summary>
    public partial class Sawshark : Shark
    {
        /// <summary> Initializes a new instance of Sawshark. </summary>
        /// <param name="length"></param>
        /// <param name="birthday"></param>
        public Sawshark(float length, DateTimeOffset birthday) : base(length, birthday)
        {
            Fishtype = "sawshark";
        }

        /// <summary> Initializes a new instance of Sawshark. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        /// <param name="age"></param>
        /// <param name="birthday"></param>
        /// <param name="picture"></param>
        internal Sawshark(string fishtype, string species, float length, IList<Fish> siblings, int? age, DateTimeOffset birthday, byte[] picture) : base(fishtype, species, length, siblings, age, birthday)
        {
            Picture = picture;
            Fishtype = fishtype ?? "sawshark";
        }

        /// <summary> Gets or sets the picture. </summary>
        public byte[] Picture { get; set; }
    }
}
