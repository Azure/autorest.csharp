// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary> The ErrorInformation. </summary>
    public partial class ErrorInformation
    {
        /// <summary> Initializes a new instance of ErrorInformation. </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        internal ErrorInformation(string code, string message)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> Gets the code. </summary>
        public string Code { get; }
        /// <summary> Gets the message. </summary>
        public string Message { get; }
    }
}
