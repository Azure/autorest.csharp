// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtLRO;

namespace MgmtLRO.Models
{
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class BarListResult
    {
        /// <summary> Initializes a new instance of BarListResult. </summary>
        /// <param name="value"> The list of bars. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal BarListResult(IEnumerable<BarData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of BarListResult. </summary>
        /// <param name="value"> The list of bars. </param>
        /// <param name="nextLink"> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </param>
        internal BarListResult(IReadOnlyList<BarData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of bars. </summary>
        public IReadOnlyList<BarData> Value { get; }
        /// <summary> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </summary>
        public string NextLink { get; }
    }
}
