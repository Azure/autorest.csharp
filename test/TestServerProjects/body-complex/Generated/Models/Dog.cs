// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Dog. </summary>
    public partial class Dog : Pet
    {
        /// <summary> Initializes a new instance of <see cref="Dog"/>. </summary>
        public Dog()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Dog"/>. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="food"></param>
        internal Dog(int? id, string name, IDictionary<string, BinaryData> serializedAdditionalRawData, string food) : base(id, name, serializedAdditionalRawData)
        {
            Food = food;
        }

        /// <summary> Gets or sets the food. </summary>
        public string Food { get; set; }
    }
}
