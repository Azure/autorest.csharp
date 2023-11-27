// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    /// <summary> Result of the What-If operation. Contains a list of predicted changes and a URL link to get to the next set of results. </summary>
    public partial class WhatIfOperationResult
    {
        /// <summary> Initializes a new instance of <see cref="WhatIfOperationResult"/>. </summary>
        internal WhatIfOperationResult()
        {
            Changes = new ChangeTrackingList<WhatIfChange>();
        }

        /// <summary> Initializes a new instance of <see cref="WhatIfOperationResult"/>. </summary>
        /// <param name="status"> Status of the What-If operation. </param>
        /// <param name="errorResponse"> Error when What-If operation fails. </param>
        /// <param name="changes"> List of resource changes predicted by What-If operation. </param>
        internal WhatIfOperationResult(string status, ErrorResponse errorResponse, IReadOnlyList<WhatIfChange> changes)
        {
            Status = status;
            ErrorResponse = errorResponse;
            Changes = changes;
        }

        /// <summary> Status of the What-If operation. </summary>
        public string Status { get; }
        /// <summary> Error when What-If operation fails. </summary>
        internal ErrorResponse ErrorResponse { get; }
        /// <summary> The details of the error. </summary>
        public string Error
        {
            get => ErrorResponse?.Error;
        }

        /// <summary> List of resource changes predicted by What-If operation. </summary>
        public IReadOnlyList<WhatIfChange> Changes { get; }
    }
}
