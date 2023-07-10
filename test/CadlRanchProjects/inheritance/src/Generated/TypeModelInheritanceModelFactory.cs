// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace _Type.Model.Inheritance.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypeModelInheritanceModelFactory
    {
        /// <summary> Initializes a new instance of SeaTurtle. </summary>
        /// <param name="swimmingSpeed"></param>
        /// <returns> A new <see cref="Models.SeaTurtle"/> instance for mocking. </returns>
        public static SeaTurtle SeaTurtle(int swimmingSpeed = default)
        {
            return new SeaTurtle("seeTurtle", swimmingSpeed);
        }

        /// <summary> Initializes a new instance of Golden. </summary>
        /// <param name="size"></param>
        /// <returns> A new <see cref="Models.Golden"/> instance for mocking. </returns>
        public static Golden Golden(int size = default)
        {
            return new Golden(DogKind.Golden, size);
        }

        /// <summary> Initializes a new instance of Cobra. </summary>
        /// <param name="size"></param>
        /// <returns> A new <see cref="Models.Cobra"/> instance for mocking. </returns>
        public static Cobra Cobra(int size = default)
        {
            return new Cobra(SnakeKind.Cobra, size);
        }
    }
}
