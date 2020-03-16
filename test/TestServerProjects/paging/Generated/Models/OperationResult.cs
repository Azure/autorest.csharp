// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace paging.Models
{
    /// <summary> The OperationResult. </summary>
    public partial class OperationResult
    {
        /// <summary> Initializes a new instance of OperationResult. </summary>
        internal OperationResult()
        {
        }

        /// <summary> Initializes a new instance of OperationResult. </summary>
        /// <param name="status"> The status of the request. </param>
        internal OperationResult(OperationResultStatus? status)
        {
            Status = status;
        }

        /// <summary> The status of the request. </summary>
        public OperationResultStatus? Status { get; internal set; }
    }
}
