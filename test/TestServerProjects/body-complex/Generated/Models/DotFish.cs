// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The DotFish. </summary>
    public partial class DotFish
    {
        /// <summary> Initializes a new instance of DotFish. </summary>
        internal DotFish()
        {
        }

        /// <summary> Initializes a new instance of DotFish. </summary>
        /// <param name="fishType"></param>
        /// <param name="species"></param>
        internal DotFish(string fishType, string species)
        {
            FishType = fishType;
            Species = species;
        }

        /// <summary> Gets or sets the fishtype. </summary>
        internal string FishType { get; set; }
        /// <summary> Gets the species. </summary>
        public string Species { get; }
    }
}
