// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace model_flattening.Models
{
    /// <summary> Parameter group. </summary>
    public partial class FlattenParameterGroup
    {
        /// <summary> Initializes a new instance of FlattenParameterGroup. </summary>
        /// <param name="name"> Product name with value 'groupproduct'. </param>
        /// <param name="productId"> Unique identifier representing a specific product for a given latitude &amp; longitude. For example, uberX in San Francisco will have a different product_id than uberX in Los Angeles. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="productId"/> is null. </exception>
        public FlattenParameterGroup(string name, string productId)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(productId, nameof(productId));

            Name = name;
            ProductId = productId;
        }

        /// <summary> Product name with value 'groupproduct'. </summary>
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
        public SimpleProductPropertiesMaxProductCapacity? Capacity { get; set; }
        /// <summary> Generic URL value. </summary>
        public string GenericValue { get; set; }
        /// <summary> URL value. </summary>
        public string OdataValue { get; set; }
    }
}
