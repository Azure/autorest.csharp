// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AppConfiguration.Models.V10
{
    /// <summary> The result of a list request. </summary>
    public partial class KeyValueListResult
    {
        /// <summary> The collection value. </summary>
        public ICollection<KeyValue>? Items { get; set; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string? NextLink { get; set; }
    }
}
