// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class ZoneListResult
    {
        private List<Zone>? _value;

        public ICollection<Zone> Value => LazyInitializer.EnsureInitialized(ref _value);
        public string? NextLink { get; set; }
    }
}
