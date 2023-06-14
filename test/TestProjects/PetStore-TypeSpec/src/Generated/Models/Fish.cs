// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace PetStore.Models
{
    /// <summary>
    /// Fish is the base model
    /// Please note <see cref="Fish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Shark"/> and <see cref="Tuna"/>.
    /// </summary>
    public abstract partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="size"> The size of the fish. </param>
        protected Fish(int size)
        {
            Size = size;
        }

        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"> The size of the fish. </param>
        internal Fish(string kind, int size)
        {
            Kind = kind;
            Size = size;
        }

        /// <summary> Discriminator. </summary>
        internal string Kind { get; set; }
        /// <summary> The size of the fish. </summary>
        public int Size { get; }
    }
}
