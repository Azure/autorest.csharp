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
    /// The List Availability Set operation response.
    /// Serialized Name: AvailabilitySetListResult
    /// </summary>
    internal partial class AvailabilitySetListResult
    {
        /// <summary> Initializes a new instance of AvailabilitySetListResult. </summary>
        /// <param name="value">
        /// The list of availability sets
        /// Serialized Name: AvailabilitySetListResult.value
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal AvailabilitySetListResult(IEnumerable<AvailabilitySetData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of AvailabilitySetListResult. </summary>
        /// <param name="value">
        /// The list of availability sets
        /// Serialized Name: AvailabilitySetListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets.
        /// Serialized Name: AvailabilitySetListResult.nextLink
        /// </param>
        internal AvailabilitySetListResult(IReadOnlyList<AvailabilitySetData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// The list of availability sets
        /// Serialized Name: AvailabilitySetListResult.value
        /// </summary>
        public IReadOnlyList<AvailabilitySetData> Value { get; }
        /// <summary>
        /// The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets.
        /// Serialized Name: AvailabilitySetListResult.nextLink
        /// </summary>
        public string NextLink { get; }
    }
}
