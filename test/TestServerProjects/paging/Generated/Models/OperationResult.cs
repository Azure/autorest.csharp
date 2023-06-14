// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace paging.Models
{
    /// <summary> The OperationResult. </summary>
    internal partial class OperationResult
    {
        /// <summary> Initializes a new instance of OperationResult. </summary>
        internal OperationResult()
        {
        }

        /// <summary> The status of the request. </summary>
        public OperationResultStatus? Status { get; }
    }
}
