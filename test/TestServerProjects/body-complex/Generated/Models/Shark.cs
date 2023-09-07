// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary>
    /// The Shark.
    /// Please note <see cref="Shark"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/> and <see cref="Sawshark"/>.
    /// </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of <see cref="Shark"/>. </summary>
        /// <param name="length"></param>
        /// <param name="birthday"></param>
        public Shark(float length, DateTimeOffset birthday) : base(length)
        {
            Birthday = birthday;
            Fishtype = "shark";
        }

        /// <summary> Initializes a new instance of <see cref="Shark"/>. </summary>
        /// <param name="fishtype"></param>
        /// <param name="species"></param>
        /// <param name="length"></param>
        /// <param name="siblings">
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cookiecuttershark"/>, <see cref="Goblinshark"/>, <see cref="Salmon"/>, <see cref="Sawshark"/>, <see cref="Shark"/> and <see cref="SmartSalmon"/>.
        /// </param>
        /// <param name="age"></param>
        /// <param name="birthday"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Shark(string fishtype, string species, float length, IList<Fish> siblings, int? age, DateTimeOffset birthday, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(fishtype, species, length, siblings, serializedAdditionalRawData)
        {
            Age = age;
            Birthday = birthday;
            Fishtype = fishtype ?? "shark";
        }

        /// <summary> Initializes a new instance of <see cref="Shark"/> for deserialization. </summary>
        internal Shark()
        {
        }

        /// <summary> Gets or sets the age. </summary>
        public int? Age { get; set; }
        /// <summary> Gets or sets the birthday. </summary>
        public DateTimeOffset Birthday { get; set; }
    }
}
