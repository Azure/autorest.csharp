// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Inheritance.Models
{
    /// <summary> The second level model in the normal multiple levels inheritance. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Cat(string name, int age) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Age = age;
        }

        /// <summary> Gets or sets the age. </summary>
        public int Age { get; set; }
    }
}
