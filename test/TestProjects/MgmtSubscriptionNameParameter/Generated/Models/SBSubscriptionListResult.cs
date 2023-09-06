// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using MgmtSubscriptionNameParameter;

namespace MgmtSubscriptionNameParameter.Models
{
    /// <summary> The response to the List Subscriptions operation. </summary>
    internal partial class SBSubscriptionListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SBSubscriptionListResult"/>. </summary>
        internal SBSubscriptionListResult()
        {
            Value = new ChangeTrackingList<SBSubscriptionData>();
        }

        /// <summary> Initializes a new instance of <see cref="SBSubscriptionListResult"/>. </summary>
        /// <param name="value"> Result of the List Subscriptions operation. </param>
        /// <param name="nextLink"> Link to the next set of results. Not empty if Value contains incomplete list of subscriptions. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SBSubscriptionListResult(IReadOnlyList<SBSubscriptionData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Result of the List Subscriptions operation. </summary>
        public IReadOnlyList<SBSubscriptionData> Value { get; }
        /// <summary> Link to the next set of results. Not empty if Value contains incomplete list of subscriptions. </summary>
        public string NextLink { get; }
    }
}
