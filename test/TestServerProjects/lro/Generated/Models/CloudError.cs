// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace lro.Models
{
    /// <summary> The CloudError. </summary>
    public partial class CloudError
    {
        /// <summary> Initializes a new instance of CloudError. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of CloudError. </summary>
        /// <param name="status"> . </param>
        /// <param name="message"> . </param>
        internal CloudError(int? status, string message)
        {
            Status = status;
            Message = message;
        }

        public int? Status { get; }
        public string Message { get; }
    }
}
