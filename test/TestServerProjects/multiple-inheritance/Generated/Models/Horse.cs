// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace multiple_inheritance.Models
{
    /// <summary> The Horse. </summary>
    public partial class Horse : Pet
    {
        /// <summary> Initializes a new instance of Horse. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Horse(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));
        }

        /// <summary> Initializes a new instance of Horse. </summary>
        /// <param name="name"></param>
        /// <param name="isAShowHorse"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Horse(string name, bool? isAShowHorse) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            IsAShowHorse = isAShowHorse;
        }

        /// <summary> Gets or sets the is a show horse. </summary>
        public bool? IsAShowHorse { get; set; }
    }
}
