// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The ProductResult. </summary>
    internal partial class ProductResult
    {
        /// <summary> Initializes a new instance of ProductResult. </summary>
        internal ProductResult()
        {
            Values = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of ProductResult. </summary>
        /// <param name="values"></param>
        /// <param name="nextLink"></param>
        internal ProductResult(IReadOnlyList<Product> values, string nextLink)
        {
            Values = values;
            NextLink = nextLink;
        }

        /// <summary> Gets the values. </summary>
        public IReadOnlyList<Product> Values { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
