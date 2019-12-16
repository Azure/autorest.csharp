// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models.V20160229
{
    public partial class DotFish
    {
        public DotFish()
        {
            FishType = null;
        }
        public string FishType { get; internal set; }
        public string? Species { get; set; }
    }
}
