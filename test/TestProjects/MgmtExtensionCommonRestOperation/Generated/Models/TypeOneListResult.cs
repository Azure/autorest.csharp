// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtExtensionCommonRestOperation;

namespace MgmtExtensionCommonRestOperation.Models
{
    /// <summary> The TypeOneListResult. </summary>
    internal partial class TypeOneListResult
    {
        /// <summary> Initializes a new instance of TypeOneListResult. </summary>
        /// <param name="value"> The list of of typeones. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal TypeOneListResult(IEnumerable<TypeOneData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of TypeOneListResult. </summary>
        /// <param name="value"> The list of of typeones. </param>
        /// <param name="nextLink"> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </param>
        internal TypeOneListResult(IReadOnlyList<TypeOneData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of of typeones. </summary>
        public IReadOnlyList<TypeOneData> Value { get; }
        /// <summary> The uri to fetch the next page of Virtual Machine Scale Set VMs. Call ListNext() with this to fetch the next page of VMSS VMs. </summary>
        public string NextLink { get; }
    }
}
