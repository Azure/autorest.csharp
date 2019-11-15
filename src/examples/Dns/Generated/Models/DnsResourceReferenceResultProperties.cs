// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class DnsResourceReferenceResultProperties
    {
        private List<DnsResourceReference>? _dnsResourceReferences;

        public ICollection<DnsResourceReference> DnsResourceReferences => LazyInitializer.EnsureInitialized(ref _dnsResourceReferences);
    }
}
