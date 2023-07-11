// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The List run command operation response. </summary>
    internal partial class ChildBodiesListResult
    {
        /// <summary> Initializes a new instance of ChildBodiesListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal ChildBodiesListResult(IEnumerable<ChildBodyData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of ChildBodiesListResult. </summary>
        /// <param name="value"> The list of run commands. </param>
        /// <param name="nextLink"> The uri to fetch the next page of run commands. </param>
        internal ChildBodiesListResult(IReadOnlyList<ChildBodyData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of run commands. </summary>
        public IReadOnlyList<ChildBodyData> Value { get; }
        /// <summary> The uri to fetch the next page of run commands. </summary>
        public string NextLink { get; }
    }
}
