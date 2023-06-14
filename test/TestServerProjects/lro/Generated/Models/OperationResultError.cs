// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The OperationResultError. </summary>
    internal partial class OperationResultError
    {
        /// <summary> Initializes a new instance of OperationResultError. </summary>
        internal OperationResultError()
        {
        }

        /// <summary> The error code for an operation failure. </summary>
        public int? Code { get; }
        /// <summary> The detailed arror message. </summary>
        public string Message { get; }
    }
}
