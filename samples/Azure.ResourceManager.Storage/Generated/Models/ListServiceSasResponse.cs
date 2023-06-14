// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The List service SAS credentials operation response. </summary>
    public partial class ListServiceSasResponse
    {
        /// <summary> Initializes a new instance of ListServiceSasResponse. </summary>
        internal ListServiceSasResponse()
        {
        }

        /// <summary> Initializes a new instance of ListServiceSasResponse. </summary>
        /// <param name="serviceSasToken"> List service SAS credentials of specific resource. </param>
        internal ListServiceSasResponse(string serviceSasToken)
        {
            ServiceSasToken = serviceSasToken;
        }

        /// <summary> List service SAS credentials of specific resource. </summary>
        public string ServiceSasToken { get; }
    }
}
