// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AnomalyDetector.Models
{
    /// <summary> ErrorResponse contains code and message that shows the error information. </summary>
    public partial class ErrorResponse
    {
        private Dictionary<string, BinaryData> _rawData;

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

        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="code"> The error code. </param>
        /// <param name="message"> The message explaining the error reported by the service. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ErrorResponse(string code, string message, Dictionary<string, BinaryData> rawData)
        {
            Code = code;
            Message = message;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ErrorResponse"/> for deserialization. </summary>
        internal ErrorResponse()
        {
        }

        /// <summary> The error code. </summary>
        public string Code { get; set; }
        /// <summary> The message explaining the error reported by the service. </summary>
        public string Message { get; set; }
    }
}
