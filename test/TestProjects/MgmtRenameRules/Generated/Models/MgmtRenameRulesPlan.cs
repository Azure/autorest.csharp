// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtRenameRules.Models
{
    /// <summary>
    /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started -&gt;**. Enter any required information and then click **Save**.
    /// Serialized Name: Plan
    /// </summary>
    public partial class MgmtRenameRulesPlan
    {
        /// <summary> Initializes a new instance of MgmtRenameRulesPlan. </summary>
        public MgmtRenameRulesPlan()
        {
        }

        /// <summary> Initializes a new instance of MgmtRenameRulesPlan. </summary>
        /// <param name="name">
        /// The plan ID.
        /// Serialized Name: Plan.name
        /// </param>
        /// <param name="publisher">
        /// The publisher ID.
        /// Serialized Name: Plan.publisher
        /// </param>
        /// <param name="product">
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: Plan.product
        /// </param>
        /// <param name="promotionCode">
        /// The promotion code.
        /// Serialized Name: Plan.promotionCode
        /// </param>
        internal MgmtRenameRulesPlan(string name, string publisher, string product, string promotionCode)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            PromotionCode = promotionCode;
        }

        /// <summary>
        /// The plan ID.
        /// Serialized Name: Plan.name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The publisher ID.
        /// Serialized Name: Plan.publisher
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// Serialized Name: Plan.product
        /// </summary>
        public string Product { get; set; }
        /// <summary>
        /// The promotion code.
        /// Serialized Name: Plan.promotionCode
        /// </summary>
        public string PromotionCode { get; set; }
    }
}
