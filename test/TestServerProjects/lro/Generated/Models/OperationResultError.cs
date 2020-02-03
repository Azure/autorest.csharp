// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace lro.Models
{
    /// <summary> The OperationResult-error. </summary>
    public partial class OperationResultError
    {
        /// <summary> The error code for an operation failure. </summary>
        public int? Code { get; set; }
        /// <summary> The detailed arror message. </summary>
        public string Message { get; set; }
    }
}
