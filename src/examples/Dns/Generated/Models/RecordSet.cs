// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Dns.Models.V20180501
{
    public partial class RecordSet
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Etag { get; set; }
        public RecordSetProperties? Properties { get; set; }
    }
}
