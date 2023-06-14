// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ModelsTypeSpec.Models
{
    /// <summary> Output model that has property of its own type. </summary>
    public partial class ErrorModel
    {
        /// <summary> Initializes a new instance of ErrorModel. </summary>
        internal ErrorModel()
        {
        }

        /// <summary> Initializes a new instance of ErrorModel. </summary>
        /// <param name="message"> Error message. </param>
        /// <param name="innerError"> Required Record. </param>
        internal ErrorModel(string message, ErrorModel innerError)
        {
            Message = message;
            InnerError = innerError;
        }

        /// <summary> Error message. </summary>
        public string Message { get; }
        /// <summary> Required Record. </summary>
        public ErrorModel InnerError { get; }
    }
}
