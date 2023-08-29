// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
    /// Serialized Name: SamplePlan
    /// </summary>
    public partial class SamplePlan
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SamplePlan"/>. </summary>
        public SamplePlan()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SamplePlan"/>. </summary>
        /// <param name="name">
        /// The plan ID.
        /// Serialized Name: SamplePlan.name
        /// </param>
        /// <param name="publisher">
        /// The publisher ID.
        /// Serialized Name: SamplePlan.publisher
        /// </param>
        /// <param name="product">
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: SamplePlan.product
        /// </param>
        /// <param name="promotionCode">
        /// The promotion code.
        /// Serialized Name: SamplePlan.promotionCode
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SamplePlan(string name, string publisher, string product, string promotionCode, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            PromotionCode = promotionCode;
            _rawData = rawData;
        }

        /// <summary>
        /// The plan ID.
        /// Serialized Name: SamplePlan.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The publisher ID.
        /// Serialized Name: SamplePlan.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: SamplePlan.product
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The promotion code.
        /// Serialized Name: SamplePlan.promotionCode
        /// </summary>
        public string PromotionCode { get; set; }
    }
}
