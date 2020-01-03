// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models.V100
{
    public partial class Banana
    {
        public string? Name { get; set; }
        public string? Flavor { get; set; }
        public DateTimeOffset? Expiration { get; set; }
    }
}
