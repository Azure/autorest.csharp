// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtSingletonResource;

namespace MgmtSingletonResource.Models
{
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class ParentResourceListResult
    {
        /// <summary> Initializes a new instance of ParentResourceListResult. </summary>
        /// <param name="value"> The list of parent resource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ParentResourceListResult(IEnumerable<ParentResourceData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of ParentResourceListResult. </summary>
        /// <param name="value"> The list of parent resource. </param>
        /// <param name="nextLink"> The URI to fetch the next page. </param>
        internal ParentResourceListResult(IReadOnlyList<ParentResourceData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of parent resource. </summary>
        public IReadOnlyList<ParentResourceData> Value { get; }
        /// <summary> The URI to fetch the next page. </summary>
        public string NextLink { get; }
    }
}
