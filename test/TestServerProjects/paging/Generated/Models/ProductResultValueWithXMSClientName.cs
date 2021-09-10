// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The ProductResultValueWithXMSClientName. </summary>
    internal partial class ProductResultValueWithXMSClientName
    {
        /// <summary> Initializes a new instance of ProductResultValueWithXMSClientName. </summary>
        internal ProductResultValueWithXMSClientName()
        {
            Indexes = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of ProductResultValueWithXMSClientName. </summary>
        /// <param name="indexes"> The Indexes. </param>
        /// <param name="nextLink"> The NextLink. </param>
        internal ProductResultValueWithXMSClientName(IReadOnlyList<Product> indexes, string nextLink)
        {
            Indexes = indexes;
            NextLink = nextLink;
        }

        /// <summary> The Indexes. </summary>
        public IReadOnlyList<Product> Indexes { get; }
        /// <summary> The NextLink. </summary>
        public string NextLink { get; }
    }
}
