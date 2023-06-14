// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtExtensionCommonRestOperation.Models
{
    /// <summary> An error response from a policy operation. </summary>
    internal partial class CloudError
    {
        /// <summary> Initializes a new instance of CloudError. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of CloudError. </summary>
        /// <param name="errorResponse"> Error response indicates that the service is not able to process the incoming request. The reason is provided in the error message. </param>
        internal CloudError(ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
        /// <summary> The details of the error. </summary>
        public string Error
        {
            get => ErrorResponse?.Error;
        }
    }
}
