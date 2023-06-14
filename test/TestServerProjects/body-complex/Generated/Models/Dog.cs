// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Dog. </summary>
    public partial class Dog : Pet
    {
        /// <summary> Initializes a new instance of Dog. </summary>
        public Dog()
        {
        }

        /// <summary> Initializes a new instance of Dog. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="food"></param>
        internal Dog(int? id, string name, string food) : base(id, name)
        {
            Food = food;
        }

        /// <summary> Gets or sets the food. </summary>
        public string Food { get; set; }
    }
}
