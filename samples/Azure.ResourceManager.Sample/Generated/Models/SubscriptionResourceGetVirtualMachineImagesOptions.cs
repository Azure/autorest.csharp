// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary> The SubscriptionResourceGetVirtualMachineImagesOptions. </summary>
    public partial class SubscriptionResourceGetVirtualMachineImagesOptions
    {
        /// <summary> Initializes a new instance of SubscriptionResourceGetVirtualMachineImagesOptions. </summary>
        /// <param name="location"> The name of a supported Azure region. </param>
        /// <param name="publisherName"> A valid image publisher. </param>
        /// <param name="offer"> A valid image publisher offer. </param>
        /// <param name="skus"> A valid image SKU. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="publisherName"/>, <paramref name="offer"/> or <paramref name="skus"/> is null. </exception>
        public SubscriptionResourceGetVirtualMachineImagesOptions(AzureLocation location, string publisherName, string offer, string skus)
        {
            Argument.AssertNotNull(publisherName, nameof(publisherName));
            Argument.AssertNotNull(offer, nameof(offer));
            Argument.AssertNotNull(skus, nameof(skus));

            Location = location;
            PublisherName = publisherName;
            Offer = offer;
            Skus = skus;
        }

        /// <summary> The name of a supported Azure region. </summary>
        public AzureLocation Location { get; }
        /// <summary> A valid image publisher. </summary>
        public string PublisherName { get; }
        /// <summary> A valid image publisher offer. </summary>
        public string Offer { get; }
        /// <summary> A valid image SKU. </summary>
        public string Skus { get; }
        /// <summary> The expand expression to apply on the operation. </summary>
        public string Expand { get; set; }
        /// <summary> The Integer to use. </summary>
        public int? Top { get; set; }
        /// <summary> The String to use. </summary>
        public string Orderby { get; set; }
    }
}
