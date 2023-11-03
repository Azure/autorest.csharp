// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace paging.Models
{
    /// <summary> The ProductResult. </summary>
    internal partial class ProductResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ProductResult"/>. </summary>
        internal ProductResult()
        {
            Values = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of <see cref="ProductResult"/>. </summary>
        /// <param name="values"></param>
        /// <param name="nextLink"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ProductResult(IReadOnlyList<Product> values, string nextLink, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Values = values;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the values. </summary>
        public IReadOnlyList<Product> Values { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
