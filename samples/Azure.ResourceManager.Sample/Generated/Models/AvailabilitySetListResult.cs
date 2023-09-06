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
    /// The List Availability Set operation response.
    /// Serialized Name: AvailabilitySetListResult
    /// </summary>
    internal partial class AvailabilitySetListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetListResult"/>. </summary>
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

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetListResult"/>. </summary>
        /// <param name="value">
        /// The list of availability sets
        /// Serialized Name: AvailabilitySetListResult.value
        /// </param>
        /// <param name="nextLink">
        /// The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets.
        /// Serialized Name: AvailabilitySetListResult.nextLink
        /// </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AvailabilitySetListResult(IReadOnlyList<AvailabilitySetData> value, string nextLink, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            NextLink = nextLink;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetListResult"/> for deserialization. </summary>
        internal AvailabilitySetListResult()
        {
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
