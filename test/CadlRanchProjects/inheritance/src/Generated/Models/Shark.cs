// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Model.Inheritance.Models
{
    /// <summary> The second level model in polymorphic multiple levels inheritance and it defines a new discriminator. </summary>
    public partial class Shark : Fish
    {
        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="age"></param>
        public Shark(int age) : base(age)
        {
            Kind = "shark";
        }

        /// <summary> Initializes a new instance of Shark. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <param name="age"></param>
        internal Shark(string kind, int age) : base(kind, age)
        {
        }
    }
}
