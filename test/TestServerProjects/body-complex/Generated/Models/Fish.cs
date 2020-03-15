// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Fish. </summary>
    public partial class Fish
    {
        /// <summary> Initializes a new instance of Fish. </summary>
        internal Fish()
        {
        }
        /// <summary> Initializes a new instance of Fish. </summary>
        internal Fish(string fishtype, string species, float length, IList<Fish> siblings)
        {
            Fishtype = fishtype;
            Species = species;
            Length = length;
            Siblings = siblings;
        }
        public string Fishtype { get; internal set; }
        public string Species { get; set; }
        public float Length { get; set; }
        public IList<Fish> Siblings { get; set; }
    }
}
