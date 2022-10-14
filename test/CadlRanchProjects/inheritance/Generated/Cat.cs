// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Models.Inheritance
{
    /// <summary> The second level model in the normal multiple levels inheritance. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="age"></param>
        public Cat(int age)
        {
            Age = age;
        }

        public int Age { get; set; }
    }
}
