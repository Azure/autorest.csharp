// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace paging.Models
{
    /// <summary> MISSING·SCHEMA-DESCRIPTION-OBJECTSCHEMA. </summary>
    public partial class ProductResultValue
    {
        /// <summary> MISSING·SCHEMA-DESCRIPTION-ARRAYSCHEMA. </summary>
        public ICollection<Product>? Value { get; set; }
        /// <summary> MISSING·SCHEMA-DESCRIPTION-STRING. </summary>
        public string? NextLink { get; set; }
    }
}
