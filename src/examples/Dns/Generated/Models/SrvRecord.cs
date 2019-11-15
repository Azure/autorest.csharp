// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Dns.Models.V20180501
{
    public partial class SrvRecord
    {
        public int? Priority { get; set; }
        public int? Weight { get; set; }
        public int? Port { get; set; }
        public string? Target { get; set; }
    }
}
