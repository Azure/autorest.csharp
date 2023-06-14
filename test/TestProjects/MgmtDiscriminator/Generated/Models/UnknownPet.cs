// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> The UnknownPet. </summary>
    internal partial class UnknownPet : Pet
    {
        /// <summary> Initializes a new instance of UnknownPet. </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="id"> The Id of the pet. </param>
        internal UnknownPet(PetKind kind, string id) : base(kind, id)
        {
            Kind = kind;
        }
    }
}
