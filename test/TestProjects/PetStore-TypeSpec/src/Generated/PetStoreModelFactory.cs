// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace PetStore.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class PetStoreModelFactory
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="size"> The size of the fish. </param>
        /// <returns> A new <see cref="Models.Fish"/> instance for mocking. </returns>
        public static Fish Fish(string kind = null, int size = default)
        {
            return new UnknownFish(kind, size);
        }

        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="bite"> The bite of the shark. </param>
        /// <returns> A new <see cref="Models.Shark"/> instance for mocking. </returns>
        public static Shark Shark(int size = default, string bite = null)
        {
            return new Shark("shark", size, bite);
        }

        /// <summary> Initializes a new instance of Tuna. </summary>
        /// <param name="size"> The size of the fish. </param>
        /// <param name="fat"> The amount of fat of the tuna. </param>
        /// <returns> A new <see cref="Models.Tuna"/> instance for mocking. </returns>
        public static Tuna Tuna(int size = default, int fat = default)
        {
            return new Tuna("tuna", size, fat);
        }
    }
}
