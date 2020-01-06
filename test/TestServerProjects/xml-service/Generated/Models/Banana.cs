// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace xml_service.Models.V100
{
    /// <summary> A banana. </summary>
    public partial class Banana
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Name { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? Flavor { get; set; }
        /// <summary> The time at which you should reconsider eating this banana. </summary>
        public DateTimeOffset? Expiration { get; set; }
    }
}
