// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;

namespace MgmtPropertyChooser.Models
{
    /// <summary> An error response for a resource management request. </summary>
    internal partial class CloudError
    {
        /// <summary> Initializes a new instance of CloudError. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of CloudError. </summary>
        /// <param name="error"> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </param>
        /// <param name="anotherError"> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </param>
        internal CloudError(ResponseError error, ResponseError anotherError)
        {
            Error = error;
            AnotherError = anotherError;
        }

        /// <summary> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </summary>
        public ResponseError Error { get; }
        /// <summary> Common error response for all Azure Resource Manager APIs to return error details for failed operations. (This also follows the OData error response format.). </summary>
        public ResponseError AnotherError { get; }
    }
}
