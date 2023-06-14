// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace PetStore.Models
{
    /// <summary> Tuna is a fish. </summary>
    public partial class Tuna : Fish
    {
        /// <summary> Initializes a new instance of Tuna. </summary>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="fat"> The amount of fat of the tuna. </param>
        internal Tuna(int size, int fat) : base(size)
        {
            Kind = "tuna";
            Fat = fat;
        }

        /// <summary> Initializes a new instance of Tuna. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="fat"> The amount of fat of the tuna. </param>
        internal Tuna(string kind, int size, int fat) : base(kind, size)
        {
            Fat = fat;
        }

        /// <summary> The amount of fat of the tuna. </summary>
        public int Fat { get; }
    }
}
