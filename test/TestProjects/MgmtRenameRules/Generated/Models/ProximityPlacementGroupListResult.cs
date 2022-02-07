// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using MgmtRenameRules;

namespace MgmtRenameRules.Models
{
    /// <summary> The List Proximity Placement Group operation response. </summary>
    internal partial class ProximityPlacementGroupListResult
    {
        /// <summary> Initializes a new instance of ProximityPlacementGroupListResult. </summary>
        /// <param name="value"> The list of proximity placement groups. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ProximityPlacementGroupListResult(IEnumerable<ProximityPlacementGroupData> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of ProximityPlacementGroupListResult. </summary>
        /// <param name="value"> The list of proximity placement groups. </param>
        /// <param name="nextLink"> The URI to fetch the next page of proximity placement groups. </param>
        internal ProximityPlacementGroupListResult(IReadOnlyList<ProximityPlacementGroupData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of proximity placement groups. </summary>
        public IReadOnlyList<ProximityPlacementGroupData> Value { get; }
        /// <summary> The URI to fetch the next page of proximity placement groups. </summary>
        public string NextLink { get; }
    }
}
