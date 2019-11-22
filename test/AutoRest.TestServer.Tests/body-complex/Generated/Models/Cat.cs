// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace body_complex.Models.V20160229
{
    public partial class Cat
    {
        private List<Dog>? _hates;

        public string? Color { get; set; }
        public ICollection<Dog> Hates => LazyInitializer.EnsureInitialized(ref _hates);
    }
}
