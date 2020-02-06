// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> The Goblinshark. </summary>
    public partial class Goblinshark : Shark
    {
        /// <summary> Initializes a new instance of Goblinshark. </summary>
        public Goblinshark()
        {
            Fishtype = "goblin";
        }
        public int? Jawsize { get; set; }
        /// <summary> Colors possible. </summary>
        public GoblinSharkColor? Color { get; set; }
    }
}
