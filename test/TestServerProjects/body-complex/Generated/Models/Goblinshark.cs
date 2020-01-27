// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class Goblinshark : Shark
    {
        /// <summary> Initializes a new instance of Goblinshark. </summary>
        public Goblinshark()
        {
            Fishtype = "goblin";
        }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-INTEGER. </summary>
        public int? Jawsize { get; set; }
        /// <summary> Colors possible. </summary>
        public GoblinSharkColor? Color { get; set; }
    }
}
