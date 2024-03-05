// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using MgmtListMethods;

namespace MgmtListMethods.Models
{
    /// <summary> The List of Non Resource Child operation response. </summary>
    internal partial class NonResourceChildListResult
    {
        /// <summary> Initializes a new instance of <see cref="NonResourceChildListResult"/>. </summary>
        internal NonResourceChildListResult()
        {
            Value = new ChangeTrackingList<NonResourceChild>();
        }

        /// <summary> Initializes a new instance of <see cref="NonResourceChildListResult"/>. </summary>
        /// <param name="value"> The list of Non Resource Child. </param>
        internal NonResourceChildListResult(IReadOnlyList<NonResourceChild> value)
        {
            Value = value;
        }

        /// <summary> The list of Non Resource Child. </summary>
        public IReadOnlyList<NonResourceChild> Value { get; }
    }
}
