// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtOperations;

namespace MgmtOperations.Models
{
    /// <summary> The UnpatchableResourceListResult. </summary>
    internal partial class UnpatchableResourceListResult
    {
        /// <summary> Initializes a new instance of <see cref="UnpatchableResourceListResult"/>. </summary>
        internal UnpatchableResourceListResult()
        {
            Value = new ChangeTrackingList<UnpatchableResourceData>();
        }

        /// <summary> Initializes a new instance of <see cref="UnpatchableResourceListResult"/>. </summary>
        /// <param name="value"></param>
        internal UnpatchableResourceListResult(IReadOnlyList<UnpatchableResourceData> value)
        {
            Value = value;
        }

        /// <summary> Gets the value. </summary>
        public IReadOnlyList<UnpatchableResourceData> Value { get; }
    }
}
