// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace model_flattening.Models
{
    /// <summary> Parameter group. </summary>
    public partial class FlattenParameterGroup
    {
        /// <summary> Initializes a new instance of FlattenParameterGroup. </summary>
        /// <param name="name"> Product name with value &apos;groupproduct&apos;. </param>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="productId"/> is null. </exception>
        public FlattenParameterGroup(string name, string productId)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (productId == null)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            Name = name;
            ProductId = productId;
            Capacity = "Large";
        }

        /// <summary> Product name with value &apos;groupproduct&apos;. </summary>
        public string Name { get; }
        /// <summary> Simple body product to put. </summary>
        public SimpleProduct SimpleBodyProduct { get; set; }
        /// <summary> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </summary>
        public string ProductId { get; }
        /// <summary> Description of product. </summary>
        public string Description { get; set; }
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
