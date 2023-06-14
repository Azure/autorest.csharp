// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The List run command operation response. </summary>
    internal partial class TheParentsListResult
    {
        /// <summary> Initializes a new instance of TheParentsListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TheParentsListResult(IEnumerable<TheParentData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of TheParentsListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <param name="nextLink"> The uri to fetch the next page of run commands. </param>
        internal TheParentsListResult(IReadOnlyList<TheParentData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of run commands. </summary>
        public IReadOnlyList<TheParentData> Value { get; }
        /// <summary> The uri to fetch the next page of run commands. </summary>
        public string NextLink { get; }
    }
}
