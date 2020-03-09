// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The Salmon. </summary>
    public partial class Salmon : Fish
    {
        /// <summary> Initializes a new instance of Salmon. </summary>
        public Salmon()
        {
            Fishtype = "salmon";
        }
        /// <summary> Initializes a new instance of Salmon. </summary>
        internal Salmon(string location, bool? iswild, string fishtype, string species, float length, ICollection<Fish> siblings) : base(fishtype, species, length, siblings)
        {
            Location = location;
            Iswild = iswild;
        }
        public string Location { get; set; }
        public bool? Iswild { get; set; }
    }
}
