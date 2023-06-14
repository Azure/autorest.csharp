// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtCustomizations.Models
{
    /// <summary> The properties. </summary>
    public partial class PetStoreProperties
    {
        /// <summary> Initializes a new instance of PetStoreProperties. </summary>
        public PetStoreProperties()
        {
        }

        /// <summary> Initializes a new instance of PetStoreProperties. </summary>
        /// <param name="order"> The order. </param>
        /// <param name="pet">
        /// A pet
        /// Please note <see cref="Pet"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cat"/> and <see cref="Dog"/>.
        /// </param>
        internal PetStoreProperties(int? order, Pet pet)
        {
            Order = order;
            Pet = pet;
        }
        /// <summary>
        /// A pet
        /// Please note <see cref="Pet"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="Cat"/> and <see cref="Dog"/>.
        /// </summary>
        public Pet Pet { get; set; }
    }
}
