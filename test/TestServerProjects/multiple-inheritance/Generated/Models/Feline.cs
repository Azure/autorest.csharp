// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace multiple_inheritance.Models
{
    /// <summary> The Feline. </summary>
    public partial class Feline
    {
        /// <summary> Initializes a new instance of Feline. </summary>
        public Feline()
        {
        }

        /// <summary> Initializes a new instance of Feline. </summary>
        /// <param name="meows"></param>
        /// <param name="hisses"></param>
        internal Feline(bool? meows, bool? hisses)
        {
            Meows = meows;
            Hisses = hisses;
        }

        /// <summary> Gets or sets the meows. </summary>
        public bool? Meows { get; set; }
        /// <summary> Gets or sets the hisses. </summary>
        public bool? Hisses { get; set; }
    }
}
