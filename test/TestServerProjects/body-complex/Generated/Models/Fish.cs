// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace body_complex.Models.V20160229
{
    public partial class Fish
    {
        public Fish()
        {
            Fishtype = null;
        }
        public string Fishtype { get; internal set; }
        public string? Species { get; set; }
        public float Length { get; set; }
        public ICollection<Fish> Siblings { get; set; }
    }
}
