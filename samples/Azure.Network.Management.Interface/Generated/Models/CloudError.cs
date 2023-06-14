// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Network.Management.Interface.Models
{
    /// <summary> An error response from the service. </summary>
    internal partial class CloudError
    {
        /// <summary> Initializes a new instance of CloudError. </summary>
        internal CloudError()
        {
        }

        /// <summary> Initializes a new instance of CloudError. </summary>
        /// <param name="error"> Cloud error body. </param>
        internal CloudError(CloudErrorBody error)
        {
            Error = error;
        }

        /// <summary> Cloud error body. </summary>
        public CloudErrorBody Error { get; }
    }
}
