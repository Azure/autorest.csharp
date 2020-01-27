// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The product documentation. </summary>
    public partial class BaseProduct
    {
        /// <summary> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </summary>
        public string ProductId { get; set; }
        /// <summary> Description of product. </summary>
        public string Description { get; set; }
    }
}
