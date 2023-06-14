// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtListMethods.Models
{
    /// <summary> The List of Non Resource Child operation response. </summary>
    internal partial class NonResourceChildListResult
    {
        /// <summary> Initializes a new instance of NonResourceChildListResult. </summary>
        internal NonResourceChildListResult()
        {
            Value = new ChangeTrackingList<NonResourceChild>();
        }

        /// <summary> Initializes a new instance of NonResourceChildListResult. </summary>
        /// <param name="value"> The list of Non Resource Child. </param>
        internal NonResourceChildListResult(IReadOnlyList<NonResourceChild> value)
        {
            Value = value;
        }

        /// <summary> The list of Non Resource Child. </summary>
        public IReadOnlyList<NonResourceChild> Value { get; }
    }
}
