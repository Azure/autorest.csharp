// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;

namespace Azure.Dns.Models.V20180501
{
    public partial class CloudErrorBody
    {
        private List<CloudErrorBody>? _details;

        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? Target { get; set; }
        public ICollection<CloudErrorBody> Details => LazyInitializer.EnsureInitialized(ref _details);
    }
}
