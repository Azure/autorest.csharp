// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtCustomizations.Models
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
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        /// <param name="meow"> A cat can meow. </param>
        internal Cat(PetKind kind, string name, int size, string meow) : base(kind, name, size)
        {
            Meow = meow;
            Kind = kind;
        }
    }
}
