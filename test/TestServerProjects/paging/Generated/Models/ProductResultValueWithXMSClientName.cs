// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The ProductResultValueWithXMSClientName. </summary>
    internal partial class ProductResultValueWithXMSClientName
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="ProductResultValueWithXMSClientName"/>. </summary>
        internal ProductResultValueWithXMSClientName()
        {
            Indexes = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of <see cref="ProductResultValueWithXMSClientName"/>. </summary>
        /// <param name="indexes"></param>
        /// <param name="nextLink"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ProductResultValueWithXMSClientName(IReadOnlyList<Product> indexes, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Indexes = indexes;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the indexes. </summary>
        public IReadOnlyList<Product> Indexes { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
