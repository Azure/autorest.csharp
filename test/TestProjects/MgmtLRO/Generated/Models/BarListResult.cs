// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtLRO.Models.BarListResult
        ///
        /// </summary>
        /// <param name="value"> The list of bars. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal BarListResult(IEnumerable<BarData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtLRO.Models.BarListResult
        ///
        /// </summary>
        /// <param name="value"> The list of bars. </param>
        /// <param name="nextLink"> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BarListResult(IReadOnlyList<BarData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="BarListResult"/> for deserialization. </summary>
        internal BarListResult()
        {
        }

        /// <summary> The list of bars. </summary>
        public IReadOnlyList<BarData> Value { get; }
        /// <summary> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </summary>
        public string NextLink { get; }
    }
}
