// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_byte.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        /// <summary> Initializes a new instance of Error. </summary>
        internal Error()
        {
        }

        /// <summary> Initializes a new instance of Error. </summary>
        /// <param name="status"> The Status. </param>
        /// <param name="message"> The Message. </param>
        internal Error(int? status, string message)
        {
            Status = status;
            Message = message;
        }

        /// <summary> The Status. </summary>
        public int? Status { get; }
        /// <summary> The Message. </summary>
        public string Message { get; }
    }
}
