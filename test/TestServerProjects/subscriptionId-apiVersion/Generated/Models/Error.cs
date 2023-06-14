// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace subscriptionId_apiVersion.Models
{
    /// <summary> The Error. </summary>
    internal partial class Error
    {
        /// <summary> Initializes a new instance of Error. </summary>
        internal Error()
        {
        }

        /// <summary> Initializes a new instance of Error. </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        internal Error(int? code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary> Gets the code. </summary>
        public int? Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
