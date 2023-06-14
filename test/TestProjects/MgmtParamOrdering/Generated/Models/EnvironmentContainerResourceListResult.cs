// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtParamOrdering;

namespace MgmtParamOrdering.Models
{
    /// <summary> The list dedicated host operation response. </summary>
    internal partial class EnvironmentContainerResourceListResult
    {
        /// <summary> Initializes a new instance of EnvironmentContainerResourceListResult. </summary>
        /// <param name="value"> The list of dedicated hosts. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal EnvironmentContainerResourceListResult(IEnumerable<EnvironmentContainerResourceData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of EnvironmentContainerResourceListResult. </summary>
        /// <param name="value"> The list of dedicated hosts. </param>
        /// <param name="nextLink"> The URI to fetch the next page of dedicated hosts. Call ListNext() with this URI to fetch the next page of dedicated hosts. </param>
        internal EnvironmentContainerResourceListResult(IReadOnlyList<EnvironmentContainerResourceData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of dedicated hosts. </summary>
        public IReadOnlyList<EnvironmentContainerResourceData> Value { get; }
        /// <summary> The URI to fetch the next page of dedicated hosts. Call ListNext() with this URI to fetch the next page of dedicated hosts. </summary>
        public string NextLink { get; }
    }
}
