// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace multiple_inheritance.Models
{
    /// <summary> The Kitten. </summary>
    public partial class Kitten : Cat
    {
        /// <summary> Initializes a new instance of Kitten. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Kitten(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
        }

        /// <summary> Initializes a new instance of Kitten. </summary>
        /// <param name="name"></param>
        /// <param name="likesMilk"></param>
        /// <param name="meows"></param>
        /// <param name="hisses"></param>
        /// <param name="eatsMiceYet"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Kitten(string name, bool? likesMilk, bool? meows, bool? hisses, bool? eatsMiceYet) : base(name, likesMilk, meows, hisses)
        {
            Argument.AssertNotNull(name, nameof(name));

            EatsMiceYet = eatsMiceYet;
        }

        /// <summary> Gets or sets the eats mice yet. </summary>
        public bool? EatsMiceYet { get; set; }
    }
}
