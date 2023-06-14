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
    /// <summary> The List operation response. </summary>
    internal partial class SubParentWithNonResChListResult
    {
        /// <summary> Initializes a new instance of SubParentWithNonResChListResult. </summary>
        /// <param name="value"> List. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal SubParentWithNonResChListResult(IEnumerable<SubParentWithNonResChData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of SubParentWithNonResChListResult. </summary>
        /// <param name="value"> List. </param>
        /// <param name="nextLink"> The URI to fetch the next page. Call ListNext() with this URI to fetch the next page. </param>
        internal SubParentWithNonResChListResult(IReadOnlyList<SubParentWithNonResChData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List. </summary>
        public IReadOnlyList<SubParentWithNonResChData> Value { get; }
        /// <summary> The URI to fetch the next page. Call ListNext() with this URI to fetch the next page. </summary>
        public string NextLink { get; }
    }
}
