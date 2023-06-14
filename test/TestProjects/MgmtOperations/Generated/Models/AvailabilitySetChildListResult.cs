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
    internal partial class AvailabilitySetChildListResult
    {
        /// <summary> Initializes a new instance of AvailabilitySetChildListResult. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal AvailabilitySetChildListResult(IEnumerable<AvailabilitySetChildData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of AvailabilitySetChildListResult. </summary>
        /// <param name="value"> The list of availability sets. </param>
        /// <param name="nextLink"> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </param>
        internal AvailabilitySetChildListResult(IReadOnlyList<AvailabilitySetChildData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of availability sets. </summary>
        public IReadOnlyList<AvailabilitySetChildData> Value { get; }
        /// <summary> The URI to fetch the next page of AvailabilitySets. Call ListNext() with this URI to fetch the next page of AvailabilitySets. </summary>
        public string NextLink { get; }
    }
}
