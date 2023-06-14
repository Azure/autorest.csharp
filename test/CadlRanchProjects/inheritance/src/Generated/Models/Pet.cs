// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace _Type.Model.Inheritance.Models
{
    /// <summary> This is base model for non-discriminator normal multiple levels inheritance. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Pet(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
    }
}
