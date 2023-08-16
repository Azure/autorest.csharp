// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace dpg_customization_LowLevel.Models
{
    /// <summary> The ProductResult. </summary>
    internal partial class ProductResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of ProductResult. </summary>
        internal ProductResult()
        {
            Values = new ChangeTrackingList<Product>();
        }

        /// <summary> Initializes a new instance of ProductResult. </summary>
        /// <param name="values"></param>
        /// <param name="nextLink"></param>
        /// <param name="rawData"></param>
        internal ProductResult(IReadOnlyList<Product> values, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Values = values;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Gets the values. </summary>
        public IReadOnlyList<Product> Values { get; }
        /// <summary> Gets the next link. </summary>
        public string NextLink { get; }
    }
}
