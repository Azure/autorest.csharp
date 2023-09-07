// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtOperations;

namespace MgmtOperations.Models
{
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class AvailabilitySetChildListResult
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetChildListResult"/>. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal AvailabilitySetChildListResult(IEnumerable<AvailabilitySetChildData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetChildListResult"/>. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <param name="nextLink"> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AvailabilitySetChildListResult(IReadOnlyList<AvailabilitySetChildData> value, string nextLink, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Value = value;
            NextLink = nextLink;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AvailabilitySetChildListResult"/> for deserialization. </summary>
        internal AvailabilitySetChildListResult()
        {
        }

        /// <summary> The list of availability sets. </summary>
        public IReadOnlyList<AvailabilitySetChildData> Value { get; }
        /// <summary> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </summary>
        public string NextLink { get; }
    }
}
