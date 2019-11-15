// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class DnsResourceReferenceRequestProperties
    {
        private List<SubResource>? _targetResources;

        public ICollection<SubResource> TargetResources => LazyInitializer.EnsureInitialized(ref _targetResources);
    }
}
