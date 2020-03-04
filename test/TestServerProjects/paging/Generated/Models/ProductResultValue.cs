// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace paging.Models
{
    /// <summary> The ProductResultValue. </summary>
    public partial class ProductResultValue
    {
        public ICollection<Product> Value { get; set; }
        public string NextLink { get; set; }
    }
}
