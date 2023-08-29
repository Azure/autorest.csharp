// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace model_flattening.Models
{
    /// <summary> The product documentation. </summary>
    public partial class BaseProduct
    {
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::model_flattening.Models.BaseProduct
        ///
        /// </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="productId"/> is null. </exception>
        public BaseProduct(string productId)
        {
            Argument.AssertNotNull(productId, nameof(productId));

            ProductId = productId;
        }

        /// <summary>
        /// Initializes a new instance of global::model_flattening.Models.BaseProduct
        ///
        /// </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BaseProduct(string productId, string description, Dictionary<string, BinaryData> rawData)
        {
            ProductId = productId;
            Description = description;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="BaseProduct"/> for deserialization. </summary>
        internal BaseProduct()
        {
        }

        /// <summary> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </summary>
        public string ProductId { get; set; }
        /// <summary> Description of product. </summary>
        public string Description { get; set; }
    }
}
