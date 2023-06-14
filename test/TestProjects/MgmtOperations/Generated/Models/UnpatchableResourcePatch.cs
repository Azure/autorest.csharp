// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtOperations.Models
{
    /// <summary> The update content of unpatchable resource. </summary>
    public partial class UnpatchableResourcePatch
    {
        /// <summary> Initializes a new instance of UnpatchableResourcePatch. </summary>
        public UnpatchableResourcePatch()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
