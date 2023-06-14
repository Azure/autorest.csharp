// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.ResourceManager.Fake.Models
{
    /// <summary> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </summary>
    [PropertyReferenceType]
    public partial class ErrorResponse
    {
        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        [InitializationConstructor]
        public ErrorResponse()
        {
        }

        /// <summary> Initializes a new instance of ErrorResponse. </summary>
        /// <param name="error"> The error object. </param>
        [SerializationConstructor]
        internal ErrorResponse(ResponseError error)
        {
            Error = error;
        }

        /// <summary> The error object. </summary>
        public ResponseError Error { get; set; }
    }
}
