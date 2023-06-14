// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtSubscriptionNameParameter;

namespace MgmtSubscriptionNameParameter.Models
{
    /// <summary> The response to the List Subscriptions operation. </summary>
    internal partial class SBSubscriptionListResult
    {
        /// <summary> Initializes a new instance of SBSubscriptionListResult. </summary>
        internal SBSubscriptionListResult()
        {
            Value = new ChangeTrackingList<SBSubscriptionData>();
        }

        /// <summary> Initializes a new instance of SBSubscriptionListResult. </summary>
        /// <param name="value"> Result of the List Subscriptions operation. </param>
        /// <param name="nextLink"> Link to the next set of results. Not empty if Value contains incomplete list of subscriptions. </param>
        internal SBSubscriptionListResult(IReadOnlyList<SBSubscriptionData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Result of the List Subscriptions operation. </summary>
        public IReadOnlyList<SBSubscriptionData> Value { get; }
        /// <summary> Link to the next set of results. Not empty if Value contains incomplete list of subscriptions. </summary>
        public string NextLink { get; }
    }
}
