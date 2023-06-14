// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtSafeFlatten;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The TypeTwoListResult. </summary>
    internal partial class TypeTwoListResult
    {
        /// <summary> Initializes a new instance of TypeTwoListResult. </summary>
        /// <param name="value"> The list of of type twos. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TypeTwoListResult(IEnumerable<TypeTwoData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of TypeTwoListResult. </summary>
        /// <param name="value"> The list of of type twos. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </param>
        internal TypeTwoListResult(IReadOnlyList<TypeTwoData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of of type twos. </summary>
        public IReadOnlyList<TypeTwoData> Value { get; }
        /// <summary> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </summary>
        public string NextLink { get; }
    }
}
