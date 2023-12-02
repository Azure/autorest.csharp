// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace _Type.Model.Inheritance.EnumDiscriminator.Models
{
    /// <summary>
    /// Test fixed enum type for discriminator
    /// Please note <see cref="Snake"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="Cobra"/>.
    /// </summary>
    public abstract partial class Snake
    {
        /// <summary> Initializes a new instance of <see cref="Snake"/>. </summary>
        /// <param name="length"> Length of the snake. </param>
        protected Snake(int length)
        {
            Length = length;
        }

        /// <summary> Initializes a new instance of <see cref="Snake"/>. </summary>
        /// <param name="kind"> discriminator property. </param>
        /// <param name="length"> Length of the snake. </param>
        internal Snake(SnakeKind kind, int length)
        {
            Kind = kind;
            Length = length;
        }

        /// <summary> discriminator property. </summary>
        internal SnakeKind Kind { get; set; }
        /// <summary> Length of the snake. </summary>
        public int Length { get; set; }
    }
}
