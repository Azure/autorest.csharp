// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Inheritance.Models
{
    /// <summary> The third level model in the normal multiple levels inheritance. </summary>
    public partial class Siamese : Cat
    {
        /// <summary> Initializes a new instance of Siamese. </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="smart"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Siamese(string name, int age, bool smart) : base(name, age)
        {
            Argument.AssertNotNull(name, nameof(name));

            Smart = smart;
        }

        /// <summary> Gets or sets the smart. </summary>
        public bool Smart { get; set; }
    }
}
