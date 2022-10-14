// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Models.Inheritance
{
    /// <summary> This is base model for polymorphic multiple levels inheritance with a discriminator. </summary>
    public partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        /// <param name="kind"></param>
        /// <param name="age"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="kind"/> is null. </exception>
        public Fish(string kind, int age)
        {
            Argument.AssertNotNull(kind, nameof(kind));

            Kind = kind;
            Age = age;
        }

        public string Kind { get; set; }

        public int Age { get; set; }
    }
}
