// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace body_complex.Models.V20160229
{
    public partial class Fish
    {
        private List<Fish>? _siblings;

        public string Fishtype { get; private set; }
        public string? Species { get; set; }
        public double Length { get; private set; }
        public ICollection<Fish> Siblings => LazyInitializer.EnsureInitialized(ref _siblings);

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        private Fish()
        {
        }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

        public Fish(string fishtype, double length)
        {
            Fishtype = fishtype;
            Length = length;
        }
    }
}
