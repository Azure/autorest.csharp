// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models.V100
{
    public partial class AccessPolicy
    {
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Expiry { get; set; }
        public string Permission { get; set; }
    }
}
