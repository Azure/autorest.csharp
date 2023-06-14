// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace multiple_inheritance.Models
{
    /// <summary> The Cat. </summary>
    public partial class Cat : Pet
    {
        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Cat(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
        }

        /// <summary> Initializes a new instance of Cat. </summary>
        /// <param name="name"></param>
        /// <param name="likesMilk"></param>
        /// <param name="meows"></param>
        /// <param name="hisses"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Cat(string name, bool? likesMilk, bool? meows, bool? hisses) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            LikesMilk = likesMilk;
            Meows = meows;
            Hisses = hisses;
        }

        /// <summary> Gets or sets the likes milk. </summary>
        public bool? LikesMilk { get; set; }
        /// <summary> Gets or sets the meows. </summary>
        public bool? Meows { get; set; }
        /// <summary> Gets or sets the hisses. </summary>
        public bool? Hisses { get; set; }
    }
}
