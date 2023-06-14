// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Used for establishing the purchase context of any 3rd Party artifact through MarketPlace.
    /// Serialized Name: PurchasePlan
    /// </summary>
    public partial class PurchasePlan
    {
        /// <summary> Initializes a new instance of PurchasePlan. </summary>
        /// <param name="publisher">
        /// The publisher ID.
        /// Serialized Name: PurchasePlan.publisher
        /// </param>
        /// <param name="name">
        /// The plan ID.
        /// Serialized Name: PurchasePlan.name
        /// </param>
        /// <param name="product">
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: PurchasePlan.product
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisher"/>, <paramref name="name"/> or <paramref name="product"/> is null. </exception>
        public PurchasePlan(string publisher, string name, string product)
        {
            Argument.AssertNotNull(publisher, nameof(publisher));
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(product, nameof(product));

            Publisher = publisher;
            Name = name;
            Product = product;
        }

        /// <summary>
        /// The publisher ID.
        /// Serialized Name: PurchasePlan.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// The plan ID.
        /// Serialized Name: PurchasePlan.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: PurchasePlan.product
        /// </summary>
        public string Product { get; set; }
    }
}
