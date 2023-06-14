// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace PetStore.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Pet(string name, int age)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Age = age;
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        /// <param name="age"></param>
        internal Pet(string name, string tag, int age)
        {
            Name = name;
            Tag = tag;
            Age = age;
        }

        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the tag. </summary>
        public string Tag { get; set; }
        /// <summary> Gets or sets the age. </summary>
        public int Age { get; set; }
    }
}
