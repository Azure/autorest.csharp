// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace validation.Models
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
        /// <param name="fields"></param>
        internal Error(int? code, string message, string fields)
        {
            Code = code;
            Message = message;
            Fields = fields;
        }

        /// <summary> Gets the code. </summary>
        public int? Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
        /// <summary> Gets the fields. </summary>
        public string Fields { get; }
    }
}
