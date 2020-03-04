// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace paging.Models
{
    /// <summary> The OdataProductResult. </summary>
    public partial class OdataProductResult
    {
        public ICollection<Product> Values { get; set; }
        public string OdataNextLink { get; set; }
    }
}
