// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary>
    /// A pet
    /// Please note <see cref="Pet"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cat"/> and <see cref="Dog"/>.
    /// </summary>
    public abstract partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        protected Pet()
        {
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="id"> The Id of the pet. </param>
        internal Pet(PetKind kind, string id)
        {
            Kind = kind;
            Id = id;
        }

        /// <summary> The kind of the pet. </summary>
        internal PetKind Kind { get; set; }
        /// <summary> The Id of the pet. </summary>
        public string Id { get; }
    }
}
