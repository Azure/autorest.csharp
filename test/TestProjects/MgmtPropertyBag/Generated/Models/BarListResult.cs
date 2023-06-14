// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtPropertyBag;

namespace MgmtPropertyBag.Models
{
    /// <summary> The List bar with subscription response. </summary>
    internal partial class BarListResult
    {
        /// <summary> Initializes a new instance of BarListResult. </summary>
        /// <param name="value"> The list of bar. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal BarListResult(IEnumerable<BarData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of BarListResult. </summary>
        /// <param name="value"> The list of bar. </param>
        /// <param name="nextLink"> The uri to fetch the next page of bar. Call ListNext() with this to fetch the next page. </param>
        internal BarListResult(IReadOnlyList<BarData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of bar. </summary>
        public IReadOnlyList<BarData> Value { get; }
        /// <summary> The uri to fetch the next page of bar. Call ListNext() with this to fetch the next page. </summary>
        public string NextLink { get; }
    }
}
