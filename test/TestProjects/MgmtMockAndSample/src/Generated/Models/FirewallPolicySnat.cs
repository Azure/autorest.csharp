// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    /// <summary> The private IP addresses/IP ranges to which traffic will not be SNAT. </summary>
    internal partial class FirewallPolicySnat
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FirewallPolicySnat"/>. </summary>
        public FirewallPolicySnat()
        {
            PrivateRanges = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="FirewallPolicySnat"/>. </summary>
        /// <param name="privateRanges"> List of private IP addresses/IP address ranges to not be SNAT. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FirewallPolicySnat(IList<string> privateRanges, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            PrivateRanges = privateRanges;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> List of private IP addresses/IP address ranges to not be SNAT. </summary>
        public IList<string> PrivateRanges { get; }
    }
}
