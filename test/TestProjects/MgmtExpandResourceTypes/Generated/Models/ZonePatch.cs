// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> Describes a request to update a DNS zone. </summary>
    public partial class ZonePatch
    {
        /// <summary> Initializes a new instance of ZonePatch. </summary>
        public ZonePatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
