// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

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
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
        }

        /// <summary> Initializes a new instance of Horse. </summary>
        /// <param name="name"></param>
        /// <param name="isAShowHorse"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal Horse(string name, bool? isAShowHorse) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            IsAShowHorse = isAShowHorse;
        }

        public bool? IsAShowHorse { get; set; }
    }
}
