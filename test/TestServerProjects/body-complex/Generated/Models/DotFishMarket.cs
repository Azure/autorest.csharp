// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The DotFishMarket. </summary>
    public partial class DotFishMarket
    {
        /// <summary> Initializes a new instance of DotFishMarket. </summary>
        internal DotFishMarket()
        {
        }
        /// <summary> Initializes a new instance of DotFishMarket. </summary>
        internal DotFishMarket(DotSalmon sampleSalmon, IList<DotSalmon> salmons, DotFish sampleFish, IList<DotFish> fishes)
        {
            SampleSalmon = sampleSalmon;
            Salmons = salmons;
            SampleFish = sampleFish;
            Fishes = fishes;
        }
        public DotSalmon SampleSalmon { get; set; }
        public IList<DotSalmon> Salmons { get; set; }
        public DotFish SampleFish { get; set; }
        public IList<DotFish> Fishes { get; set; }
    }
}
