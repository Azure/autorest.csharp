// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Inheritance.Models
{
    /// <summary> The second level model in polymorphic multiple levels inheritance which contains references to other polymorphic instances. </summary>
    public partial class Salmon : Fish
    {
        /// <summary> Initializes a new instance of Salmon. </summary>
        /// <param name="age"></param>
        public Salmon(int age) : base(age)
        {
            Kind = "salmon";
            Friends = new ChangeTrackingList<Fish>();
            Hate = new ChangeTrackingDictionary<string, Fish>();
        }

        /// <summary> Initializes a new instance of Salmon. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="age"></param>
        /// <param name="friends"></param>
        /// <param name="hate"></param>
        /// <param name="partner"></param>
        internal Salmon(string kind, int age, IList<Fish> friends, IDictionary<string, Fish> hate, Fish partner) : base(kind, age)
        {
            Friends = friends;
            Hate = hate;
            Partner = partner;
        }

        /// <summary>
        /// Gets the friends
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Shark"/> and <see cref="Salmon"/>.
        /// </summary>
        public IList<Fish> Friends { get; }
        /// <summary>
        /// Gets the hate
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Shark"/> and <see cref="Salmon"/>.
        /// </summary>
        public IDictionary<string, Fish> Hate { get; }
        /// <summary>
        /// Gets or sets the partner
        /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Shark"/> and <see cref="Salmon"/>.
        /// </summary>
        public Fish Partner { get; set; }
    }
}
