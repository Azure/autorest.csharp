// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class ZoneUpdate
    {
        private Dictionary<string, string>? _tags;

        public IDictionary<string, string> Tags => LazyInitializer.EnsureInitialized(ref _tags);
    }
}
