// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtExtensionResource.Models
{
    /// <summary> An error response from a policy operation. </summary>
    internal partial class CloudError
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="CloudError"/>. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of <see cref="CloudError"/>. </summary>
        /// <param name="errorResponse"> Error response indicates that the service is not able to process the incoming request. The reason is provided in the error message. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CloudError(ErrorResponse errorResponse, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ErrorResponse = errorResponse;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> The details of the error. </summary>
        public string Error
        {
            get => ErrorResponse?.Error;
        }
    }
}
