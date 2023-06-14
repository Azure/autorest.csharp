// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace azure_special_properties.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        /// <summary> Initializes a new instance of Error. </summary>
        internal Error()
        {
            ConstantId = ErrorConstantId._1;
        }

        /// <summary> Initializes a new instance of Error. </summary>
        /// <param name="status"></param>
        /// <param name="constantId"></param>
        /// <param name="message"></param>
        internal Error(int? status, ErrorConstantId constantId, string message)
        {
            Status = status;
            ConstantId = constantId;
            Message = message;
        }

        /// <summary> Gets the status. </summary>
        public int? Status { get; }
        /// <summary> Gets the constant id. </summary>
        public ErrorConstantId ConstantId { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
