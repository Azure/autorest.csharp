// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Models.Inheritance.Models
{
    /// <summary>
    /// This is base model for polymorphic multiple levels inheritance with a discriminator.
    /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Shark"/> and <see cref="Salmon"/>.
    /// </summary>
    public abstract partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="age"></param>
        protected Fish(int age)
        {
            Age = age;
        }

        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="age"></param>
        internal Fish(string kind, int age)
        {
            Kind = kind;
            Age = age;
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> Gets or sets the age. </summary>
        public int Age { get; set; }
    }
}
