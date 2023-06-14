// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using MgmtConstants;

namespace MgmtConstants.Models
{
    /// <summary> The List Virtual Machine operation response. </summary>
    internal partial class OptionalMachineListResult
    {
        /// <summary> Initializes a new instance of OptionalMachineListResult. </summary>
        /// <param name="value"> The list of virtual machines. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        internal OptionalMachineListResult(IEnumerable<OptionalMachineData> value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value.ToList();
        }

        /// <summary> Initializes a new instance of OptionalMachineListResult. </summary>
        /// <param name="value"> The list of virtual machines. </param>
        /// <param name="nextLink"> The URI to fetch the next page of VMs. Call ListNext() with this URI to fetch the next page of Virtual Machines. </param>
        internal OptionalMachineListResult(IReadOnlyList<OptionalMachineData> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> The list of virtual machines. </summary>
        public IReadOnlyList<OptionalMachineData> Value { get; }
        /// <summary> The URI to fetch the next page of VMs. Call ListNext() with this URI to fetch the next page of Virtual Machines. </summary>
        public string NextLink { get; }
    }
}
