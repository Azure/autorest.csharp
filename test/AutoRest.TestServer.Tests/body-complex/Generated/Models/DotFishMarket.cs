// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace body_complex.Models.V20160229
{
    public partial class DotFishMarket
    {
        public DotSalmon? SampleSalmon { get; set; }
        public ICollection<DotSalmon> Salmons { get; } = new List<DotSalmon>();
        public DotFish? SampleFish { get; set; }
        public ICollection<DotFish> Fishes { get; } = new List<DotFish>();
    }
}
