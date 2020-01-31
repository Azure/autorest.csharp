// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace custom_baseUrl_paging.Models
{
    /// <summary> The ProductResult. </summary>
    public partial class ProductResult
    {
        public ICollection<Product> Values { get; set; }
        public string NextLink { get; set; }
    }
}
