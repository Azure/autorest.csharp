// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtOperations;

namespace MgmtOperations.Models
{
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class AvailabilitySetGrandChildListResult
    {
        /// <summary> Initializes a new instance of AvailabilitySetGrandChildListResult. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal AvailabilitySetGrandChildListResult(IEnumerable<AvailabilitySetGrandChildData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of AvailabilitySetGrandChildListResult. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <param name="nextLink"> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </param>
        internal AvailabilitySetGrandChildListResult(IReadOnlyList<AvailabilitySetGrandChildData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of availability sets. </summary>
        public IReadOnlyList<AvailabilitySetGrandChildData> Value { get; }
        /// <summary> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </summary>
        public string NextLink { get; }
    }
}
