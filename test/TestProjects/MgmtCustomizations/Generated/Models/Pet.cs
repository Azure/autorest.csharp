// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtCustomizations.Models
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
        /// <param name="name"> The name of the pet. </param>
        /// <param name="size">
        /// The size of the pet. This property here is mocking the following scenario:
        /// Despite in the swagger it has a type of string, in the real payload of this request, the service is actually sending using a number, therefore the type in this swagger here is wrong and we have to fix it using customization code.
        /// </param>
        internal Pet(PetKind kind, string name, int size)
        {
            Kind = kind;
            Name = name;
            Size = size;
        }

        /// <summary> The kind of the pet. </summary>
        internal PetKind Kind { get; set; }
        /// <summary> The name of the pet. </summary>
        public string Name { get; }
    }
}
