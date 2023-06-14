// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtExpandResourceTypes;

namespace MgmtExpandResourceTypes.Models
{
    /// <summary> The response to a Zone List or ListAll operation. </summary>
    internal partial class ZoneListResult
    {
        /// <summary> Initializes a new instance of ZoneListResult. </summary>
        internal ZoneListResult()
        {
            Value = new ChangeTrackingList<ZoneData>();
        }

        /// <summary> Initializes a new instance of ZoneListResult. </summary>
        /// <param name="value"> Information about the DNS zones. </param>
        /// <param name="nextLink"> The continuation token for the next page of results. </param>
        internal ZoneListResult(IReadOnlyList<ZoneData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> Information about the DNS zones. </summary>
        public IReadOnlyList<ZoneData> Value { get; }
        /// <summary> The continuation token for the next page of results. </summary>
        public string NextLink { get; }
    }
}
