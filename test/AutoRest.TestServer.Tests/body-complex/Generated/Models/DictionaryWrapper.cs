// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace body_complex.Models.V20160229
{
    public partial class DictionaryWrapper
    {
        private Dictionary<string, string>? _defaultProgram;

        public IDictionary<string, string> DefaultProgram => LazyInitializer.EnsureInitialized(ref _defaultProgram);
    }
}
