// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class DnsResourceReference
    {
        private List<SubResource>? _dnsResources;

        public ICollection<SubResource> DnsResources => LazyInitializer.EnsureInitialized(ref _dnsResources);
        public SubResource? TargetResource { get; set; }
    }
}
