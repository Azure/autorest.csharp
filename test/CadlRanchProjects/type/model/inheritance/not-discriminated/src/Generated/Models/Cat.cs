// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Inheritance.NotDiscriminated.Models
{
    /// <summary> The second level model in the normal multiple levels inheritance. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of <see cref="Cat"/>. </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Cat(string name, int age) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Age = age;
        }

        /// <summary> Initializes a new instance of <see cref="Cat"/>. </summary>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="age"></param>
        internal Cat(string name, IDictionary<string, BinaryData> serializedAdditionalRawData, int age) : base(name, serializedAdditionalRawData)
        {
            Age = age;
        }

        /// <summary> Initializes a new instance of <see cref="Cat"/> for deserialization. </summary>
        internal Cat()
        {
        }

        /// <summary> Gets the age. </summary>
        public int Age { get; }
    }
}
