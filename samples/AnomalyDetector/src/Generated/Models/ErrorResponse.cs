// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> ErrorResponse contains code and message that shows the error information. </summary>
    public partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="code"> The error code. </param>
        /// <param name="message"> The message explaining the error reported by the service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="code"/> or <paramref name="message"/> is null. </exception>
        public ErrorResponse(string code, string message)
        {
            Argument.AssertNotNull(code, nameof(code));
            Argument.AssertNotNull(message, nameof(message));

            Code = code;
            Message = message;
        }

        /// <summary> The error code. </summary>
        public string Code { get; set; }
        /// <summary> The message explaining the error reported by the service. </summary>
        public string Message { get; set; }
    }
}
