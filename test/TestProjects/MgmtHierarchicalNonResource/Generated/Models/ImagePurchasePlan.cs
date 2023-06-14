// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Describes the gallery image definition purchase plan. This is used by marketplace images. </summary>
    public partial class ImagePurchasePlan
    {
        /// <summary> Initializes a new instance of ImagePurchasePlan. </summary>
        internal ImagePurchasePlan()
        {
        }

        /// <summary> Initializes a new instance of ImagePurchasePlan. </summary>
        /// <param name="name"> The plan ID. </param>
        /// <param name="publisher"> The publisher ID. </param>
        /// <param name="product"> The product ID. </param>
        internal ImagePurchasePlan(string name, string publisher, string product)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
        }

        /// <summary> The plan ID. </summary>
        public string Name { get; }
        /// <summary> The publisher ID. </summary>
        public string Publisher { get; }
        /// <summary> The product ID. </summary>
        public string Product { get; }
    }
}
