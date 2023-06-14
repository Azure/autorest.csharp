// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace body_complex.Models
{
    /// <summary>
    /// The DotFish.
    /// Please note <see cref="DotFish"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="DotSalmon"/>.
    /// </summary>
    public abstract partial class DotFish
    {
        /// <summary> Initializes a new instance of DotFish. </summary>
        protected DotFish()
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

        /// <summary> Gets or sets the fish type. </summary>
        internal string FishType { get; set; }
        /// <summary> Gets the species. </summary>
        public string Species { get; }
    }
}
