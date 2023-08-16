// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Sample;

namespace Azure.ResourceManager.Sample.Models
{
    /// <summary>
    /// The list dedicated host operation response.
    /// Serialized Name: DedicatedHostListResult
    /// </summary>
    internal partial class DedicatedHostListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.DedicatedHostListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of dedicated hosts
        /// Serialized Name: DedicatedHostListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal DedicatedHostListResult(IEnumerable<DedicatedHostData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.DedicatedHostListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of dedicated hosts
        /// Serialized Name: DedicatedHostListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of dedicated hosts. Call ListNext() with this URI to fetch the next page of dedicated hosts.
        /// Serialized Name: DedicatedHostListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DedicatedHostListResult(IReadOnlyList<DedicatedHostData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary>
        /// The list of dedicated hosts
        /// Serialized Name: DedicatedHostListResult.value
        /// </summary>
        public IReadOnlyList<DedicatedHostData> Value { get; }
        /// <summary>
        /// The URI to fetch the next page of dedicated hosts. Call ListNext() with this URI to fetch the next page of dedicated hosts.
        /// Serialized Name: DedicatedHostListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
