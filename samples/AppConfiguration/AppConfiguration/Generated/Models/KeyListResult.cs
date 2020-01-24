// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace AppConfiguration.Models
{
    /// <summary> The result of a list request. </summary>
    public partial class KeyListResult
    {
        /// <summary> The collection value. </summary>
        public ICollection<Key> Items { get; set; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; set; }
    }
}
