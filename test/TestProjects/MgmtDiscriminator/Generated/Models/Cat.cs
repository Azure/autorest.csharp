// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtDiscriminator.Models
{
    /// <summary> A cat. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of Cat. </summary>
        public Cat()
        {
            Kind = PetKind.Cat;
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="kind"> The kind of the pet. </param>
        /// <param name="id"> The Id of the pet. </param>
        /// <param name="meow"> A cat can meow. </param>
        internal Cat(PetKind kind, string id, string meow) : base(kind, id)
        {
            Meow = meow;
            Kind = kind;
        }

        /// <summary> A cat can meow. </summary>
        public string Meow { get; set; }
    }
}
