// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace body_complex.Models
{
    /// <summary> The Cat. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of Cat. </summary>
        public Cat()
        {
            Hates = new ChangeTrackingList<Dog>();
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="hates"></param>
        internal Cat(int? id, string name, string color, IList<Dog> hates) : base(id, name)
        {
            Color = color;
            Hates = hates;
        }

        /// <summary> Gets or sets the color. </summary>
        public string Color { get; set; }
        /// <summary> Gets the hates. </summary>
        public IList<Dog> Hates { get; }
    }
}
