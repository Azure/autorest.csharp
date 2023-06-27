// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The UnknownDotFish. </summary>
    internal partial class UnknownDotFish : DotFish
    {
        /// <summary> Initializes a new instance of UnknownDotFish. </summary>
        /// <param name="fishType"></param>
        /// <param name="species"></param>
        internal UnknownDotFish(string fishType, string species) : base(fishType, species)
        {
            FishType = fishType ?? "Unknown";
        }
    }
}
