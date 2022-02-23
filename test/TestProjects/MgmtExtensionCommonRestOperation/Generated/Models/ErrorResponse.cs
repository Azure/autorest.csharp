// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtExtensionCommonRestOperation.Models
{
    /// <summary> Error response indicates that the service is not able to process the incoming request. The reason is provided in the error message. </summary>
    internal partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        internal ErrorResponse()
        {
        }

        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"> The details of the error. </param>
        internal ErrorResponse(string error)
        {
            Error = error;
        }

        /// <summary> The details of the error. </summary>
        public string Error { get; }
    }
}
