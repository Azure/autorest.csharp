// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace body_complex.Models.V20160229
{
    public partial class ArrayWrapper
    {
        private List<string>? _array;

        public ICollection<string> Array => LazyInitializer.EnsureInitialized(ref _array);
    }
}
