// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> Operation status message object. </summary>
    public partial class StatusMessage
    {
        /// <summary> Initializes a new instance of <see cref="StatusMessage"/>. </summary>
        internal StatusMessage()
        {
        }

        /// <summary> Initializes a new instance of <see cref="StatusMessage"/>. </summary>
        /// <param name="status"> Status of the deployment operation. </param>
        /// <param name="errorResponse"> The error reported by the operation. </param>
        internal StatusMessage(string status, ErrorResponse errorResponse)
        {
            Status = status;
            ErrorResponse = errorResponse;
        }

        /// <summary> Status of the deployment operation. </summary>
        public string Status { get; }
        /// <summary> The error reported by the operation. </summary>
        internal ErrorResponse ErrorResponse { get; }
        /// <summary> The details of the error. </summary>
        public string Error
        {
            get => ErrorResponse?.Error;
        }
    }
}
