// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Result of listing marketplaces. It contains a list of available marketplaces in reverse chronological order by billing period. </summary>
    internal partial class MarketplacesListResult
    {
        /// <summary> Initializes a new instance of MarketplacesListResult. </summary>
        internal MarketplacesListResult()
        {
            Value = new ChangeTrackingList<Marketplace>();
        }

        /// <summary> Initializes a new instance of MarketplacesListResult. </summary>
        /// <param name="value"> The list of marketplaces. </param>
        /// <param name="nextLink"> The link (url) to the next page of results. </param>
        internal MarketplacesListResult(IReadOnlyList<Marketplace> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of marketplaces. </summary>
        public IReadOnlyList<Marketplace> Value { get; }
        /// <summary> The link (url) to the next page of results. </summary>
        public string NextLink { get; }
    }
}
