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
    /// The List Dedicated Host Group with resource group response.
    /// Serialized Name: DedicatedHostGroupListResult
    /// </summary>
    internal partial class DedicatedHostGroupListResult
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.DedicatedHostGroupListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of dedicated host groups
        /// Serialized Name: DedicatedHostGroupListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal DedicatedHostGroupListResult(IEnumerable<DedicatedHostGroupData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary>
        /// Initializes a new instance of global::Azure.ResourceManager.Sample.Models.DedicatedHostGroupListResult
        ///
        /// </summary>
        /// <param name="value">
        /// The list of dedicated host groups
        /// Serialized Name: DedicatedHostGroupListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of Dedicated Host Groups. Call ListNext() with this URI to fetch the next page of Dedicated Host Groups.
        /// Serialized Name: DedicatedHostGroupListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DedicatedHostGroupListResult(IReadOnlyList<DedicatedHostGroupData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DedicatedHostGroupListResult"/> for deserialization. </summary>
        internal DedicatedHostGroupListResult()
        {
        }

        /// <summary>
        /// The list of dedicated host groups
        /// Serialized Name: DedicatedHostGroupListResult.value
        /// </summary>
        public IReadOnlyList<DedicatedHostGroupData> Value { get; }
        /// <summary>
        /// The URI to fetch the next page of Dedicated Host Groups. Call ListNext() with this URI to fetch the next page of Dedicated Host Groups.
        /// Serialized Name: DedicatedHostGroupListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
