// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Goblinshark. </summary>
    public partial class Goblinshark : Shark
    {
        /// <summary> Initializes a new instance of Goblinshark. </summary>
        /// <param name="length"></param>
        /// <param name="birthday"></param>
        public Goblinshark(float length, DateTimeOffset birthday) : base(length, birthday)
        {
            Fishtype = "goblin";
        }

        /// <summary> Initializes a new instance of Goblinshark. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        /// <param name="age"></param>
        /// <param name="birthday"></param>
        /// <param name="jawsize"></param>
        /// <param name="color"> Colors possible. </param>
        internal Goblinshark(string fishtype, string species, float length, IList<Fish> siblings, int? age, DateTimeOffset birthday, int? jawsize, GoblinSharkColor? color) : base(fishtype, species, length, siblings, age, birthday)
        {
            Jawsize = jawsize;
            Color = color;
            Fishtype = fishtype ?? "goblin";
        }

        /// <summary> Gets or sets the jawsize. </summary>
        public int? Jawsize { get; set; }
        /// <summary> Colors possible. </summary>
        public GoblinSharkColor? Color { get; set; }
    }
}
