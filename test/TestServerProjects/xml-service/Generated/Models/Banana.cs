// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models
{
    /// <summary> A banana. </summary>
    public partial class Banana
    {
        public string? Name { get; set; }
        public string? Flavor { get; set; }
        /// <summary> The time at which you should reconsider eating this banana. </summary>
        public DateTimeOffset? Expiration { get; set; }
    }
}
