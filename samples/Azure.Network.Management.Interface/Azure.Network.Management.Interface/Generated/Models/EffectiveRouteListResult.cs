// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> Response for list effective route API service call. </summary>
    public partial class EffectiveRouteListResult
    {
        /// <summary> Initializes a new instance of EffectiveRouteListResult. </summary>
        internal EffectiveRouteListResult()
        {
        }

        /// <summary> Initializes a new instance of EffectiveRouteListResult. </summary>
        /// <param name="value"> A list of effective routes. </param>
        /// <param name="nextLink"> The URL to get the next set of results. </param>
        internal EffectiveRouteListResult(IList<EffectiveRoute> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> A list of effective routes. </summary>
        public IList<EffectiveRoute> Value { get; }
        /// <summary> The URL to get the next set of results. </summary>
        public string NextLink { get; }
    }
}
