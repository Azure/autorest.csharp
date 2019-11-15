// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Dns.Models.V20180501
{
    public partial class SoaRecord
    {
        public string? Host { get; set; }
        public string? Email { get; set; }
        public int? SerialNumber { get; set; }
        public int? RefreshTime { get; set; }
        public int? RetryTime { get; set; }
        public int? ExpireTime { get; set; }
        public int? MinimumTTL { get; set; }
    }
}
