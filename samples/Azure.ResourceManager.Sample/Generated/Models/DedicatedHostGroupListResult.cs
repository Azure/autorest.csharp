// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> Initializes a new instance of DedicatedHostGroupListResult. </summary>
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

        /// <summary> Initializes a new instance of DedicatedHostGroupListResult. </summary>
        /// <param name="value">
        /// The list of dedicated host groups
        /// Serialized Name: DedicatedHostGroupListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of Dedicated Host Groups. Call ListNext() with this URI to fetch the next page of Dedicated Host Groups.
        /// Serialized Name: DedicatedHostGroupListResult.nextLink
        /// </param>
        internal DedicatedHostGroupListResult(IReadOnlyList<DedicatedHostGroupData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
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
