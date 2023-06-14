// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> The List Availability Set operation response. </summary>
    internal partial class TenantParentWithNonResChListResult
    {
        /// <summary> Initializes a new instance of TenantParentWithNonResChListResult. </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TenantParentWithNonResChListResult(IEnumerable<TenantParentWithNonResChData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of TenantParentWithNonResChListResult. </summary>
        /// <param name="value"> The list of fakes. </param>
        /// <param name="nextLink"> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </param>
        internal TenantParentWithNonResChListResult(IReadOnlyList<TenantParentWithNonResChData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of fakes. </summary>
        public IReadOnlyList<TenantParentWithNonResChData> Value { get; }
        /// <summary> The URI to fetch the next page of Fakes. Call ListNext() with this URI to fetch the next page of Fakes. </summary>
        public string NextLink { get; }
    }
}
