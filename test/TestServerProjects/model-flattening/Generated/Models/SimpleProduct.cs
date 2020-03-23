// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace model_flattening.Models
{
    /// <summary> The product documentation. </summary>
    public partial class SimpleProduct : BaseProduct
    {
        /// <summary> Initializes a new instance of SimpleProduct. </summary>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        public SimpleProduct(string productId) : base(productId)
        {
        }

        /// <summary> Initializes a new instance of SimpleProduct. </summary>
        /// <param name="maxProductDisplayName"> Display name of product. </param>
        /// <param name="capacity"> Capacity of product. For example, 4 people. </param>
        /// <param name="genericValue"> Generic URL value. </param>
        /// <param name="odataValue"> URL value. </param>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <param name="description"> Description of product. </param>
        internal SimpleProduct(string maxProductDisplayName, string capacity, string genericValue, string odataValue, string productId, string description) : base(productId, description)
        {
            MaxProductDisplayName = maxProductDisplayName;
            Capacity = capacity;
            GenericValue = genericValue;
            OdataValue = odataValue;
        }

        /// <summary> Display name of product. </summary>
        public string MaxProductDisplayName { get; set; }
        /// <summary> Capacity of product. For example, 4 people. </summary>
        public string Capacity { get; set; }
        /// <summary> Generic URL value. </summary>
        public string GenericValue { get; set; }
        /// <summary> URL value. </summary>
        public string OdataValue { get; set; }
    }
}
