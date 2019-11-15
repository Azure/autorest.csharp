// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class TxtRecord
    {
        private List<string>? _value;

        public ICollection<string> Value => LazyInitializer.EnsureInitialized(ref _value);
    }
}
