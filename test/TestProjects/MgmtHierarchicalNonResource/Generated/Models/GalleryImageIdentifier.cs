// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace MgmtHierarchicalNonResource.Models
{
    /// <summary> This is the gallery image definition identifier. </summary>
    public partial class GalleryImageIdentifier
    {
        /// <summary> Initializes a new instance of GalleryImageIdentifier. </summary>
        /// <param name="publisher"> The name of the gallery image definition publisher. </param>
        /// <param name="offer"> The name of the gallery image definition offer. </param>
        /// <param name="sku"> The name of the gallery image definition SKU. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisher"/>, <paramref name="offer"/> or <paramref name="sku"/> is null. </exception>
        internal GalleryImageIdentifier(string publisher, string offer, string sku)
        {
            Argument.AssertNotNull(publisher, nameof(publisher));
            Argument.AssertNotNull(offer, nameof(offer));
            Argument.AssertNotNull(sku, nameof(sku));

            Publisher = publisher;
            Offer = offer;
            Sku = sku;
        }

        /// <summary> The name of the gallery image definition publisher. </summary>
        public string Publisher { get; }
        /// <summary> The name of the gallery image definition offer. </summary>
        public string Offer { get; }
        /// <summary> The name of the gallery image definition SKU. </summary>
        public string Sku { get; }
    }
}
