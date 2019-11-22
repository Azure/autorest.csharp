// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace body_complex.Models.V20160229
{
    public partial class DotFishMarket
    {
        private List<DotSalmon>? _salmons;
        private List<DotFish>? _fishes;

        public DotSalmon? SampleSalmon { get; set; }
        public ICollection<DotSalmon> Salmons => LazyInitializer.EnsureInitialized(ref _salmons);
        public DotFish? SampleFish { get; set; }
        public ICollection<DotFish> Fishes => LazyInitializer.EnsureInitialized(ref _fishes);
    }
}
