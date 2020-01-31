// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace body_complex.Models
{
    /// <summary> The DotFishMarket. </summary>
    public partial class DotFishMarket
    {
        public DotSalmon SampleSalmon { get; set; }
        public ICollection<DotSalmon> Salmons { get; set; }
        public DotFish SampleFish { get; set; }
        public ICollection<DotFish> Fishes { get; set; }
    }
}
