// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Model.Inheritance.Models
{
    /// <summary> Unknown version of Fish. </summary>
    internal partial class UnknownFish : Fish
    {
        /// <summary> Initializes a new instance of UnknownFish. </summary>
        /// <param name="age"></param>
        internal UnknownFish(int age) : base(age)
        {
        }

        /// <summary> Initializes a new instance of UnknownFish. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="age"></param>
        internal UnknownFish(string kind, int age) : base(kind, age)
        {
        }
    }
}
