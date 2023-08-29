// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSubscriptionNameParameter.Models
{
    /// <summary> Properties specific to client affine subscriptions. </summary>
    public partial class SBClientAffineProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SBClientAffineProperties"/>. </summary>
        public SBClientAffineProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SBClientAffineProperties"/>. </summary>
        /// <param name="clientId"> Indicates the Client ID of the application that created the client-affine subscription. </param>
        /// <param name="isDurable"> For client-affine subscriptions, this value indicates whether the subscription is durable or not. </param>
        /// <param name="isShared"> For client-affine subscriptions, this value indicates whether the subscription is shared or not. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SBClientAffineProperties(string clientId, bool? isDurable, bool? isShared, Dictionary<string, BinaryData> rawData)
        {
            ClientId = clientId;
            IsDurable = isDurable;
            IsShared = isShared;
            _rawData = rawData;
        }

        /// <summary> Indicates the Client ID of the application that created the client-affine subscription. </summary>
        public string ClientId { get; set; }
        /// <summary> For client-affine subscriptions, this value indicates whether the subscription is durable or not. </summary>
        public bool? IsDurable { get; set; }
        /// <summary> For client-affine subscriptions, this value indicates whether the subscription is shared or not. </summary>
        public bool? IsShared { get; set; }
    }
}
