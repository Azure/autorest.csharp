// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> Describes the gallery image definition purchase plan. This is used by marketplace images. </summary>
    public partial class ImagePurchasePlan
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ImagePurchasePlan"/>. </summary>
        internal ImagePurchasePlan()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ImagePurchasePlan"/>. </summary>
        /// <param name="name"> The plan ID. </param>
        /// <param name="publisher"> The publisher ID. </param>
        /// <param name="product"> The product ID. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ImagePurchasePlan(string name, string publisher, string product, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Publisher = publisher;
            Product = product;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The plan ID. </summary>
        public string Name { get; }
        /// <summary> The publisher ID. </summary>
        public string Publisher { get; }
        /// <summary> The product ID. </summary>
        public string Product { get; }
    }
}
