// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace body_complex.Models.V20160229
{
    public partial class DotFish
    {
        public string FishType { get; private set; }
        public string? Species { get; set; }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        private DotFish()
        {
        }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        public DotFish(string fishtype)
        {
            FishType = fishtype;
        }
    }
}
